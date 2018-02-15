using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XMLSerializableApp
{
    class Program
    {
        static void Main()
        {
            string serializationPath = @"C:\Users\barry\Source\Repos\CSharp-7-and-DotNET-Core-Cookbook-master\Chapter6\XMLSerializableApp\tempclassinfo.xml";
            Student studentA = new Student()
            {
                StudentName = "John Smith",
                SubjectMark = 86.4
            };

            Student studentB = new Student()
            {
                StudentName = "Jane Smith",
                SubjectMark = 67.3
            };

            List<Student> students = new List<Student>
            {
                studentA,
                studentB
            };

            FundamentalProgramming subject = new FundamentalProgramming
            {
                Lecturer = "Prof. Johan van Niekerk",
                RoomNumber = "Lecture Auditorium A121",
                ClassAverage = (students.Sum(mark => mark.SubjectMark) / students.Count())
            };
            subject.Students.AddRange(students);


            using (FileStream stream = new FileStream(serializationPath, FileMode.Create))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(FundamentalProgramming));
                xmlSerializer.Serialize(stream, subject);
            }

            using (FileStream stream = new FileStream(serializationPath, FileMode.Open))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(FundamentalProgramming));
                FundamentalProgramming fundamentalProgramming = xmlSerializer.Deserialize(stream) as FundamentalProgramming;
                Debug.Assert(fundamentalProgramming != null);
            }
        }
    }
}
