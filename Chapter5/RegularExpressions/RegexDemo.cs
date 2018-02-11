using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RegularExpressions
{
    public static class RegexDemo
    {
        public static void ValidDate(string dateString)
        {
            string pattern = $@"^(19|20)\d\d[-./](0[1-9]|1[0-2]|[1-9])[-./](0[1-9]|[12][0-9]|3[01])$";
            if (Regex.IsMatch(dateString, pattern))
            {
                Console.WriteLine($"The string {dateString} contains a valid date.");
            }
            else
            {
                Console.WriteLine($"The string {dateString} DOES NOT contain a valid date.");
            }
        }

        public static string SanitizeINput(string input)
        {
            List<string> badList = new List<string>(new string[] { "BadWord1", "BadWord2", "BadWord3" });
            string pattern = "";
            foreach (string badWord in badList)
            {
                pattern += pattern.Length == 0 ? badWord : $"|{badWord}";
            }
            pattern = $@"\b({pattern})\b";
            return Regex.Replace(input, pattern, "*****", RegexOptions.IgnoreCase);
        }
    }
}
