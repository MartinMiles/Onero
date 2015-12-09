using System.Collections.Generic;

namespace Onero
{
    public class JsonResponse
    {
        public int statusCode { get; set; }
        public JsonItemResult result { get; set; }
        public JsonError error { get; set; }
    }

    public class JsonItemResult
    {
        public int totalCount { get; set; }
        public int resultCount { get; set; }
        public IEnumerable<JsonItem> items { get; set; }
    }

    public class JsonItem
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string Url { get; set; }
        public IDictionary<string, JsonField> Fields { get; set; }

        public string GetUrl()
        {
            return string.Format("/?sc_itemid={0}", ID);
        }
        public override string ToString()
        {
            return Path;
        }
    }

    public class JsonField
    {
        public string Name { get; set; }
        public string Value { get; set; }

        public override string ToString()
        {
            return string.Format("{0}: {1}", Name, Value);
        }
    }

    public class JsonError
    {
        public string Message { get; set; }

        public override string ToString()
        {
            return Message;
        }
    }
}
