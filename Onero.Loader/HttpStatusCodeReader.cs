using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;

namespace Onero.Loader
{
    public class HttpStatusCodeReader
    {
        private readonly IEnumerable<Uri> uris;
        private readonly int[] httpStatusCodes;
        private readonly object syncLock;
        private int completed;

        public HttpStatusCodeReader(IEnumerable<Uri> uris)
        {
            if (uris == null)
            {
                throw new ArgumentNullException("uris");
            }

            foreach (Uri uri in uris)
            {
                if (uri.Scheme != Uri.UriSchemeHttp && uri.Scheme != Uri.UriSchemeHttps)
                {
                    throw new ArgumentException($"{uri} is not valid http(s) uri.", "uris");
                }
            }

            this.uris = uris;
            this.httpStatusCodes = new int[uris.Count()];
            this.syncLock = new object();
            this.completed = 0;
        }

        public Dictionary<Uri, bool> GetHttpStatusCodes()
        {
            for (int i = 0; i < httpStatusCodes.Length; ++i)
            {
                HttpWebRequest httpWebRequest = WebRequest.Create(uris.ElementAt(i)) as HttpWebRequest;
                httpWebRequest.Method = "HEAD";
                httpWebRequest.AllowAutoRedirect = true;
                httpWebRequest.BeginGetResponse(GetResponseCompleted, new object[] { httpWebRequest, i });
            }
            lock (syncLock)
            {
                while (completed < httpStatusCodes.Length)
                {
                    Monitor.Wait(syncLock);
                }
            }

            var results = new Dictionary<Uri, bool>();

            for (int i = 0; i < httpStatusCodes.Length; i++)
            {
                results.Add(uris.ElementAt(i), httpStatusCodes[i] == 200);
            }

            return results;
        }

        private void GetResponseCompleted(IAsyncResult ar)
        {
            object[] objects = ar.AsyncState as object[];
            HttpWebRequest httpWebRequest = objects[0] as HttpWebRequest;

            int index = (int)objects[1];
            HttpWebResponse httpWebResponse = null;

            try
            {
                httpWebResponse = httpWebRequest.EndGetResponse(ar) as HttpWebResponse;
                httpStatusCodes[index] = (int)httpWebResponse.StatusCode;
            }
            catch (WebException webException)
            {
                httpWebResponse = webException.Response as HttpWebResponse;
                if (httpWebResponse != null)
                {
                    httpStatusCodes[index] = (int)httpWebResponse.StatusCode;
                }
            }
            finally
            {
                httpWebResponse?.Close();

                lock (syncLock)
                {
                    Interlocked.Add(ref completed, 1);
                    Monitor.Pulse(syncLock);
                }
            }
        }
    }
}
