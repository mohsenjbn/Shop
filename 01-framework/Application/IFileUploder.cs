using Microsoft.AspNetCore.Http;

namespace _01_framework.Application
{
    public interface  IFileUploder
    {
        string Upload(IFormFile file, string path);
    }
}
