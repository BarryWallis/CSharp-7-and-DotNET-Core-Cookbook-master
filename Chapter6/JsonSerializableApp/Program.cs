using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JsonSerializableApp
{
    class Program
    {
        static void Main()
        {
            string serializationPath = @"C:\Users\barry\Source\Repos\CSharp-7-and-DotNET-Core-Cookbook-master\Chapter6\JsonSerializableApp\tempclassinfo.json";
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
            Console.WriteLine($"Calculated class average = {subject.ClassAverage}");


            JsonSerializer jsonSerializer = new JsonSerializer
            {
                Formatting = Formatting.Indented
            };
            StreamWriter streamWriter = new StreamWriter(serializationPath);
            using (JsonWriter jsonWriter = new JsonTextWriter(streamWriter))
            {
                jsonSerializer.Serialize(jsonWriter, subject);
            }
            Console.WriteLine($"Serialized to file using JSON Serializer");

            using (StreamReader streamReader2 = new StreamReader(serializationPath))
            {
                string jsonString = streamReader2.ReadToEnd();
                Console.WriteLine($"JSON String Read from file");
                JObject jObject = JObject.Parse(jsonString);
                IList<double> subjectMarks = jObject["Students"].Select(m => (double)m["SubjectMark"]).ToList();
                double average = subjectMarks.Sum() / subjectMarks.Count();
                Console.WriteLine($"Calculated class average using jObject = {average}");
            }

            StreamReader streamReader = new StreamReader(serializationPath);
            using (JsonReader jsonReader = new JsonTextReader(streamReader))
            {
                FundamentalProgramming fundamentalProgramming = jsonSerializer.Deserialize<FundamentalProgramming>(jsonReader);
            }

            if (Debugger.IsAttached)
            {
                Console.Write($"\nPress any key to continue...");
                Console.ReadKey();
            }
        }
    }
}