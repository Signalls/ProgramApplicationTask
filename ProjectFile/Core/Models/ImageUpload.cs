namespace Core.Models
{
    public class ImageUpload
    {

        public string PublicId { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string SecureUrl { get; set; } = string.Empty;
        public string Format { get; set; } = string.Empty;
        public long Length { get; set; }

    }
}
