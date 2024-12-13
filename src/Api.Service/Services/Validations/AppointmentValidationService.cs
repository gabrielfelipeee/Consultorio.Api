using Api.Domain.Entities;
using Api.Domain.Interfaces;

namespace Api.Service.Services.Validations
{
    public class AppointmentValidationService
    {
        private readonly IRepository<PatientEntity> _patientRepository;
        private readonly IRepository<SpecialtyEntity> _specialtyRepository;
        private readonly IRepository<ProfessionalEntity> _professionalRepository;

        public AppointmentValidationService(
            IRepository<PatientEntity> patientRepository,
            IRepository<SpecialtyEntity> specialtyRepository,
            IRepository<ProfessionalEntity> professionalRepository)
        {
            _patientRepository = patientRepository;
            _specialtyRepository = specialtyRepository;
            _professionalRepository = professionalRepository;
        }

        // Verifica se o paciente, profissional e especialidade existem
        public async Task ValidateAppointmentDataAsync(AppointmentEntity appointment)
        {
            if (await _patientRepository.SelectByIdAsync(appointment.PatientId) == null)
                throw new KeyNotFoundException("O paciente informado não existe.");

            if (await _professionalRepository.SelectByIdAsync(appointment.ProfessionalId) == null)
                throw new KeyNotFoundException("O profissional informado não existe.");

            if (await _specialtyRepository.SelectByIdAsync(appointment.SpecialtyId) == null)
                throw new KeyNotFoundException("A especialidade informada não existe.");
        }
    }
}
