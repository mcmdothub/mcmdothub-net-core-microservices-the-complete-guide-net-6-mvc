namespace Deli.Web
{
    // public static so we don't have to create an object
    public static class SD
    {
        public static string ProductAPIBase { get; set; }

        // create an enum which will be APIType whenever we make an API calls
        // the calls can be GET, POST, PUT, DELETE
        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE,
        }
    }
}
