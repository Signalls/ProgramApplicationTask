using Data.Enum;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Data.Dtos
{
    public class ApplicationTemplateRequestDto
    {
        [Required(ErrorMessage = "Id is required.")]
        public string Id { get; set; }
        public IFormFile file { get; set; }
        public PersonalInfoDto PersonalInformation { get; set; }

        public Mandatory Education { get; set; }
        public Mandatory Experience { get; set; }
        public Mandatory Resume { get; set; }
    }
}
