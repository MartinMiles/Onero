using Onero.Loader.Forms;

namespace Onero.Loader
{
    public class WebFormField
    {
        #region Properies

        public string Id { get; set; }

        public FieldType Type { get; set; }

        public string Value { get; set; }

        #endregion

        #region Constructors

        public WebFormField(string id, string value)
        {
            Id = id;
            Type = FieldType.SendText;
            Value = value;
        }

        public WebFormField(string id, FieldType type, string value)
        {
            Id = id;
            Type = type;
            Value = value;
        }

        #endregion

        public override string ToString()
        {
            return $"[{Type}] id: {Id} Value: {Value}";
        }
    }
}
