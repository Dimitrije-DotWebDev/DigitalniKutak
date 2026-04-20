using Backend.Application.Common.Helpers;
using Microsoft.AspNetCore.Http;

namespace Backend.Application.Common.Services
{
    public class UploadFileService
    {
        public UploadFileService()
        {

        }

        public bool IsValidFile(IFormFile file, FileType fileType)
        {
            var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
            return FileExtensionHelper.AllowedExtensions[fileType].Contains(extension);
        }

        public string UploadFile(IFormFile file, FileType fileType, string destinationPath)
        {
            if (!IsValidFile(file, fileType))
            {
                return "";
            }

            destinationPath = Path.Combine(destinationPath, fileType.ToString());

            if (!Directory.Exists(destinationPath))
            {
                Directory.CreateDirectory(destinationPath);
            }
            var filePath = Path.Combine(destinationPath, file.FileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return filePath;
        }

        public void DeleteFile(string filePath)
        {
            Console.WriteLine(filePath);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
    }
}