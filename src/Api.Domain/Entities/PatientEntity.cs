namespace Api.Domain.Entities
{
    public class PatientEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public List<AppointmentEntity> Appointments { get; set; }
    }
}
