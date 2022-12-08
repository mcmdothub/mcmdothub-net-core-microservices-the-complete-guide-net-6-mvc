namespace Deli.Web.Models
{
    // BETTER TO ISOLATE all Microservices
    public class ResponseDto
    {
        public bool IsSuccess { get; set; } = true;

        public object Result { get; set; }

        public string DisplayMessage { get; set; } = "";

        public List<string> ErrorMessages { get; set; }

    }
}
