using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace JsonSerializableApp
{
    public class FundamentalProgramming
    {
        public string Lecturer { get; set; }
        public double ClassAverage { get; set; }
        public string RoomNumber { get; set; }
        public List<Student> Students { get; } = new List<Student>();

    }
}
