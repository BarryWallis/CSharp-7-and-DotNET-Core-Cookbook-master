using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ISerializableApp
{
    class Program
    {
        static void Main()
        {
            string serializationPath = @"C:\Users\barry\Source\Repos\CSharp-7-and-DotNET-Core-Cookbook-master\Chapter6\ISerializableApp\vehicleInfo.dat";
            Vehicle vehicle = new Vehicle
            {
                VehicleType = (int)Vehicle.VehicleTypes.Car,
                EngineCapacity = 1600,
                TopSpeed = 230
            };

            if (File.Exists(serializationPath))
            {
                File.Delete(serializationPath);
            }

            using (FileStream stream = new FileStream(serializationPath, FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, vehicle);
            }

            using (FileStream stream = new FileStream(serializationPath, FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                Vehicle deserializeVehicle = formatter.Deserialize(stream) as Vehicle;
                Debug.Assert(deserializeVehicle != null);
            }
        }
    }
}
