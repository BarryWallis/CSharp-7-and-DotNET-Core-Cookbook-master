using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceTheFinalFrontier
{
    public class NasaShuttle : Shuttle
    {
        public NasaShuttle(double engineThrust, double totalShuttleMass, double gravitationalAcceleration)
        {

        }

        public NasaShuttle(double engineThrust, double totalShuttleMass, double planetMass, double planetRadius)
        {

        }

        public override double TWR() => throw new NotImplementedException();
    }
}
