using System.Net;
using System.Net.Http.Headers;

namespace Onero.Helper.Models
{
    public class GenericPostResult
    {
        public string result { get; set; }
        public string reasonPhrase { get; set; }
        public HttpResponseHeaders headers { get; set; }
        public HttpStatusCode code { get; set; }
        public string errorMessage { get; set; }
    }
}
