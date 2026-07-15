using Gna.Iata;
using Gna.Iata.Ssim;

namespace Gna.Example
{
    static partial class Program
    {
        static string SeasonDetails(Season season) => $"{season.Name} {season.From:ddMMMyyyy} - {season.To:ddMMMyyyy}";

        private static void Example04_IataSeasonExample()
        {
            var now = Gna.Iata.Season.Now();

            Console.WriteLine($"Previous IATA season {SeasonDetails(now.Previous())}");
            Console.WriteLine($"Current IATA season {SeasonDetails(now)}");
            Console.WriteLine($"Next IATA season {SeasonDetails(now.Next())}");
        }
    }
}
