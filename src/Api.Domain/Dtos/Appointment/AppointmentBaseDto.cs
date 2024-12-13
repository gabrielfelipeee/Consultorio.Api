namespace Api.Domain.Dtos.Appointment
{
    public class AppointmentBaseDto
    {
        public DateTime AppointmentDateTime { get; set; }
        public int Status { get; set; }
        public decimal Price { get; set; }
        public int PatientId { get; set; }
        public int SpecialtyId { get; set; }
        public int ProfessionalId { get; set; }
    }
}
