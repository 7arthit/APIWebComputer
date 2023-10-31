using System.Net;

namespace ExWebComputer.DTOs
{
    public class AppResponse
    {
        public int id { get; set; }

        public HttpStatusCode code { get; set; }

        public string Message { get; set; }
    }
}
