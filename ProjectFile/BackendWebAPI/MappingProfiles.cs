using AutoMapper;
using Data.Dtos;
using Data.Models;

namespace BackendAPI.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ProgramDetails, ProgramDetailsDto>().ReverseMap();
            CreateMap<ProgramDetails, ProgramDetailUpdateDto>().ReverseMap();
            CreateMap<ProgramDetails, ApplicationTemplateRequestDto>().ReverseMap();
            CreateMap<PersonalInfo, PersonalInfoDto>().ReverseMap();
            CreateMap<ProgramDetails, WorkFlowDto>().ReverseMap();
            CreateMap<ProgramDetails, ApplicationPreviewDto>().ReverseMap();
        }
    }
}
