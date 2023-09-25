using Data.Models;

namespace Data.Dtos
{
    public class ApplicationTemplateDto
    {
        public string CoverImageUrl { get; set; }
        public PersonalInfo PersonalInformation { get; set; }
        public string PersonalInformationId { get; set; }

        //public AdditionalQuestion AdditionalQuestion { get; set; }
    }
}
