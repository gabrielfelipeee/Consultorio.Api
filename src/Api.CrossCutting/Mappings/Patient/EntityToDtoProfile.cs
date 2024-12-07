using Api.Domain.Dtos.Patient;
using Api.Domain.Entities;
using AutoMapper;

namespace Api.CrossCutting.Mappings.Patient
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<PatientEntity, PatientDto>()
                .ReverseMap();

            CreateMap<PatientEntity, PatientCreateResultDto>()
                .ReverseMap();
                
            CreateMap<PatientEntity, PatientUpdateResultDto>()
                .ReverseMap();
        }
    }
}
