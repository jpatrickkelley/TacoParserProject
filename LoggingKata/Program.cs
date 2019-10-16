using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            logger.LogInfo("Log initialized");

            var lines = File.ReadAllLines(@"C:\Users\jpatr\source\repos\TacoParser\LoggingKata\TacoBell-US-AL.csv");

            if (lines.Length == 0)
            {
                logger.LogError(" Empty file");
            }
            if (lines.Length == 1)
            {
                logger.LogWarning("Warning 1 line only");
            }
            logger.LogInfo($"Lines: {lines[0]}");

            var parser = new TacoParser();

            var locations = lines.Select(parser.Parse).ToArray();

            ITrackable TB1 = null;
            ITrackable TB2 = null;
            double distance = 0;

            var CorA = new GeoCoordinate();
            var CorB = new GeoCoordinate();

            for (int i = 0; i < locations.Length; i++)
            {
                
                CorA.Latitude = locations[i].Location.Latitude;
                CorA.Longitude = locations[i].Location.Longitude;

                for (int j = 0; j < locations.Length; j++)
                {
                    
                    CorB.Latitude = locations[j].Location.Latitude;
                    CorB.Longitude = locations[j].Location.Longitude;
                    double newDistance = CorA.GetDistanceTo(CorB);
                    if (newDistance > distance)
                    {

                        TB1 = locations[i];
                        TB2 = locations[j];
                        distance = newDistance;

                    }
                }
            }
            Console.WriteLine($"{TB1.Name}, {TB2.Name}");
            Console.ReadLine();


            // TODO:  Find the two Taco Bells in Alabama that are the furthest from one another.
            // HINT:  You'll need two nested forloops for this part
        }
    }
}