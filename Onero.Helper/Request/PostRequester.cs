using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Onero.Helper.Models;

namespace Onero.Helper.Request
{
    public class PostRequester
    {
        private static readonly HttpClient client = new HttpClient();

        public static async Task<T> GenericPost<T>(string url, Dictionary<string, string> values) where T : GenericPostResult, new()
        {
            var result = new T();

            try
            {
                var encodedContent = new FormUrlEncodedContent(values);

                using (HttpResponseMessage response = await client.PostAsync(url, encodedContent))
                {
                    using (HttpContent content = response.Content)
                    {
                        // need these to return to Form for display
                        string resultString = await content.ReadAsStringAsync();
                        string reasonPhrase = response.ReasonPhrase;
                        HttpResponseHeaders headers = response.Headers;
                        HttpStatusCode code = response.StatusCode;

                        result.result = resultString;
                        result.reasonPhrase = reasonPhrase;
                        result.headers = headers;
                        result.code = code;
                    }
                }
            }
            catch (Exception ex)
            {
                result.errorMessage = ex.Message;
            }
            return result;
        }
    }
}
