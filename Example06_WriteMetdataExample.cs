using Gna.Iata;
using Gna.Iata.Ssim;

namespace Gna.Example
{
    static partial class Program
    { 
        static void SetLocalDiff(IFlightLeg leg, int diff)
        {
            leg.STDLocalDiff = diff;
            leg.STDLocal = leg.STD + TimeSpan.FromMinutes(diff);
            leg.STALocalDiff = diff;
            leg.STALocal = leg.STA + TimeSpan.FromMinutes(diff);

        }

        const string airlineCode = "AWX";
        const string from = "POZ";
        const string to = "MMX"; 

        static IEnumerable<IFlightLeg> CreateDummyFlights(Gna.Iata.Season season, int legsToCreate)
        { 
            for (var i = 0; i < legsToCreate; i++)
            {
                FlightLeg legA = new();
                legA.FlightDate = season.From.AddDays(i);
                legA.DepAirportCode = from;
                legA.ArrAirportCode = to;
                legA.AirlineCode = airlineCode;
                legA.FlightNumber = 1234;
                legA.AcTypeCode = "321";
                legA.AcVersion = "AWX180Y";
                legA.AcConfiguration = "Y180";
                legA.STD = legA.FlightDate.Value.AddHours(10);
                legA.STA = legA.STD.Value.AddHours(1);
                SetLocalDiff(legA, 60);
                yield return legA;

                FlightLeg legB = new();
                legB.FlightDate = legA.FlightDate;
                legB.DepAirportCode = to;
                legB.ArrAirportCode = from;
                legB.AirlineCode = airlineCode;
                legB.FlightNumber = 4321;
                legB.AcTypeCode = "321";
                legB.AcConfiguration = "Y180";
                legB.AcVersion = "AWX180Y";
                legB.STD = legB.FlightDate.Value.AddHours(14);
                legB.STA = legB.STD.Value.AddHours(1);
                SetLocalDiff(legB, 60);
                yield return legB;
            }
        }

        private static void Example06_WriteMetdataExample()
        {
            var ssimReader = SsimReader.Create();

            var season = Gna.Iata.Season.Now();
            
            //Create some legs
            IFlightLeg[] legs = CreateDummyFlights(season, 10).ToArray();

            //Create Ssim writer 
            var ssimWriter = SsimWriter.Create(legs); 

            // Customize carrier record
            if (ssimWriter.CarrierRecords.TryCreate(season, airlineCode, out var carrierRecord))
            {
                carrierRecord.GeneralInfo = ".NET Example";
                carrierRecord.CreatorReference = "ABV";
                carrierRecord.ReleaseDate = DateTime.UtcNow;
                carrierRecord.CreationDate = DateTime.UtcNow;
                carrierRecord.TitleOfData = "Sample MMX<->POZ flights";
            }

            // Synchronous save to plain file
            var newFileName = $"{season.Name}_{from}_{to}.ssim";
            ssimWriter.SaveToFile(newFileName);
             

            Console.WriteLine($"File {newFileName} created");
        }
    }
}
