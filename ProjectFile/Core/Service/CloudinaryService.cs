using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Core.Service
{
    public class CloudinaryService : ICloudinaryService
    {
        private readonly Cloudinary _cloudinary;

        public CloudinaryService(IConfiguration configuration)
        {
            var cloudinaryConfig = new Account(
                configuration["CloudinarySettings:CloudName"],
                configuration["CloudinarySettings:ApiKey"],
                configuration["CloudinarySettings:ApiSecret"]
            );

            _cloudinary = new Cloudinary(cloudinaryConfig);
        }
        public async Task<ImageUpload> UploadImageAsync(IFormFile image)
        {
            if(image == null || image.Length == 0)
            {
                throw new ArgumentException("Invalid image");
            }

            // Convert the image to bytes
            byte[] imageBytes;
            using(var memoryStream = new MemoryStream())
            {
                await image.CopyToAsync(memoryStream);
                imageBytes = memoryStream.ToArray();
            }

            // Upload the image using Cloudinary
            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(image.FileName, new MemoryStream(imageBytes)),
                // Set other upload parameters as needed
            };

            var uploadResult = await _cloudinary.UploadAsync(uploadParams);

            if(uploadResult.Error != null)
            {
                throw new Exception(uploadResult.Error.Message);
            }

            return new ImageUpload
            {
                PublicId = uploadResult.PublicId,
                Url = uploadResult.Url.ToString(),
                SecureUrl = uploadResult.SecureUrl.ToString(),
                Format = uploadResult.Format,
                Length = image.Length
            };
        }
    }
}
