using System;

namespace Onero.Loader.Results
{
    public class DataExtractResult
    {
        #region Public properies

        public DataExtractItem DataExtractItem { get; private set; }
        public ResultCode ResultCode { get; private set; }
        public string UrlTaken { get; private set; }
        public string Value { get; private set; }

        #endregion

        #region Properties

        public DataExtractResult()
        {

        }

        public DataExtractResult(DataExtractItem dataExtractItem, string urlTaken, ResultCode resultCode, string value)
        {
            DataExtractItem = dataExtractItem;
            ResultCode = resultCode;
            UrlTaken = urlTaken;
            Value = value;
        }

        public DataExtractResult(ResultCode resultCode)
        {
            if (resultCode == ResultCode.Successful)
            {
                throw new ArgumentException(
                    "Constructor with one parameter supposed to take an error code, not Successful value");
            }

            ResultCode = resultCode;
        }

        #endregion
    }
}
