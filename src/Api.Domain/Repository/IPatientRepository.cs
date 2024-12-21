using Api.Domain.Entities;
using Api.Domain.Interfaces;

namespace Api.Domain.Repository
{
    public interface IPatientRepository : IRepository<PatientEntity>
    {
        Task<IEnumerable<PatientEntity>> SelectAllWithAppointmentsAsync();
        Task<PatientEntity> SelectByIdWithAppointmentsAsync(int id);
    }
}
