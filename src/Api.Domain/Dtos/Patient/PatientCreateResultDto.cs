namespace Api.Domain.Dtos.Patient
{
    public class PatientCreateResultDto :  PatientBaseDto
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
