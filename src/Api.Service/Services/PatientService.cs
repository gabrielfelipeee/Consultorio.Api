using Api.Domain.Dtos.Patient;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services;
using Api.Domain.Models;
using Api.Domain.Repository;
using Api.Service.Shared;
using AutoMapper;

namespace Api.Service.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _repository;
        private readonly IMapper _mapper;
        private readonly EntityValidationService<PatientEntity> _entityValidationService;
        private readonly EntityFluentValidationService<PatientCreateDto, PatientUpdateDto> _entityFluentValidationService;

        public PatientService(
            IPatientRepository repository,
            IMapper mapper,
            EntityValidationService<PatientEntity> entityValidationService,
            EntityFluentValidationService<PatientCreateDto, PatientUpdateDto> entityFluentValidationService)
        {
            _repository = repository;
            _mapper = mapper;
            _entityValidationService = entityValidationService;
            _entityFluentValidationService = entityFluentValidationService;
        }

        public async Task<IEnumerable<PatientDto>> GetAllAsync()
        {
            var entities = await _repository.SelectAllWithAppointmentsAsync();
            var dto = _mapper.Map<IEnumerable<PatientDto>>(entities);
            return dto;
        }

        public async Task<PatientDto> GetByIdAsync(int id)
        {
            await _entityValidationService.ValidateEntityAsync(id);

            var entity = await _repository.SelectByIdWithAppointmentsAsync(id);
            var dto = _mapper.Map<PatientDto>(entity);
            return dto;
        }
        public async Task<PatientCreateResultDto> PostAsync(PatientCreateDto patient)
        {
            await _entityFluentValidationService.ValidateCreateAsync(patient);

            var model = _mapper.Map<PatientModel>(patient);
            var entity = _mapper.Map<PatientEntity>(model);

            var result = await _repository.InsertAsync(entity);
            var dto = _mapper.Map<PatientCreateResultDto>(result);
            return dto;
        }
        public async Task<PatientUpdateResultDto> PutAsync(PatientUpdateDto patient)
        {
            await _entityValidationService.ValidateEntityAsync(patient.Id);

            await _entityFluentValidationService.ValidateUpdateAsync(patient);

            var model = _mapper.Map<PatientModel>(patient);
            var entity = _mapper.Map<PatientEntity>(model);

            var result = await _repository.UpdateAsync(entity);
            var dto = _mapper.Map<PatientUpdateResultDto>(result);
            return dto;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            await _entityValidationService.ValidateEntityAsync(id);

            return await _repository.DeleteAsync(id);
        }
    }
}
