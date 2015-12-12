namespace Onero.Loader.Results
{
    public enum ResultCode
    {
        Successfull = 200,
        NoJquery,
        RuleFailed,
        RuleParseError,
        ElementNotFound,
        RedirectUrlMismatch,
        Timeout,
        FormResultUrlMissmatch,
        PageFailed = 500,
        PageFailedFromTimeout,
        NotFinished
    }
}
