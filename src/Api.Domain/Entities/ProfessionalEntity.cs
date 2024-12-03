namespace Api.Domain.Entities
{
    public class ProfessionalEntity : BaseEntity
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public List<AppointmentEntity> Appointments { get; set; }
        public List<SpecialtyEntity> Specialties { get; set; }
    }
}
