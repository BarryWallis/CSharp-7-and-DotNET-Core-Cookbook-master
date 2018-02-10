using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static Chapter1.ExtensionMethods;
using static System.Math;

namespace Chapter1
{
    class Program
    {
        static void Main()
        {
            #region Tuples
            //int[] scores = { 17, 46, 39, 62, 81, 79, 52, 24, 49 };
            //int threshold = 40;
            //(double average, int count, bool belowAverage) = GetAverageAndCount(scores, threshold);
            //WriteLine($"Average was {Round(average, 2)} across {count} students. Class score {(belowAverage ? "below" : "above")} average."); 
            #endregion

            #region Pattern Matching
            //Student student = new Student
            //{
            //    Name = "Dirk",
            //    LastName = "Strauss",
            //    CourseCodes = new List<int> { 203, 202, 101 }
            //};

            //OutputInformation(student);

            //Professor professor = new Professor
            //{
            //    Name = "Reinhardt",
            //    LastName = "Botha",
            //    TeachesSubjects = new List<string> { "Mobile Development", "Cryptography" }
            //};

            //OutputInformation(professor);

            //student = null;
            //OutputInformation(student);

            #endregion

            #region Out Variables
            //string stringValue = "500";
            //(string originalValue, int integerValue, bool isInteger) = stringValue.ToInt();
            //if (isInteger)
            //{
            //    WriteLine($"{integerValue} is a valid integer");
            //}
            //else
            //{
            //    WriteLine($"{stringValue} is not a valid integer");
            //}
            #endregion

            #region Deconstructor
            //Student student = new Student("12345");
            //var (firstName, surname) = student;
            //WriteLine($"The student name is {firstName} {surname}");
            #endregion

            #region Local Functions
            //Building building = GetShopFloorSpace(200, 35, 100);
            //WriteLine($"The total space for shops is {building.TotalFloorSpace} square meters.");
            #endregion

            #region Improvements to Literals
            //long oldNum = 342057239127493;
            //long newNum = 342_057_239_127_493;
            //WriteLine($"oldNum = {oldNum} and newNum = {newNum}");
            #endregion

            #region Ref returns and locals
            //int a = 10;
            //int b = 20;
            //int val = GetLargest(a, b);
            //val += 25;
            //WriteLine($"val = {val}; a = {a}; b = {b}");

            //ref int refVal = ref GetLargest(ref a, ref b);
            //refVal += 25;
            //WriteLine($"refVal = {refVal}; a = {a}; b = {b}");

            //unsafe
            //{
            //    IntPtr a_var_memoryAddress = (IntPtr)(&a);
            //    IntPtr b_var_memoryAddress = (IntPtr)(&b);
            //    IntPtr val_var_memoryAddress = (IntPtr)(&val);

            //    fixed (int* refVal_var = &refVal)
            //    {
            //        IntPtr refVal_var_memoryAddress = (IntPtr)(refVal_var);
            //        WriteLine($"The memory address of a is {a_var_memoryAddress}");
            //        WriteLine($"The memory address of b is {b_var_memoryAddress}");
            //        WriteLine($"The memory address of val is {val_var_memoryAddress}");
            //        WriteLine($"The memory address of refVal is { refVal_var_memoryAddress}");
            //    }
            //}
            #endregion

            #region Throw Expressions
            //try
            //{
            //    int nameLength = GetNameLength("", "");
            //}
            //catch (Exception exception)
            //{
            //    WriteLine(exception.Message);
            //}
            #endregion

            if (Debugger.IsAttached)
            {
                Write("Press any key to continue...");
                ReadKey();
            }

            #region Tuples
            //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
            //private static (double average, int count) GetAverageAndCount(int[] scores) => (average: (double)scores.Sum() / scores.Count(), count: scores.Count());

            //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
            //private static (double average, int count, bool belowAverage) GetAverageAndCount(int[] scores, int threshold)
            //    => (average: (double)scores.Sum() / scores.Count(), count: scores.Count(), belowAverage: ((double)scores.Sum() / scores.Count()).CheckIfBelowAverage(threshold));
            #endregion

            #region Pattern Matching
            //public static void OutputInformation(object person)
            //{
            //    switch (person)
            //    {
            //        case Student student when (student.CourseCodes.Contains(203)):
            //            WriteLine($"Student {student.Name} {student.LastName} is enrolled in course 203.");
            //            break;
            //        case Student student:
            //            WriteLine($"Student {student.Name} {student.LastName} is enrolled for courses {String.Join<int>(", ", student.CourseCodes)}.");
            //            break;
            //        case Professor professor:
            //            WriteLine($"Professor {professor.Name} {professor.LastName} teaches {String.Join<string>(", ", professor.TeachesSubjects)}.");
            //            break;
            //        case null:
            //            WriteLine($"Object {nameof(person)} is null.");
            //            break;
            //        default:
            //            WriteLine($"Unknown object detected.");
            //            break;
            //    }
            //}
            #endregion

            #region Local Functions
            //Building GetShopFloorSpace(int floorCommonArea, int buildingWidth, int buildingLength)
            //{
            //    Building newBuilding = new Building
            //    {
            //        TotalFloorSpace = CalculateShopFloorSpace(floorCommonArea, buildingWidth, buildingLength)
            //    };

            //    int CalculateShopFloorSpace(int commonArea, int width, int length) => width * length - commonArea;

            //    newBuilding.TotalFloorSpace = CalculateShopFloorSpace(10, 9, 17);
            //    return newBuilding;
            //}
            #endregion

        }
    }
}
