using System.ComponentModel;

namespace Onero.Helper.Browsers
{
    public enum SupportedBrowser
    {
        [Description("Don't display browser")]
        BrowserHidden = 1,

        [Description("Internet Explorer")]
        [IgnoreBrowser]
        IE,

        [IgnoreBrowser]
        Edge,

        [IgnoreBrowser]
        Firefox,

        Chrome,

        [IgnoreBrowser]
        Opera
    }
}
