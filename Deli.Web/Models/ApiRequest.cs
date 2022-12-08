using static Deli.Web.SD;

namespace Deli.Web.Models
{
    // whenever we make an API request
    // what are the values we need by default?
    public class ApiRequest
    {
        // is a GET,POST OR DELETE ? ...we set by default "ApiType.GET"
        public ApiType ApiType { get; set; } = ApiType.GET;


        // to which url we want to send this API request?
        public string Url { get; set; }


        // if there is anything that needs to be passsed in message body we need to store that and pass that along
        // object(generic) since we are not sure what is the type of the Data
        public object Data { get; set; }


        // we will have a string object for token
        // will require tokens to be passed to each request so they can be validated
        public string AccessToken { get; set; }
    }
}
