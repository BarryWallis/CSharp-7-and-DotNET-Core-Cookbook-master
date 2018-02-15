using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ISerializableApp
{
    [Serializable]
    public class Vehicle : ISerializable
    {
        public enum VehicleTypes { None = 0, Car = 1, SUV = 2, Utility = 3 }

        public int VehicleType { get; set; }
        public int EngineCapacity { get; set; }
        public int TopSpeed { get; set; }

        public Vehicle()
        {

        }

        protected Vehicle(SerializationInfo info, StreamingContext context)
        {
            VehicleType = info.GetInt32(nameof(VehicleType));
            EngineCapacity = info.GetInt32(nameof(EngineCapacity));
            TopSpeed = info.GetInt32(nameof(TopSpeed));
        }

        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(VehicleType), VehicleType);
            info.AddValue(nameof(EngineCapacity), EngineCapacity);
            info.AddValue(nameof(TopSpeed), TopSpeed);
        }
    }
}
