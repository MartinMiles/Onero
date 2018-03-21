using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml;

namespace Onero
{
    public class SitemapClient : IParseable
    {
        private readonly string url;
        private static Dictionary<string, IEnumerable<string>> savedSitemaps;

        public SitemapClient(string url)
        {
            this.url = url;

            if (savedSitemaps == null)
            {
                savedSitemaps = new Dictionary<string, IEnumerable<string>>();
            }
        }

        public IEnumerable<string> Parse()
        {
            if (!savedSitemaps.ContainsKey(url))
            {
                savedSitemaps.Add(url, Load());
            }

            return savedSitemaps[url];
        }

        private IEnumerable<string> Load()
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            
            // Trust ALL the certificates, enable if required
            //ServicePointManager.ServerCertificateValidationCallback += (s, ce, ch, ssl) => true;
            
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(url);

            var urls = new List<string>();

            // Iterate through the top level nodes and find the "urlset" node. 
            foreach (XmlNode topNode in xmlDoc.ChildNodes)
            {
                if (topNode.Name.ToLower() == "urlset")
                {
                    // Use the Namespace Manager, so that we can fetch nodes using the namespace
                    var nsmgr = new XmlNamespaceManager(xmlDoc.NameTable);
                    nsmgr.AddNamespace("ns", topNode.NamespaceURI);

                    // Get all URL nodes and iterate through it.
                    XmlNodeList urlNodes = topNode.ChildNodes;
                    foreach (XmlNode urlNode in urlNodes)
                    {
                        // Get the "loc" node and retrieve the inner text.
                        XmlNode locNode = urlNode.SelectSingleNode("ns:loc", nsmgr);
                        string link = locNode != null ? locNode.InnerText : "";

                        // Add to our string builder.
                        urls.Add(link.Trim());
                    }
                }
            }

            return urls.Distinct();
        }

        private void Https(string url)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);

            //Header Settings
            req.Method = "POST"; // Post method
            req.ContentType = "text/xml";// content type
            req.KeepAlive = false;
            req.ProtocolVersion = HttpVersion.Version10;

            //Certificate with private key
            X509Certificate2 cert = new X509Certificate2("Cert.der", "Password");
            req.ClientCertificates.Add(cert);
            req.PreAuthenticate = true;

            String XML = "Test Message"; //reader.ReadToEnd();
            byte[] buffer = Encoding.ASCII.GetBytes(XML);
            req.ContentLength = buffer.Length;

            // Wrap the request stream with a text-based writer
            Stream writer = req.GetRequestStream();

            // Write the XML text into the stream
            writer.Write(buffer, 0, buffer.Length);

            writer.Close();

            WebResponse rsp = req.GetResponse();
            StreamReader responseStream = new StreamReader(rsp.GetResponseStream());
        }
    }
}
