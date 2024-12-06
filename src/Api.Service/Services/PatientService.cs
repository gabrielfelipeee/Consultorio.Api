using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services;
using FluentValidation;

namespace Api.Service.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _repository;
        private readonly IValidator<PatientEntity> _validator;
        public PatientService(IPatientRepository repository, IValidator<PatientEntity> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task ValidatePatient(PatientEntity patient)
        {
            var validationResult = await _validator.ValidateAsync(patient);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(string.Join("; ", validationResult.Errors.Select(e => e.ErrorMessage)));
            }
        }

        public async Task<List<PatientEntity>> GetAllAsync()
        {
            return await _repository.SelectAllWithAppointmentsAsync();
        }

        public async Task<PatientEntity> GetByIdAsync(int id)
        {
            return await _repository.SelectByIdWithAppointmentsAsync(id);
        }
        public async Task<PatientEntity> PostAsync(PatientEntity patient)
        {
            await ValidatePatient(patient);

            var newPatient = await _repository.InsertAsync(patient);
            return newPatient;
        }
        public async Task<PatientEntity> PutAsync(PatientEntity patient)
        {
            await ValidatePatient(patient);

            var updatedPatient = await _repository.UpdateAsync(patient);
            return updatedPatient;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}