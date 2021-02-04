using System;
using System.Collections.Generic;
using System.Text;

namespace Hefesto.Response
{
    public class ResponseGenericModel
    {
        public string status { get; set; }
        public string subject { get; set; }
        public string message { get; set; }
        public int httpCode { get; set; }
        public string urlRedirect { get; set; }
        public bool? reload { get; set; }
        public object data { get; set; }
    }

    public static class StatusResponseCodes
    {
        public const string
            StatusResponseSuccess = "success",
            StatusResponseError = "error",
            StatusResponseWarn = "warn";
    }
}
