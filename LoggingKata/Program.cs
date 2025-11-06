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
            
            //string[] lines = File.ReadAllLines(csvPath);
            //added inline data below
            
            string[] lines = new string[]
            {
                "34.035985, -84.683302, Taco Bell Acworth...",
                "34.087508,-84.575512,Taco Bell Acworth...\n",
                "34.376395,-84.913185,Taco Bell Adairsvill...",
                "31.570771,-84.10353,Taco Bell Albany...\n",
                "34.280205,-86.217115,Taco Bell Albertvill...\n",
                "30.731386,-86.566652,Taco Bell Crestvie...\n"
            };
            //end of added inline data

            logger.LogInfo($"Lines: {lines[0]}");
            if (lines.Length == 0)
            {
                logger.LogError("No lines found");
            }

            if (lines.Length == 1)
            {
                logger.LogWarning("Only one line found");
            }

           
            var parser = new TacoParser();          

            var locations = lines.Select(line => parser.Parse(line)).ToArray();
            
            ITrackable[] tacoBells = new ITrackable[2];
            ITrackable firstTacoBell = null;
            ITrackable secondTacoBell = null;
            double distance = 0;

            for (int i = 0; i < locations.Length; i++)
            {
                var locA = locations[i];
                var corA = new GeoCoordinate();
                corA.Latitude = locA.Location.Latitude;
                corA.Longitude = locA.Location.Longitude;

                for (int j = 0; j < locations.Length; j++)
                {
                    var locB = locations[j];
                    var corB = new GeoCoordinate();
                    corB.Latitude = locB.Location.Latitude;
                    corB.Longitude = locB.Location.Longitude;

                    if (corA.GetDistanceTo(corB) > distance)
                    {
                        distance = corA.GetDistanceTo(corB);
                        firstTacoBell = locA;
                        secondTacoBell = locB;
                    }
                }
            }

            logger.LogInfo($"{firstTacoBell.Name} and {secondTacoBell.Name} are the farthest apart.");
            
                }
            }
        }
    

