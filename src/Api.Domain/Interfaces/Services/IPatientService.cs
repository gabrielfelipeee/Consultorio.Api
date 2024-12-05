using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Services
{
    public interface IPatientService
    {
        Task<List<PatientEntity>> GetAllAsync();
        Task<PatientEntity> GetByIdAsync(int id);
        Task<PatientEntity> PostAsync(PatientEntity patient);
        Task<PatientEntity> PutAsync(PatientEntity patient);
        Task<bool> DeleteAsync(int id);
    }
}
