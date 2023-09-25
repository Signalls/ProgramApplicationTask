using System.ComponentModel.DataAnnotations;

namespace Data.Dtos
{
    public class ApplicationPreviewDto
    {
        [Required(ErrorMessage = "Id is required.")]
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Summary { get; set; }

        public string Benefits { get; set; }

        public string ApplicationCriteria { get; set; }
    }
}
