using Api.Domain.Dtos.Appointment;
using Api.Domain.Models;
using AutoMapper;

namespace Api.CrossCutting.Mappings.Appointment
{
    public class DtoToModelAppointmentProfile : Profile
    {
        public DtoToModelAppointmentProfile()
        {
            CreateMap<AppointmentModel, AppointmentDto>()
                .ReverseMap();
            CreateMap<AppointmentModel, AppointmentCreateDto>()
                .ReverseMap();
            CreateMap<AppointmentModel, AppointmentUpdateDto>()
         .ReverseMap();
        }
    }
}
