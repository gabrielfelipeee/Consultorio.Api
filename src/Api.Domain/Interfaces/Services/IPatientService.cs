using Api.Domain.Dtos.Patient;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Services
{
    public interface IPatientService
    {
        Task<IEnumerable<PatientDto>> GetAllAsync();
        Task<PatientDto> GetByIdAsync(int id);
        Task<PatientCreateResultDto> PostAsync(PatientCreateDto patient);
        Task<PatientUpdateResultDto> PutAsync(PatientUpdateDto patient);
        Task<bool> DeleteAsync(int id);
    }
}
