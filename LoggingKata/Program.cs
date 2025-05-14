using System.Linq;
using System.IO;
using GeoCoordinatePortable;
using System;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            // Get data
            var lines = File.ReadAllLines(csvPath);

            // Throw errors if data is missing/wrong
            if (lines.Length == 0) { logger.LogError("No Data In Data Set"); }
            else if (lines.Length == 1) { logger.LogWarning("Limited Data In Data Set"); }

            // Show first Line
            //logger.LogInfo($"Lines: {lines[0]}");

            // Prepair data && Initilize Values
            var parser = new TacoParser();
            var locations = lines.Select(parser.Parse).ToArray();
            ITrackable store1 = null;
            ITrackable store2 = null;
            double distanceMeters = 0;

            // Go through every store && get coordinates
            foreach (ITrackable locA in locations) {
                var coodA = new GeoCoordinate(locA.Location.Latitude, locA.Location.Longitude);
                // Go through every store again && get coordinates
                foreach (ITrackable locB in locations) {
                    var coodB = new GeoCoordinate(locB.Location.Latitude, locB.Location.Longitude);
                    // check distance and update values as needed
                    double ABDistance = coodA.GetDistanceTo(coodB);
                    if (ABDistance > distanceMeters) {
                        distanceMeters = ABDistance;
                        store1 = locA;
                        store2 = locB;
                    }

                }
            }

            // Display data
            double distanceMiles = distanceMeters / 1609.344;;
            Console.WriteLine($"Location {store1.Name} located at {store1.Location.Latitude:F3} x {store1.Location.Longitude:F3}");
            Console.WriteLine($"and {store2.Name} located at {store2.Location.Latitude:F3} x {store2.Location.Longitude:F3}");
            Console.WriteLine($"Are the two furthest TacoBells from each other being {distanceMiles:F2} miles away from each other");

            Console.ReadLine();
        }
    }
}
