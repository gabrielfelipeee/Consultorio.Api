using Api.Data.Context;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Repository
{
    public class PatientRepository : BaseRepository<PatientEntity>, IPatientRepository
    {
        private readonly ConsultorioContext _consultorioContext;
        public PatientRepository(ConsultorioContext consultorioContext) : base(consultorioContext)
        {
            _consultorioContext = consultorioContext;
        }

        public async Task<List<PatientEntity>> SelectAllWithAppointmentsAsync()
        {
            return await _consultorioContext.Patients
                .Include(p => p.Appointments)
                .ToListAsync();
        }

        public async Task<PatientEntity> SelectByIdWithAppointmentsAsync(int id)
        {
            return await _consultorioContext.Patients
                .Include(p => p.Appointments)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
