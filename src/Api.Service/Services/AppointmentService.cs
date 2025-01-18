using Api.Domain.Dtos.Appointment;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services;
using Api.Domain.Models;
using Api.Service.Services.Validations;
using Api.Service.Shared;
using AutoMapper;

namespace Api.Service.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IRepository<AppointmentEntity> _repository;
        private readonly IMapper _mapper;
        private readonly EntityValidationService<AppointmentEntity> _entityValidationService;
        private readonly EntityFluentValidationService<AppointmentCreateDto, AppointmentUpdateDto> _entityFluentValidationService;
        private readonly AppointmentValidationService _appointmentValidationService;

        public AppointmentService(
            IRepository<AppointmentEntity> repository,
            IMapper mapper,
            EntityValidationService<AppointmentEntity> entityValidationService,
            EntityFluentValidationService<AppointmentCreateDto, AppointmentUpdateDto> entityFluentValidationService,
            AppointmentValidationService appointmentValidationService)
        {
            _repository = repository;
            _mapper = mapper;
            _entityValidationService = entityValidationService;
            _entityFluentValidationService = entityFluentValidationService;
            _appointmentValidationService = appointmentValidationService;
        }

        public async Task<IEnumerable<AppointmentDto>> GetAllAsync()
        {
            var entities = await _repository.SelectAllAsync();
            var dto = _mapper.Map<IEnumerable<AppointmentDto>>(entities);
            return dto;
        }

        public async Task<AppointmentDto> GetByIdAsync(int id)
        {
            // Verifica se o ID é válido, e se a entidade existe no DB.
            await _entityValidationService.ValidateEntityAsync(id);

            var entity = await _repository.SelectByIdAsync(id);
            var dto = _mapper.Map<AppointmentDto>(entity);
            return dto;
        }

        public async Task<AppointmentCreateResultDto> PostAsync(AppointmentCreateDto appointment)
        {
            // Verficação de dados
            await _entityFluentValidationService.ValidateCreateAsync(appointment);

            var model = _mapper.Map<AppointmentModel>(appointment);
            var entity = _mapper.Map<AppointmentEntity>(model);

            // Verifica se o paciente, profissional e especialidade existem
            await _appointmentValidationService.ValidateAppointmentDataAsync(entity);

            var result = await _repository.InsertAsync(entity);
            var dto = _mapper.Map<AppointmentCreateResultDto>(result);
            return dto;
        }

        public async Task<AppointmentUpdateResultDto> PutAsync(int id, AppointmentUpdateDto appointment)
        {
            await _entityValidationService.ValidateEntityAsync(id);

            await _entityFluentValidationService.ValidateUpdateAsync(appointment);

            var model = _mapper.Map<AppointmentModel>(appointment);
            var entity = _mapper.Map<AppointmentEntity>(model);

            await _appointmentValidationService.ValidateAppointmentDataAsync(entity);

            var result = await _repository.UpdateAsync(id, entity);
            var dto = _mapper.Map<AppointmentUpdateResultDto>(result);
            return dto;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            await _entityValidationService.ValidateEntityAsync(id);

            return await _repository.DeleteAsync(id);
        }
    }
}
