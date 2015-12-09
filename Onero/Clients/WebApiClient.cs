using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web.Script.Serialization;

namespace Onero
{
    public class WebApiClient : IParseable
    {
        private readonly string url;
        private readonly string login;
        private readonly string password;

        public WebApiClient(string url, string login, string password)
        {
            this.url = url;
            this.login = login;
            this.password = password;
        }

        private string Hostname
        {
            get
            {
                Uri uri = new Uri(url);
                return string.Format("{0}://{1}", uri.Scheme, uri.Host.TrimEnd('/'));
            }
        }

        public IEnumerable<string> Parse()
        {
            var jsonRaw = ReadWebApi(url, login, password);

            return ProcessJson(jsonRaw);
        }

        private IEnumerable<string> ProcessJson(string jsonRaw)
        {
            var jsonPased = (JsonResponse)new JavaScriptSerializer().Deserialize(jsonRaw, typeof(JsonResponse));

            if (jsonPased.statusCode == 200)
            {
                return jsonPased.result.items.Select(i => Hostname + i.GetUrl());
            }
            else
            {
                throw new Exception(jsonPased.error.Message);
            }
        }

        private string ReadWebApi(string url, string login, string password)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
            httpWebRequest.Method = "GET";

            if (!string.IsNullOrWhiteSpace(login) && !string.IsNullOrWhiteSpace(password))
            {
                httpWebRequest.Headers["X-Scitemwebapi-Username"] = login;
                httpWebRequest.Headers["X-Scitemwebapi-Password"] = password;
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            string responseText;
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                responseText = streamReader.ReadToEnd();
            }

            return responseText;
        }
    }
}
