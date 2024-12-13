using Api.Domain.Dtos.Appointment;
using Api.Domain.Entities;
using AutoMapper;

namespace Api.CrossCutting.Mappings.Appointment
{
    public class EntityToDtoAppointmentProfile : Profile
    {
        public EntityToDtoAppointmentProfile()
        {
            CreateMap<AppointmentEntity, AppointmentDto>()
                .ReverseMap();

            CreateMap<AppointmentEntity, AppointmentCreateResultDto>()
                .ReverseMap();

            CreateMap<AppointmentEntity, AppointmentUpdateResultDto>()
                .ReverseMap();
        }
    }
}
