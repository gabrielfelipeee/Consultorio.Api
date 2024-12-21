using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Implementation
{
    public class PatientImplementation : BaseRepository<PatientEntity>, IPatientRepository
    {
        private DbSet<PatientEntity> _dataset;
        public PatientImplementation(ConsultorioContext consultorioContext) : base(consultorioContext)
        {
            _dataset = consultorioContext.Set<PatientEntity>();
        }

        public async Task<IEnumerable<PatientEntity>> SelectAllWithAppointmentsAsync()
        {
            return await _dataset
                    .Include(p => p.Appointments)
                    .ToListAsync();
        }

        public async Task<PatientEntity> SelectByIdWithAppointmentsAsync(int id)
        {
            return await _dataset
                    .Include(p => p.Appointments)
                    .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
