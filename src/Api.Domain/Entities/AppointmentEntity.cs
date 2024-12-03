namespace Api.Domain.Entities
{
    public class AppointmentEntity : BaseEntity
    {
        public DateTime ApppointmentDateTime { get; set; }
        public int Status { get; set; }
        public decimal Price { get; set; }
        public int PatientId { get; set; }
        public PatientEntity Patient { get; set; }
        public int SpecialtyId { get; set; }
        public SpecialtyEntity Specialty { get; set; }
        public int ProfessionalId { get; set; }
        public ProfessionalEntity Professional { get; set; }
    }
}
