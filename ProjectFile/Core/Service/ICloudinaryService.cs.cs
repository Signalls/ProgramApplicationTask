using Core.Models;
using Microsoft.AspNetCore.Http;

namespace Core.Service
{
    public interface ICloudinaryService
    {
        Task<ImageUpload> UploadImageAsync(IFormFile image);
    }
}
