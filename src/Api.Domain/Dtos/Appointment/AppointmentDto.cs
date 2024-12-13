namespace Api.Domain.Dtos.Appointment
{
    public class AppointmentDto : AppointmentBaseDto
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
