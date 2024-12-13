using Api.Domain.Dtos.Appointment;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services;
using Api.Domain.Models;
using Api.Service.Services.Validations;
using AutoMapper;

namespace Api.Service.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IRepository<AppointmentEntity> _repository;
        private readonly IMapper _mapper;
        private readonly AppointmentValidationService _validationService;
        private readonly EntityValidationService<AppointmentEntity> _entityValidationService;

        public AppointmentService(
            IRepository<AppointmentEntity> repository,
            IMapper mapper,
            AppointmentValidationService validationService,
            EntityValidationService<AppointmentEntity> entityValidationService)
        {
            _repository = repository;
            _mapper = mapper;
            _validationService = validationService;
            _entityValidationService = entityValidationService;
        }

        public async Task<IEnumerable<AppointmentDto>> GetAllAsync()
        {
            var entities = await _repository.SelectAllAsync();
            var dto = _mapper.Map<IEnumerable<AppointmentDto>>(entities);
            return dto;
        }

        public async Task<AppointmentDto> GetByIdAsync(int id)
        {
            await _entityValidationService.ValidateIdAsync(id);
            await _entityValidationService.ValidateEntityExistsAsync(id);

            var entity = await _repository.SelectByIdAsync(id);
            var dto = _mapper.Map<AppointmentDto>(entity);
            return dto;
        }

        public async Task<AppointmentCreateResultDto> PostAsync(AppointmentCreateDto appointment)
        {
            var model = _mapper.Map<AppointmentModel>(appointment);
            var entity = _mapper.Map<AppointmentEntity>(model);

            await _validationService.ValidateCreateAppointmentAsync(entity);

            var result = await _repository.InsertAsync(entity);
            var dto = _mapper.Map<AppointmentCreateResultDto>(result);
            return dto;
        }

        public async Task<AppointmentUpdateResultDto> PutAsync(AppointmentUpdateDto appointment)
        {
            await _entityValidationService.ValidateIdAsync(appointment.Id);
            await _entityValidationService.ValidateEntityExistsAsync(appointment.Id);

            var model = _mapper.Map<AppointmentModel>(appointment);
            var entity = _mapper.Map<AppointmentEntity>(model);

            await _validationService.ValidateUpdateAppointmentAsync(entity);

            var result = await _repository.UpdateAsync(entity);

            var dto = _mapper.Map<AppointmentUpdateResultDto>(result);
            return dto;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            await _entityValidationService.ValidateIdAsync(id);
            await _entityValidationService.ValidateEntityExistsAsync(id);

            return await _repository.DeleteAsync(id);
        }
    }
}
