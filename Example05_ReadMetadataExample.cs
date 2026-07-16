using Gna.Iata.Ssim;

namespace Gna.Example
{
    static partial class Program
    {
        private static void Example05_ReadMetadataExample()
        {
            // Create Ssim reader
            var ssimReader = SsimReader.Create();

            // Synchronously read file to the end
            _ = ssimReader.ReadFromFile("sample.ssim").ToArray();

            if (ssimReader.HeaderRecord.NumberOfSeasons.HasValue)
                Console.WriteLine($"Number of seasons: {ssimReader.HeaderRecord.NumberOfSeasons}");

            // Printout each season/airline metadata from the file
            if (ssimReader?.CarrierRecords?.Count > 0)
                for(var c=0;c<ssimReader.CarrierRecords.Count;c++) 
                {
                    var carrierRecord = ssimReader.CarrierRecords[c];
                    Console.WriteLine(c);
                    Console.WriteLine($"Season: {carrierRecord.Season.Name}");
                    Console.WriteLine($"Airline: {carrierRecord.AirlineCode}");
                    Console.WriteLine("TimeMode: " + (carrierRecord.LocalTimeMode ? "Local" : "UTC"));
                    if (!string.IsNullOrEmpty(carrierRecord.ElectronicTicketingInformation))
                        Console.WriteLine($"Electronic Ticketing: {carrierRecord.ElectronicTicketingInformation}");
                    if (!string.IsNullOrEmpty(carrierRecord.GeneralInfo))
                        Console.WriteLine($"General Info: {carrierRecord.GeneralInfo}");
                    if (!string.IsNullOrEmpty(carrierRecord.CreatorReference))
                        Console.WriteLine($"General Info: {carrierRecord.CreatorReference}");
                    if (!string.IsNullOrEmpty(carrierRecord.InFLightServiceInformationDefaults))
                        Console.WriteLine($"In-flight Service Defaults: {carrierRecord.InFLightServiceInformationDefaults}");
                    if (carrierRecord.AutomatedCheckIn.HasValue)
                        Console.WriteLine("AutomatedCheckIn: " + (carrierRecord.AutomatedCheckIn.Value ? "Yes" : "No"));
                    if (carrierRecord.CreationDate.HasValue)
                        Console.WriteLine($"CreationDate: {carrierRecord.CreationDate:ddMMMyyyy}");
                    if (carrierRecord.ReleaseDate.HasValue)
                        Console.WriteLine($"ReleaseDate: {carrierRecord.ReleaseDate:ddMMMyyyy}");
                    if (carrierRecord.ScheduleStatusConfirmed.HasValue)
                        Console.WriteLine("ScheduleConfirmed: " + (carrierRecord.ScheduleStatusConfirmed.Value ? "Yes" : "No"));
                    if (carrierRecord.SecureFlightIndicator.HasValue)
                        Console.WriteLine("Secured flight: " + (carrierRecord.SecureFlightIndicator.Value ? "Yes" : "No"));
                    if (!string.IsNullOrEmpty(carrierRecord.TitleOfData))
                        Console.WriteLine($"Title of data: {carrierRecord.TitleOfData}");
                    if (carrierRecord.ValidFrom.HasValue)
                        Console.WriteLine($"ValidFrom: {carrierRecord.ValidFrom:ddMMMyyyy}");
                    if (carrierRecord.ValidTo.HasValue)
                        Console.WriteLine($"ValidTo: {carrierRecord.ValidTo:ddMMMyyyy}");
                }
        }
    }
}
