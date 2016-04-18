using System.ComponentModel;

namespace Onero.Loader.Results
{
    public enum ResultCode
    {
        Successful = 200,
        NoJquery,
        RuleFailed,
        RuleParseError,
        ElementNotFound,
        RedirectUrlMismatch,
        Timeout,

        [Description("Form result URL mismatch")]
        FormResultUrlMissmatch,
        [Description("Unknown error in form execution")]
        FormFailed,


        [Description("Form returns the result other than expected")]
        FormReturnsNotExpectedResult,

        PageFailed = 500,
        PageFailedFromTimeout,
        NotFinished
    }
}
