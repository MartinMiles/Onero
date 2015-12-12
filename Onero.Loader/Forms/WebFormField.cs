namespace Onero.Loader
{
    public class WebFormField
    {
        public string Id { get; set; }
        public string Value { get; set; }

        public WebFormField(string id, string value)
        {
            Id = id;
            Value = value;
        }

        public override string ToString()
        {
            return string.Format("id: {0} Value: {1}", Id, Value);
        }
    }
}
