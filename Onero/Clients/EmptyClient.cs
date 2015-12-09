using System;
using System.Collections.Generic;

namespace Onero
{
    public class EmptyClient : IParseable
    {
        private IEnumerable<string> links; 

        public EmptyClient(string textboxExistingContent)
        {
           links = textboxExistingContent.Trim().Split('\n');
        }

        public IEnumerable<string> Parse()
        {
            return links;
        }
    }
}
