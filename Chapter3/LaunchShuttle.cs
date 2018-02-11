using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceTheFinalFrontier
{
    public class LaunchShuttle
    {
        private double engineThrust;
        private double totalShuttleMass;
        private double localGravitationalAcceleration;

        private const double earthGravity = 9.81;
        private const double moonGravity = 1.63;
        private const double marsGravity = 3.75;
        private double universalGravitationalConstant;

        public enum Planet {  Earth, Moon, Mars }

        public LaunchShuttle(double engineThrust, double totalShuttleMass, double gravitationalAcceleration)
        {
            this.engineThrust = engineThrust;
            this.totalShuttleMass = totalShuttleMass;
            this.localGravitationalAcceleration = gravitationalAcceleration;
        }

        public LaunchShuttle(double engineThrust, double totalShuttleMass, Planet planet)
        {
            this.engineThrust = engineThrust;
            this.totalShuttleMass = totalShuttleMass;
            SetGravitationalAcceleration(planet);
        }

        public LaunchShuttle(double engineThrust, double totalShuttleMass, double planetMass, double planetRadius)
        {
            this.engineThrust = engineThrust;
            this.totalShuttleMass = totalShuttleMass;
            SetUniversalGravitationalConstant();
            this.localGravitationalAcceleration = Math.Round(CalculateGravitationalAcceleration(planetRadius, planetMass), 2);
        }

        public double TWR() => Math.Round(CalculateThrustToWeightRatio(), 2);

        // TWR = Ft/m.g > 1 
        private double CalculateThrustToWeightRatio() => engineThrust / (totalShuttleMass * localGravitationalAcceleration);

        private double CalculateGravitationalAcceleration(double planetRadius, double planetMass) => (universalGravitationalConstant * planetMass) / Math.Pow(planetRadius, 2);

        private void SetUniversalGravitationalConstant() => universalGravitationalConstant = 6.6726 * Math.Pow(10, -11);

        private void SetGravitationalAcceleration(Planet planet)
        {
            switch (planet)
            {
                case Planet.Earth:
                    localGravitationalAcceleration = earthGravity;
                    break;
                case Planet.Moon:
                    localGravitationalAcceleration = moonGravity;
                    break;
                case Planet.Mars:
                    localGravitationalAcceleration = marsGravity;
                    break;
                default:
                    Debug.Fail($"Unexpected planet: {planet.ToString()}");
                    break;
            }
        }
    }
}
