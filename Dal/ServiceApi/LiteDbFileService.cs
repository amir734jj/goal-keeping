using System.Collections.ObjectModel;
using System.Net;
using Dal.Interfaces;
using LiteDB;
using Models.ViewModels.S3;

namespace Dal.ServiceApi
{
    public class LiteDbFileService : IFileService
    {
        private readonly ILiteStorage<string> _storage;

        public LiteDbFileService(ILiteDatabase database)
        {
            _storage = database.FileStorage;
        }

        public Task<GenericFileServiceResponse> Upload(string fileKey, string fileName, string contentType,
            Stream data, IDictionary<string, string> metadata)
        {
            metadata["Name"] = fileName;
            metadata["Content-Type"] = contentType;
            
            _storage.Upload(fileKey, fileName, data,
                new BsonDocument(
                    new Dictionary<string, BsonValue>(metadata.ToDictionary(x => x.Key, x => new BsonValue(x.Value)))));

            return Task.FromResult(new GenericFileServiceResponse(
                HttpStatusCode.Accepted,
                "Successfully uploaded file to LiteDb storage"
            ));
        }

        public Task<DownloadFileServiceResponse> Download(string keyName)
        {
            var result = new MemoryStream();
            var response = _storage.Download(keyName, result);
            
            var fileName = response.Metadata["Name"];
            var contentType = response.Metadata["Content-Type"];

            return Task.FromResult(new DownloadFileServiceResponse(
                HttpStatusCode.OK,
                "Successfully downloaded uploaded file from LiteDb storage",
                result,
                new ReadOnlyDictionary<string, string>(response.Metadata.ToDictionary(x => x.Key, x => x.Value.AsString)),
                contentType, fileName));
        }

        public Task<GenericFileServiceResponse> Delete(string keyName)
        {
            var status = _storage.Delete(keyName) ? HttpStatusCode.OK : HttpStatusCode.BadRequest;

            return Task.FromResult(new GenericFileServiceResponse(status, $"Deleting a file with key: {keyName}"));
        }

        public Task<List<string>> List()
        {
            return Task.FromResult(_storage.FindAll().Select(x => x.Id).ToList());
        }
    }
}