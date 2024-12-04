namespace Api.Domain.Entities
{
    public class ProfessionalSpecialtyEntity
    {
        public int ProfessionalId { get; set; }
        public ProfessionalEntity Professional { get; set; }
        public int SpecialtyId { get; set; }
        public SpecialtyEntity Specialty { get; set; }
    }
}
