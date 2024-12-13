namespace Api.Domain.Dtos.Appointment
{
    public class AppointmentUpdateResultDto : AppointmentBaseDto
    {
        public int Id { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
