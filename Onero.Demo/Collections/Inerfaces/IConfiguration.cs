namespace Onero.Demo.Collections.Inerfaces
{
    public interface IConfiguration
    {
        string LicensesFilePath { get; }
        string FeedbacksFilePath { get; }
        string ErrorsFilePath { get; }
    }
}