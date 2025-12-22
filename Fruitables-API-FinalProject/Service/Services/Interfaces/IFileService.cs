using Microsoft.AspNetCore.Http;

namespace Service.Services.Interfaces
{
    public interface IFileService
    {
        Task<string> UploadFileAsync(IFormFile file,string folder);
        void DeleteFile(string file,string folder);
    }
}
