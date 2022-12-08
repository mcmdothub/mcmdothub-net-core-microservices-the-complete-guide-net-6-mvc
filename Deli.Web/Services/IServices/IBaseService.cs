using Deli.Web.Models;

namespace Deli.Web.Services.IServices
{
    public interface IBaseService : IDisposable
    {
        ResponseDto responseModel { get; set; }

        // create a generic method "SendAsync" to send the request
        // return type is generic "T"
        Task<T> SendAsync<T>(ApiRequest apiRequest);
    }
}
