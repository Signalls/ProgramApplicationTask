using Data.Enum;
using System.ComponentModel.DataAnnotations;

namespace Data.Dtos
{
    public class ProgramDetailUpdateDto
    {
        [Required(ErrorMessage = "Id is required.")]
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Summary { get; set; }
        public string Skills { get; set; }

        public string Benefits { get; set; }

        public string ApplicationCriteria { get; set; }

        public ProgramType programType { get; set; }

        public Duration ProgramDuration { get; set; }

        public MiniQualification mininmumQualification { get; set; }

        public int MaxNumberOfApplication { get; set; }
        public string Location { get; set; }
        public DateTime ProgramStart { get; set; }
        public DateTime ApplicationClose { get; set; }
    }

}
