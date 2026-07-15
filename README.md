### AvionWorx [Gna.Iata](https://www.nuget.org/packages/Gna.Iata) code examples

### IATA ssim parse read write Quick Start
 ```csharp
            using Gna.Iata;

            // Create Ssim reader
            var ssimReader = SsimReader.Create();

            // Read
            var legs = ssimReader.ReadFromFile("sample.ssim");

            // Create Ssim writer, with LocalTime output
            var ssimWriter = SsimWriter.Create(legs, new SsimWriterOptions() { LocalTime = true });

            var newFileName = System.IO.Path.GetRandomFileName() + ".ssim";

            // Save
            ssimWriter.SaveToFile(newFileName);
```

### Code examples:

* #### [Synchronous read & write](https://github.com/Avionworx/Gna.Iata/blob/master/Example01_FileSynchronousReadWriteExample.cs)

* #### [Asynchronous read & write from/to ZIP file](https://github.com/Avionworx/Gna.Iata/blob/master/Example02_ZipFileAsynchronousReadWriteExample.cs)

* #### [Reading non compliant IATA legs](https://github.com/Avionworx/Gna.Iata/blob/master/Example03_ReadIATANonCompliantExample.cs)

--

# SSIM Reader and Writer I/O Methods
 
The library can read/write SSIM data from/to:

- a file
- a string
- a stream 

Most reader/writer methods have both synchronous and asynchronous variants. 
Most reader/writer methods supports uncompressed and compressed (zip,gzip) variants.

# SSIM Reader Options

Options used by `SsimReaderOptions` when reading SSIM data.

- **DisrespectLocalTimes** – If `true`, local time information from the SSIM input is ignored.  
  The reader will not populate local-time related flight leg properties such as `STDLocal`, `STALocal`, `STDLocalDiff`, `STALocalDiff`, `PSTDLocal`, or `PSTALocal`.

- **IgnoreSegmentData** – If `true`, segment data is not processed from the input.  
  This includes SSIM Segment Records / Record Type 4 data.

- **SuppressSsimErrors** – If `true`, SSIM reading and parsing errors are suppressed and stored in `SsimErrors` instead of throwing exceptions.  
  **Warning:** Using this option may allow parsing to continue after invalid input, but the resulting data may be incomplete or incorrect.

- **SkipValidation** – If `true`, flight legs are read without enforcing IATA compliance validation.  
  **Warning:** Using this option may allow invalid or non-compliant data to be loaded.

# SSIM Writer Options

Options used by `SsimWriterOptions` when writing SSIM data.

- **LocalTime** – If `true`, the writer outputs SSIM data in local time mode.  
  If `false`, the writer outputs data in UTC mode.  
  When using local time mode, make sure local time information is available on the flight legs, such as `STDLocal` / `STALocal`, or `STDLocalDiff` / `STALocalDiff`.

- **SkipTimezoneDifferences** – If `true`, UTC/local time differences are not written to the SSIM output.  
  This affects properties such as `STDLocalDiff` and `STALocalDiff`.

- **IgnoreDuplicates** – If `true`, duplicate flight legs are ignored instead of causing an exception.  
  **Warning:** Using this option may cause data loss or produce incomplete output.

- **SkipValidation** – If `true`, flight leg data is written without enforcing IATA compliance validation.  
  **Warning:** Using this option may produce invalid or non-compliant SSIM output.

- **BypassFrequencyRate** – If `true`, the weekly frequency rate is not used when generating the SSIM output.

- **WithDateVariation** – If `true`, optional date variation information is included in the SSIM output.

- **WithoutSegmentData** – If `true`, segment data is ignored and not written to the SSIM output.  
  **Warning:** Using this option may cause segment-level data loss.
---
