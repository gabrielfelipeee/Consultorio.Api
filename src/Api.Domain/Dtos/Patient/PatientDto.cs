using Api.Domain.Entities;

namespace Api.Domain.Dtos.Patient
{
    public class PatientDto : PatientBaseDto
    {
        public int Id { get; set; }
        public List<AppointmentEntity>? Appointments { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
