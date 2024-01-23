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

            var newFileName = System.IO.Path.GetRandomFileName() + ".ssim";

            // Synchronous save to plain file
            ssimWriter.SaveToFile(newFileName);

            Console.WriteLine($"File {newFileName} created");
        }
    }
}
