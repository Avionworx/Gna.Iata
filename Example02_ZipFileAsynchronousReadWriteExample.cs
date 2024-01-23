using Gna.Iata;
using Gna.Iata.Ssim;

namespace Gna.Example
{
    static partial class Program
    {
        private static async Task ZipFileAsynchronousReadWriteExample()
        {
            // Create Ssim reader
            var ssimReader = SsimReader.Create();

            // Asynchronously read from compressed (zip) file
            var legsCollection = new List<IFlightLeg>();
            await foreach (var leg in ssimReader.ReadFromFileAsync("sample.zip"))
            {
                legsCollection.Add(leg);
            }

            //Create Ssim writer, with UTC output
            var ssimWriter = SsimWriter.Create(legsCollection);

            var newFileName = System.IO.Path.GetRandomFileName() + ".zip";

            // Asynchronous save to compressed file
            await ssimWriter.SaveToZipFileAsync(newFileName, "sample.ssim");

            Console.WriteLine($"File {newFileName} created");
        }
    }
}
