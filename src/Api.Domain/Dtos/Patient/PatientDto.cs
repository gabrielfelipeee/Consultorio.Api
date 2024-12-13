using Api.Domain.Dtos.Appointment;

namespace Api.Domain.Dtos.Patient
{
    public class PatientDto : PatientBaseDto
    {
        public int Id { get; set; }
        public List<AppointmentDto>? Appointments { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
