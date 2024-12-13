namespace Api.Domain.Models
{
    public class AppointmentModel : BaseModel
    {
        private DateTime _appointmentDateTime;
        public DateTime AppointmentDateTime
        {
            get { return _appointmentDateTime; }
            set { _appointmentDateTime = value; }
        }
        private int _status;
        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }
        private decimal _price;
        public decimal Price
        {
            get { return _price; }
            set { _price = value; }
        }

        private int _patientId;
        public int PatientId
        {
            get { return _patientId; }
            set { _patientId = value; }
        }
        private int _specialtyId;
        public int SpecialtyId
        {
            get { return _specialtyId; }
            set { _specialtyId = value; }
        }
        private int _professionalId;
        public int ProfessionalId
        {
            get { return _professionalId; }
            set { _professionalId = value; }
        }
    }
}
