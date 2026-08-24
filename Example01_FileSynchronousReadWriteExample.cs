using Gna.Iata.Ssim;

namespace Gna.Example
{
    static partial class Program
    {
        private static void FileSynchronousReadWriteExample()
        {
            // Create Ssim reader
            var ssimReader = SsimReader.Create();

            // Synchronously read from plain file
            var legs = ssimReader.ReadFromFile("sample.ssim");

            //Create Ssim writer, with LocalTime output
            var ssimWriter = SsimWriter.Create(legs, new SsimWriterOptions() { LocalTime = true });

            // Following properties will be copied to carrier records
            // (unless carrier record are created manually - see WriteMetdataExample)
            ssimWriter.TitleOfData = ".NET Test";
            ssimWriter.GeneralInfo = "Testing Gna.Iata";
            ssimWriter.CreationDate = DateTime.UtcNow.AddDays(365);

            var newFileName = System.IO.Path.GetRandomFileName() + ".ssim";

            // Synchronous save to plain file
            ssimWriter.SaveToFile(newFileName);

            Console.WriteLine($"File {newFileName} created");
        }
    }
}
