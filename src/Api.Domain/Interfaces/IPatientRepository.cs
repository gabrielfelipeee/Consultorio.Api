using Api.Domain.Entities;

namespace Api.Domain.Interfaces
{
    public interface IPatientRepository: IRepository<PatientEntity>
    {
        Task<List<PatientEntity>> SelectAllWithAppointmentsAsync();
        Task<PatientEntity> SelectByIdWithAppointmentsAsync(int id);
    }
}
