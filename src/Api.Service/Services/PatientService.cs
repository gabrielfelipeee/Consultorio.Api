using Api.Domain.Dtos.Patient;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services;
using Api.Domain.Models;
using AutoMapper;
using FluentValidation;

namespace Api.Service.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _repository;
        private readonly IMapper _mapper;
        private readonly IValidator<PatientCreateDto> _createValidator;
        private readonly IValidator<PatientUpdateDto> _updateValidator;

        public PatientService(
            IPatientRepository repository,
            IMapper mapper,
            IValidator<PatientCreateDto> createValidator,
            IValidator<PatientUpdateDto> updateValidator)
        {
            _repository = repository;
            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task<IEnumerable<PatientDto>> GetAllAsync()
        {
            var entities = await _repository.SelectAllWithAppointmentsAsync();
            var dto = _mapper.Map<IEnumerable<PatientDto>>(entities);
            return dto;
        }

        public async Task<PatientDto> GetByIdAsync(int id)
        {
            var entity = await _repository.SelectByIdWithAppointmentsAsync(id);
            if (entity == null)
            {
                throw new KeyNotFoundException($"Paciente com ID {id} não encontrado.");
            }

            var dto = _mapper.Map<PatientDto>(entity);
            return dto;
        }
        public async Task<PatientCreateResultDto> PostAsync(PatientCreateDto patient)
        {
            var validationResult = await _createValidator.ValidateAsync(patient);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var model = _mapper.Map<PatientModel>(patient);
            var entity = _mapper.Map<PatientEntity>(model);

            var result = await _repository.InsertAsync(entity);

            var dto = _mapper.Map<PatientCreateResultDto>(result);
            return dto;
        }
        public async Task<PatientUpdateResultDto> PutAsync(PatientUpdateDto patient)
        {
            // Verifica se o paciente existe
            var patientResult = await _repository.SelectByIdAsync(patient.Id);
            if (patientResult == null || patient.Id <= 0)
            {
                throw new KeyNotFoundException($"Paciente com ID {patient.Id} não encontrado.");
            }

            var validationResult = await _updateValidator.ValidateAsync(patient);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var model = _mapper.Map<PatientModel>(patient);
            var entity = _mapper.Map<PatientEntity>(model);

            var result = await _repository.UpdateAsync(entity);

            var dto = _mapper.Map<PatientUpdateResultDto>(result);

            return dto;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var result = await _repository.SelectByIdAsync(id);
            if (result == null || id <= 0)
            {
                throw new KeyNotFoundException($"Paciente com ID {id} não encontrado.");
            }
            return await _repository.DeleteAsync(id);
        }
    }
}
