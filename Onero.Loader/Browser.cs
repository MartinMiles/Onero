using System.ComponentModel;

namespace Onero.Loader
{
    public enum Browser
    {
        [Description("Don't display browser")]
        BrowserHidden = 1,

        [Description("Run in Firefox")]
        Firefox,

        Chrome,

        Opera
    }
}
