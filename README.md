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

# SSIM Reader Options

- **DisrespectLocalTimes** – If `true`, UTC-local time differences in the input are ignored.  

- **IgnoreSegmentData** – If `true`, segment data (Record Type 4) is ignored from the input.  

- **SuppressSsimErrors** – If `true`, exceptions on invalid input are suppressed and parser continues despite input errors; reliability may be reduced. **Warning:** Using this option may produce incorrect data.  

- **SkipValidation** – If `true`, data is read as-is without enforcing IATA compliance checks

# SSIM Writer Options

- **LocalTime** – If `true`, use local time mode; otherwise UTC

- **SkipTimezoneDifferences** – If `true`, UTC-local time differences for Departure and Arrival are ignored in the output.

- **IgnoreDuplicates** – If `true`, non-compliant IATA legs do not trigger exceptions and duplicates legs are ignored **Warning:** Using this option may produce incorrect output. 

- **SkipValidation** – If `true`, data is written as-is without compliance checks **Warning:** Using this option may produce incorrect output.   

- **BypassFrequencyRate** – If `true`, the (weekly) Frequency Rate is ignored.  

---

