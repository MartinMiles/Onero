using System;

namespace Onero.Helper.ErrorHandling
{
    public class ReportableError
    {
        public string Comment { get; set; }
        public string Type { get; set; }
        public string CallStack { get; set; }
        public string ExceptionMessage { get; set; }
        public string InnerType { get; set; }
        public string InnerCallStack { get; set; }
        public string InnerExceptionMessage { get; set; }
        public DateTime Created { get; set; }
        public string MachineId { get; set; }
        public string SerialNumber { get; set; }
        public string OS { get; set; }
    }
}
