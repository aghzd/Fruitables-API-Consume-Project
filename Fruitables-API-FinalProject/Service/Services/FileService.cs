using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment _env;
        public FileService(IWebHostEnvironment env)
        {
            _env = env;
        }

        public void DeleteFile(string file, string folder)
        {
            string path = Path.Combine(_env.WebRootPath,folder, file);
            if (File.Exists(path)) 
                File.Delete(path);
        }

        public async Task<string> UploadFileAsync(IFormFile file, string folder)
        {
            string fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);

            string path = Path.Combine(_env.WebRootPath, folder , fileName);

            using var stream = new FileStream(path, FileMode.Create);
            await file.CopyToAsync(stream);
            return  fileName;
        }
    }
}
