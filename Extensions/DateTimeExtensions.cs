using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions
{
    public static class DateTimeExtensions
    {
        public static string ConvertByExpectedDateFormat(this DateTime date) =>
            date.ToString(ConfigorationValues.ExpectedDateFormat);
    }
}
