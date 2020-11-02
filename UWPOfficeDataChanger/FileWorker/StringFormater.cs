using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPOfficeDataChanger
{
    public static class StringFormater
    {
        public static string ToFormatString(this DateTime dateTime)
        {
            string formatTime = string.Format("{0:yyyy-MM-ddTH:mm:ssZ}", dateTime);
            return formatTime;
        }

        public static DateTime InvertFormat(this string dt)
        {
            string year = dt.Substring(0, dt.IndexOf('-'));
            string month = dt.Substring(dt.IndexOf('-') + 1, dt.LastIndexOf('-') - dt.IndexOf('-') - 1);
            string day = dt.Substring(dt.LastIndexOf('-') + 1, dt.IndexOf('T') - dt.LastIndexOf('-') - 1);
            string hour = dt.Substring(dt.IndexOf('T') + 1, dt.IndexOf(':') - dt.IndexOf('T') - 1);
            string minute = dt.Substring(dt.IndexOf(':') + 1, dt.LastIndexOf(':') - dt.IndexOf(':') - 1);
            string second = dt.Substring(dt.LastIndexOf(':') + 1, dt.IndexOf('Z') - dt.LastIndexOf(':') - 1);
            DateTime dateTime = new DateTime(Int32.Parse(year), Int32.Parse(month), Int32.Parse(day), Int32.Parse(hour), Int32.Parse(minute), Int32.Parse(second));
            return dateTime;
        }
    }
}
