namespace Api.Domain.Dtos.Appointment
{
    public class AppointmentCreateResultDto :  AppointmentBaseDto
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
