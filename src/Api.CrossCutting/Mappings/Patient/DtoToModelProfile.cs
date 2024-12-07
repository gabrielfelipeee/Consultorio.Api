using Api.Domain.Dtos.Patient;
using Api.Domain.Models;
using AutoMapper;

namespace Api.CrossCutting.Mappings.Patient
{
    public class DtoToModelProfile : Profile
    {
        public DtoToModelProfile()
        {
            CreateMap<PatientModel, PatientDto>()
                .ReverseMap();

            CreateMap<PatientModel, PatientCreateDto>()
                .ReverseMap();

            CreateMap<PatientModel, PatientUpdateDto>()
                .ReverseMap();
        }
    }
}
