using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter1
{
    public class Student
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public List<int> CourseCodes { get; }

        public Student(string studentNumber) => (Name, LastName) = GetStudentDetails(studentNumber);

        public void Deconstruct(out string name, out string lastName)
        {
            name = Name;
            lastName = LastName;
        }

        private static (string name, string lastName) GetStudentDetails(string studentNumber) => ("Dirk", "Strauss");
    }
}
