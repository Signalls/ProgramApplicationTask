using Data.Enum;
using System.ComponentModel.DataAnnotations;

namespace Data.Dtos
{
    public class WorkFlowDto
    {
        [Required(ErrorMessage = "Id is required.")]
        public string Id { get; set; }
        public string StageName { get; set; }
        public StageType StageType { get; set; }
    }
}
