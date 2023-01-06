using MangoWeb.Models;
using MangoWeb.Services.IServices;

namespace MangoWeb.Services
{
    public class BaseService : IBaseService
    {
        public ResponseDTO ResponseModel { get; set; }
        public IHttpClientFactory _httpClient { get; set; }

        public BaseService(IHttpClientFactory httpClient)
        {
            ResponseModel = new ResponseDTO();
            _httpClient = httpClient;
        }

        public Task<T> SendAsync<T>(ApiRequest apiRequest)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }
    }
}
