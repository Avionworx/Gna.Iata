using Gna.Iata;
using Gna.Iata.Ssim;

namespace Gna.Example
{ 
    internal class LegWithDuplicates : FlightLeg
    { 
        public readonly IList<FlightLeg> Duplicates = new List<FlightLeg>();
    }

    static partial class Program
    {
        const string fileName = "sample_with_duplicates.ssim";


        internal static void PrintOutResult(Dictionary<FlightLegIdentifier, LegWithDuplicates> legs)
        {
            int duplicatesCount = 0;

            foreach (var leg in legs)
            {
                Console.WriteLine($"Leg '{leg.Key.AirlineCode}{leg.Key.FlightNumber}{leg.Key.SuffixCode} {leg.Key.FlightDate?.ToString("ddMMMyy")?.ToUpper()} {leg.Key.DepAirportCode} [{leg.Value.Duplicates.Count} duplicate(s)]");
                duplicatesCount += leg.Value.Duplicates.Count;
            }

            Console.WriteLine($"File '{fileName} contains {duplicatesCount} duplicates.");
        }        

        private static void Example03_ReadIATANonCompilantExample()
        {
            // Create templated Ssim reader that accepts non compilant IATA schedule
            var ssimReader = SsimReader.Create<LegWithDuplicates>(new SsimReaderOptions() { SkipValidation = true });

            var legs = new Dictionary<FlightLegIdentifier, LegWithDuplicates>(); 

            // Iterate over legs to locate legs with duplicated flight leg identifier
            foreach (var leg in ssimReader.ReadFromFile(fileName))
            {
                var flightLegIdentifier = new FlightLegIdentifier(leg);
                if (legs.TryGetValue(flightLegIdentifier, out var existingLeg))
                    existingLeg.Duplicates.Add(leg);
                else
                    legs.Add(flightLegIdentifier, leg);
            }

            PrintOutResult(legs);
        }
    }
}
