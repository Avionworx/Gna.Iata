namespace Gna.Example
{
    internal static partial class Program
    { 
        static async Task Main(string[] _)
        {

            Console.WriteLine("Which example to run? (enter nbr and press [Enter] key)");
            Console.WriteLine("[1] Synchronously reading and writing to/from SSIM file");
            Console.WriteLine("[2] Asynchronously reading and writing to/from compressed SSIM file");

            var nbr = Console.ReadLine();

            if (int.TryParse(nbr, out var choice))
            {
                switch (choice)
                {
                    case 1:
                        FileSynchronousReadWriteExample();
                        break;
                    case 2:
                        await ZipFileAsynchronousReadWriteExample();
                        break;
                }
            }
        }
    }
}
