using System.IO;
using Application.Commons;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;

namespace Application.Utils
{
    public static class ImageUtil
    {
        public static async Task<string?> SaveImageAsync(AppConfiguration configuration, Type entityType, IFormFile file)
        {
            if (file == null || file.Length == 0)
                return null;

            Cloudinary cloudinary = new(configuration.CloudinaryConfig.GetCloudinaryURL());
            cloudinary.Api.Secure = true;

            var fileName = $"{Guid.NewGuid():N}_{file.FileName}";
            using var stream = file.OpenReadStream();
            var uploadParams = new ImageUploadParams()
            {
                Folder = entityType.Name,
                File = new FileDescription(fileName, stream),
                UseFilename = true,
                UniqueFilename = false,
                Overwrite = true,
            };
            var result = await cloudinary.UploadAsync(uploadParams);
            return result.Error == null ? fileName : null;
        }

        public static async Task<string?> GetImageAsync(AppConfiguration configuration, Type entityType, string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                return null;

            Cloudinary cloudinary = new(configuration.CloudinaryConfig.GetCloudinaryURL());
            cloudinary.Api.Secure = true;

            var path = $"{entityType.Name}/{fileName}";
            var result = await cloudinary.GetResourceAsync(new GetResourceParams(path));

            return result.Url;
        }

        public static async Task<bool> DeleteImageAsync(AppConfiguration configuration, Type entityType, string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                return false;

            Cloudinary cloudinary = new(configuration.CloudinaryConfig.GetCloudinaryURL());
            cloudinary.Api.Secure = true;

            var path = $"{entityType.Name}/{fileName}";
            var result = await cloudinary.DeleteResourcesAsync(path);

            return result.Error == null;
        }
    }
}
