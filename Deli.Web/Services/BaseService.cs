using Deli.Web.Models;
using Deli.Web.Services.IServices;

using Newtonsoft.Json;

using System.Text;

namespace Deli.Web.Services
{
    public class BaseService : IBaseService
    {
        public ResponseDto responseModel { get; set; }
        public IHttpClientFactory httpClient { get; set; }

        public BaseService(IHttpClientFactory httpClient)
        {
            this.responseModel = new ResponseDto();
            this.httpClient = httpClient;
        }

        public async Task<T> SendAsync<T>(ApiRequest apiRequest)
        {
            try
            {
                // need to create a client object using httpClient an pass a name "DeliAPI"
                var client = httpClient.CreateClient("DeliAPI");

                // now on this created client we have to send an http request message
                HttpRequestMessage message = new HttpRequestMessage();

                // need to configure the Headers with Add of type "Accept" as "application/json"
                message.Headers.Add("Accept", "application/json");

                // we need to define the Uri for where it should be send
                message.RequestUri = new Uri(apiRequest.Url);

                // after on this client if there are any default request headers we will clear them
                client.DefaultRequestHeaders.Clear();

                // we check if the apiRequest has any data
                if (apiRequest.Data != null)
                {
                    // if there is we have to serialize that data and assign it to "message.Content"
                    message.Content = new StringContent(
                        JsonConvert.SerializeObject(apiRequest.Data), Encoding.UTF8, "application/json");
                }

                // once we populate the data we will get a ResponseMessage
                HttpResponseMessage apiResponse = null;

                // what is the type of the message? GET,POST,DELETE
                switch (apiRequest.ApiType)
                {
                    case SD.ApiType.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case SD.ApiType.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    case SD.ApiType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                    default:
                        message.Method = HttpMethod.Get;
                        break;
                }

                // next we need to call the client and sent the API, so we will get a apiResponse
                apiResponse = await client.SendAsync(message);

                // once we get the response we have to convert it or read as string
                var apiContent = await apiResponse.Content.ReadAsStringAsync();

                // then we need to deserialize , the type is generic "T" as the SendAsync<T>
                var apiResponseDto = JsonConvert.DeserializeObject<T>(apiContent);

                return apiResponseDto;
            }
            catch (Exception e)
            {
                // if there is an exception
                // first create a var dto as a new ResponseDto and add a display message
                var dto = new ResponseDto
                {
                    DisplayMessage = "Error",
                    ErrorMessages = new List<string> { Convert.ToString(e.Message) },
                    IsSuccess = false
                };

                var res = JsonConvert.SerializeObject(dto);
                var apiResponseDto = JsonConvert.DeserializeObject<T>(res);

                return apiResponseDto;
            }
        }

        // We can even ignore Dispose since this method has not been implemented
        public void Dispose()
        {
            // G.S. garbage collection that suppress finalize
            GC.SuppressFinalize(true);
        }
    }
}
