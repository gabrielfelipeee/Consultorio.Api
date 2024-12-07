namespace Api.Domain.Dtos.Patient
{
    public class PatientUpdateResultDto : PatientBaseDto
    {
        public int Id { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
