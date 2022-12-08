using Deli.Web.Models;
using Deli.Web.Services.IServices;

namespace Deli.Web.Services
{
    public class BaseService : IBaseService
    {
        public ResponseDto responseModel { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<T> SendAsync<T>(ApiRequest apiRequest)
        {
            throw new NotImplementedException();
        }
    }
}
