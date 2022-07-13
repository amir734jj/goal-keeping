using System.Net;
using Dal.Interfaces;
using Logic.Interfaces;
using Microsoft.AspNetCore.Http.Internal;
using Models.ViewModels.Api;

namespace Logic.Logic
{
    public class ImageUploadLogic : IImageUploadLogic
    {
        private readonly IFileService _fileService;

        public ImageUploadLogic(IFileService fileService)
        {
            _fileService = fileService;
        }
        
        public async Task<string> Upload(UploadViewModel file)
        {
            // Randomly assign a key!
            var key = Guid.NewGuid().ToString();

            await _fileService.Upload(key, file.File.Name, file.File.ContentType, file.File.OpenReadStream(), new Dictionary<string, string>
            {
                ["Description"] = file.Description
            });

            return key;
        }

        public async Task<UploadViewModel> Download(Guid id)
        {
            var response = await _fileService.Download(id.ToString());

            var formFile = new FormFile(response.Data, 0, response.Data.Length, id.ToString(), response.Name)
            {
                ContentType = response.ContentType
            };

            return new UploadViewModel
            {
                File = formFile,
                Description = response.MetaData["Description"]
            };
        }

        public async Task<bool> Delete(Guid id)
        {
            var response = await _fileService.Delete(id.ToString());

            return response.Status != HttpStatusCode.BadRequest;
        }
    }
}