using Api.Domain.Dtos.Appointment;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Models;
using AutoMapper;
using FluentValidation;

namespace Api.Service.Services.Validations
{
    public class AppointmentValidationService
    {
        private readonly IRepository<PatientEntity> _patientRepository;
        private readonly IRepository<SpecialtyEntity> _specialtyRepository;
        private readonly IRepository<ProfessionalEntity> _professionalRepository;
        private readonly IValidator<AppointmentCreateDto> _createValidator;
        private readonly IValidator<AppointmentUpdateDto> _updateValidator;
        private readonly IMapper _mapper;

        public AppointmentValidationService(
            IRepository<PatientEntity> patientRepository,
            IRepository<SpecialtyEntity> specialtyRepository,
            IRepository<ProfessionalEntity> professionalRepository,
            IValidator<AppointmentCreateDto> createValidator,
            IValidator<AppointmentUpdateDto> updateValidator,
            IMapper mapper)
        {
            _patientRepository = patientRepository;
            _specialtyRepository = specialtyRepository;
            _professionalRepository = professionalRepository;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
            _mapper = mapper;
        }

        private async Task ValidateAppointmentDataAsync(AppointmentEntity appointment)
        {
            if (await _patientRepository.SelectByIdAsync(appointment.PatientId) == null)
                throw new KeyNotFoundException("O paciente informado não existe.");

            if (await _professionalRepository.SelectByIdAsync(appointment.ProfessionalId) == null)
                throw new KeyNotFoundException("O profissional informado não existe.");

            if (await _specialtyRepository.SelectByIdAsync(appointment.SpecialtyId) == null)
                throw new KeyNotFoundException("A especialidade informada não existe.");
        }

        public async Task ValidateCreateAppointmentAsync(AppointmentEntity appointment)
        {
            var model = _mapper.Map<AppointmentModel>(appointment);
            var createDto = _mapper.Map<AppointmentCreateDto>(model);
            var fluentValidationResult = await _createValidator.ValidateAsync(createDto);

            if (!fluentValidationResult.IsValid)
                throw new ValidationException(fluentValidationResult.Errors);

            await ValidateAppointmentDataAsync(appointment);
        }

        public async Task ValidateUpdateAppointmentAsync(AppointmentEntity appointment)
        {
            var model = _mapper.Map<AppointmentModel>(appointment);
            var updateDto = _mapper.Map<AppointmentUpdateDto>(model);
            var fluentValidationResult = await _updateValidator.ValidateAsync(updateDto);

            if (!fluentValidationResult.IsValid)
                throw new ValidationException(fluentValidationResult.Errors);

            await ValidateAppointmentDataAsync(appointment);
        }
    }
}
