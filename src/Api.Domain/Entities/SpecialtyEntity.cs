namespace Api.Domain.Entities
{
    public class SpecialtyEntity : BaseEntity
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public List<ProfessionalEntity> Professionals { get; set; }
        public List<AppointmentEntity> Appointments { get; set; }
    }
}
