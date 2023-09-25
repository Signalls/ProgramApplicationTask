using AutoMapper;
using Backend.Repository;
using Core.Service;
using Data.Dtos;
using Data.Models;
using Data.Repository;

namespace Data.Service
{
    public class ApplicationTemplateService : IApplicationTemplateService
    {
        private readonly IProgramDetailsRepo _programDetailsRepo;
        private readonly ICloudinaryService _image;
        private readonly IMapper _mapper;
        private readonly IPersonalInfoRepo _personalInfo;


        public ApplicationTemplateService(IProgramDetailsRepo programDetailsRepo, ICloudinaryService image, IPersonalInfoRepo personalInfo, IMapper mapper)
        {
            _programDetailsRepo = programDetailsRepo;
            _image = image;
            _mapper = mapper;
            _personalInfo = personalInfo;

        }

        public async Task<APIResponseDto> UpdateProgram(ApplicationTemplateRequestDto templateRequestDto)
        {
            var response = new APIResponseDto();
            var imageUpload = await _image.UploadImageAsync(templateRequestDto.file);
            var person = new PersonalInfo();
            var personalInfo = _mapper.Map<PersonalInfo>(templateRequestDto.PersonalInformation);
            personalInfo.Id = person.Id;
            var programUpdate = new ProgramDetails();
            programUpdate.Id = templateRequestDto.Id;
            programUpdate.Education = templateRequestDto.Education;
            programUpdate.Experience = templateRequestDto.Experience;
            programUpdate.Resume = templateRequestDto.Resume;
            programUpdate.PersonalInformationId = personalInfo.Id;
            await _personalInfo.CreatePersonalInfoAsync(personalInfo);
            programUpdate.CoverImageUrl = imageUpload.Url;
            programUpdate.PersonalInformationId = personalInfo.Id;
            var updateProgram = await _programDetailsRepo.UpdateProgram(programUpdate);
            if(updateProgram)
            {
                response.StatusCode = 200;
                response.Message = "Program updated successfully";
                return response;
            }
            response.StatusCode = 500;
            response.Message = "Failed";
            return response;


        }
        public async Task<APIResponseDto> GetProgram(string Id)
        {
            var response = new APIResponseDto();
            var program = await _programDetailsRepo.GetProgram(Id);
            var person = await _personalInfo.GetPersonalInfoAsync(program.PersonalInformationId);
            var persondto = _mapper.Map<PersonalInfoDto>(person);
            var template = new ApplicationTemplateRequestDto();
            template.Education = program.Education;
            template.Experience = program.Experience;
            template.Resume = program.Resume;
            template.PersonalInformation = persondto;
            if(template.PersonalInformation != null)
            {
                response.StatusCode = 200;
                response.Message = "Program retrievd successfully";
                return response;
            }
            response.StatusCode = 500;
            response.Message = "Failed";
            return response;


        }
    }

}
