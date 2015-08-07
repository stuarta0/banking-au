# banking-au
A .NET library containing data types and file IO for common banking formats in Australia.

This library implements the required file specification (with the assistance of FileHelpers) as well as the validation of the data to ensure acceptance/conformance with associated institutions.

## Supported Formats

### Westpac QuickSuper Contribution CSV File

https://quicksuper.westpac.com.au/

### Australian Bankers Association (ABA) or Cemtext File Format (EFT)

https://www.cemtexaba.com/aba-format/cemtex-aba-file-format-details

http://www.brad-smith.info/blog/archives/405

## Preliminary Support

### Australian Taxation Office (ATO) SuperStream Alternate File Format (SAFF)

POCO's exist to represent file structure, but no validation or IO is provided.

http://softwaredevelopers.ato.gov.au/ato-disclaimer?destination=sites/default/files/resource-attachments/SuperStream_alternative_file_format.xlsx

