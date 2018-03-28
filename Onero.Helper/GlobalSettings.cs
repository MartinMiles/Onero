namespace Onero.Helper
{
    public static class GlobalSettings
    {
        #region Hostname

#if DEBUG
        private const string WebServiceHostName = "demo.onero.net";
#else
        private const string WebServiceHostName = "onero.net";
#endif
        public static string ServerBase => $"http://{WebServiceHostName}";

        #endregion

        public const string LogFileName = "_errorLog.txt";
    }
}
