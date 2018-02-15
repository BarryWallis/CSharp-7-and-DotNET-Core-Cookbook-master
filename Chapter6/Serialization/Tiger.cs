using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Serialization
{
    [Serializable]
    public class Tiger : Cat
    {
        private string trainer;
        private bool isTamed;

        public string Trainer { get => trainer; set => trainer = value; }
        public bool IsTamed { get => isTamed; set => isTamed = value; }

        public static Stream Serialize()
        {
            Tiger tiger = new Tiger
            {
                Age = 12,
                IsTamed = false,
                Trainer = "Joe Soap",
                Weight = 120
            };

            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, tiger);
            stream.Position = 0;
            return stream;
        }

        public static void Deserialize(Stream stream)
        {
            stream.Position = 0;
            BinaryFormatter formatter = new BinaryFormatter();
            Tiger tiger = formatter.Deserialize(stream) as Tiger;
            Debug.Assert(tiger != null);
        }
    }
}
