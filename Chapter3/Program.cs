using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceTheFinalFrontier
{
    class Program
    {
        static void Main(string[] args)
        {
            Spaceship transporter = new Spaceship();
            transporter.ConrtrolBridge();
            transporter.CrewQuarters(1500);
            transporter.EngineRoom(2);
            transporter.MedicalBay(350);
            transporter.TeleportationRoom();

            Destroyer warship = new Destroyer();
            warship.Armory(6);
            warship.ConrtrolBridge();
            warship.CrewQuarters(2200);
            warship.EngineRoom(4);
            warship.MedicalBay(800);
            warship.TeleportationRoom();
            warship.WarRoom();
            warship.WarSpecialists(1);

            Annihilator planetClassDestroyer = new Annihilator();
            planetClassDestroyer.Armory(12);
            planetClassDestroyer.ConrtrolBridge();
            planetClassDestroyer.CrewQuarters(4500);
            planetClassDestroyer.EngineRoom(7);
            planetClassDestroyer.MedicalBay(3500);
            planetClassDestroyer.PlanetDestructionCapability();
            planetClassDestroyer.TeleportationRoom();
            planetClassDestroyer.TractorBeam();
            planetClassDestroyer.WarRoom();
            planetClassDestroyer.WarSpecialists(3);

            double thrust = 220; // kN
            double shuttleMass = 16.12; // t
            double gravitationalAccelerationEarth = 9.81;
            double earthMass = 5.9742 * Math.Pow(10, 24);
            double earthRadius = 6378100;
            double thrustToWeightRatio = 0;

            LaunchShuttle nasaShuttle1 = new LaunchShuttle(thrust, shuttleMass, gravitationalAccelerationEarth);
            thrustToWeightRatio = nasaShuttle1.TWR();
            Console.WriteLine(thrustToWeightRatio);

            LaunchShuttle nasaShuttle2 = new LaunchShuttle(thrust, shuttleMass, LaunchShuttle.Planet.Earth);
            thrustToWeightRatio = nasaShuttle1.TWR();
            Console.WriteLine(thrustToWeightRatio);

            LaunchShuttle nasaShuttle3 = new LaunchShuttle(thrust, shuttleMass, earthMass, earthRadius);
            thrustToWeightRatio = nasaShuttle1.TWR();
            Console.WriteLine(thrustToWeightRatio);

            if (Debugger.IsAttached)
            {
                Console.Write($"\nPress any key to continue...");
                Console.ReadKey();
            }
        }
    }
}
