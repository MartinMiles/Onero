using System.ComponentModel;

namespace Onero.Loader.Forms
{
    public enum FieldType
    {
        [Description("Send text")]
        SendText = 1,

        [Description("Click item")]
        ClickItem,

        [Description("Send keys")]
        SendKeys,

        [Description("JavaScript")]
        JavaScript
    }
}
