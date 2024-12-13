using Api.Domain.Entities;
using Api.Domain.Models;
using AutoMapper;

namespace Api.CrossCutting.Mappings.Appointment
{
    public class ModelToEntityAppointmentProfile : Profile
    {
        public ModelToEntityAppointmentProfile()
        {
            CreateMap<AppointmentModel, AppointmentEntity>()
                .ReverseMap();
        }
    }
}
