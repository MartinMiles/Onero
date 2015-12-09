namespace Onero.Crawler.Results
{
    public class PageResult
    {
        public PageResult(int number, string url, long milliseconds)
        {
            PageNumber = number;
            URL = url;
            MillisecondsForLoad = milliseconds;
        }

        public int PageNumber { get; private set; }

        public string URL { get; private set; }

        public long MillisecondsForLoad { get; private set; }

        public override string ToString()
        {
            return string.Format("{0}. {1} loaded in {2}", PageNumber, URL, MillisecondsForLoad);
        }
    }
}
