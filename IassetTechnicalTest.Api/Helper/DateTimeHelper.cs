using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IassetTechnicalTest.Api.Helper
{
    public static class DateTimeHelper
    {
        public static string UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            var dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime.ToShortTimeString();
        }

    }
}