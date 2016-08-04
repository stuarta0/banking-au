# banking-au
A .NET library containing data types and file IO for common banking formats in Australia.

This library implements the required file specification (with the assistance of FileHelpers) as well as the validation of the data to ensure acceptance/conformance with associated institutions.

## Supported Formats

### Australian Bankers Association (ABA) or Cemtext File Format (EFT)

- https://www.cemtexaba.com/aba-format/cemtex-aba-file-format-details
- http://www.brad-smith.info/blog/archives/405

### Westpac QuickSuper Contribution CSV File

- https://quicksuper.westpac.com.au/


### Australian Taxation Office (ATO) SuperStream Alternate File Format (SAFF)

**Only preliminary support**

POCO's exist to represent file structure, but no validation or IO is provided.

http://softwaredevelopers.ato.gov.au/ato-disclaimer?destination=sites/default/files/resource-attachments/SuperStream_alternative_file_format.xlsx

## Examples

### ABA

Usage of the ABA file API is meant to be simple.  Total records can be automatically generated and a helper IO class is provided for convenience.

```c#
// Simplest use case

var file = new AbaFile();
foreach (var row in myData)
{
  file.DetailRecords.Add(new Records.DetailRecord()
  {
    Bsb = row['bsb'],
    Amount = row['amount']
    // etc
  });
}
file.UpdateTotalRecord();
new AbaFileIO.Write(@"C:\file.aba", file);
```

To ensure your data conforms to the specification, a set of validator classes are provided that can provide both validation and automatic correction (truncation, aggregration, invalid character removal).  These functions are Validate() and Clean() respectively.

```c#
// Validated use case

var file = new AbaFile();
var validator = new AbaFileValidator();

foreach (var row in myData)
{
  var record = new Records.DetailRecord()
  {
    Bsb = row['bsb'],
    Amount = row['amount']
    // etc
  };
  if (validator.CanAdd(file, record))
    file.DetailRecords.Add(record);
  else
  { /* file limits exceeded, create new AbaFile */ }
}

try 
{
  validator.Clean(file);
  new AbaFileIO.Write(@"C:\file.aba", file);
}
catch (IOException io)
{
  // could not write file
}
catch (Exception ex)
{
  // invalid data within AbaFile
  foreach (Exception e in validator.Validate(file))
    Console.WriteLine(e.Message);
}
```
