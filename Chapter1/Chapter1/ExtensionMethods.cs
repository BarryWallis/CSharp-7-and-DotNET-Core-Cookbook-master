using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter1
{
    public static class ExtensionMethods
    {
        public static bool CheckIfBelowAverage(this double classAverage, int threshold) => classAverage < threshold;

        public static (string originalValue, int integerValue, bool isInteger) ToInt(this string stringValue)
        {
            bool isInteger = int.TryParse(stringValue, out int integerValue);
            return (stringValue, integerValue, isInteger);
        }

        public static void Deconstruct(this Student student, out string name, out string lastName)
        {
            name = student.Name;
            lastName = student.LastName;
        }

        //#region Ref returns and locals
        //public static int GetLargest(int a, int b) => a > b ? a : b;

        //public static ref int GetLargest(ref int a, ref int b)
        //{
        //    if (a > b)
        //        return ref a;
        //    else
        //        return ref b;
        //}
        //#endregion

        #region Throw Expressions
        public static int GetNameLength(string firstName, string lastName)
            => firstName.Length + lastName.Length > 0 ? firstName.Length + lastName.Length : throw new Exception("First and last names are empty");
        #endregion
    }
}
