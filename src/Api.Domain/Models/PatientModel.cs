using Api.Domain.Entities;

namespace Api.Domain.Models
{
    public class PatientModel : BaseModel
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private string _cpf;
        public string Cpf
        {
            get { return _cpf; }
            set { _cpf = value; }
        }
        private string _email;
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        private string _Telephone;
        public string Telephone
        {
            get { return _Telephone; }
            set { _Telephone = value; }
        }
        public List<AppointmentEntity> _appointments;
        public List<AppointmentEntity> Appointments
        {
            get { return _appointments;}
            set { _appointments = value;}
        }
    }
}
