using Api.Domain.Entities;
using Api.Domain.Models;
using AutoMapper;

namespace Api.CrossCutting.Mappings.Patient
{
    public class ModelToEntityPatientProfile : Profile
    {
        public ModelToEntityPatientProfile()
        {
            CreateMap<PatientModel, PatientEntity>()
                .ReverseMap();
        }
    }
}
