using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XMLSerializableApp
{
    [XmlRoot(ElementName = "FundamentalsOfProgramming", Namespace = "http://serialization")]
    public class FundamentalProgramming
    {
        [XmlElement(ElementName = "LecturerFullname", DataType = "string")]
        public string Lecturer { get; set; }

        [XmlIgnore]
        public double ClassAverage { get; set; }

        [XmlAttribute]
        public string RoomNumber { get; set; }

        [XmlArray(ElementName = "StudentsInClass", Namespace = "http://serialization")]
        public List<Student> Students { get; } = new List<Student>();

    }
}
