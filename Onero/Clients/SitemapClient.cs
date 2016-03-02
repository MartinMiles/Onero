using System.Collections.Generic;
using System.Linq;
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
            var rssXmlDoc = new XmlDocument();

            rssXmlDoc.Load(url);

            var urls = new List<string>();

            // Iterate through the top level nodes and find the "urlset" node. 
            foreach (XmlNode topNode in rssXmlDoc.ChildNodes)
            {
                if (topNode.Name.ToLower() == "urlset")
                {
                    // Use the Namespace Manager, so that we can fetch nodes using the namespace
                    var nsmgr = new XmlNamespaceManager(rssXmlDoc.NameTable);
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
    }
}
