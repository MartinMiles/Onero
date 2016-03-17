using System.ComponentModel;

namespace Onero.Loader
{
    public enum Browser
    {
        [Description("Don't display browser")]
        BrowserHidden = 1,

        [Description("Internet Explorer")]
        IE,

        Edge,

        Firefox,

        Chrome,

        Opera
    }
}
