using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RegularExpressions
{
    public static class CustomRegexHelper
    {
        public static bool ValidAcmeCompanyFilename(this string value) 
            => Regex.IsMatch(value, $@"^acm[_]{DateTime.Now.Year}[_]({DateTime.Now.Month}|0[{DateTime.Now.Month}])[_]({DateTime.Now.Day}|0[{DateTime.Now.Day}])(.txt|.docx|.xlsx)$");
    }
}
