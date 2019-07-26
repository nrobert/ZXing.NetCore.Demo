# ZXing.Net with .NetCore - Issue illustration
Demo of ZXing.Net behaviour on .Net Core with ConsoleApp and Azure Function.

We found a strang behaviour when trying to decode barcodes using ZXing.Net, in a .Net Core environment, especially when using Azure Functions.
This repository hosts the necessary code to demonstrate the case.

## What we initially saw
The `Decode` method is not always returning results when called from an Azure Function (v2, so .Net Core).
Using a Console App in .Net Core, we always find the right result.

## Our tests
### Implementations
There are 3 implementations:
 - One with `ZXing.Net.Bindings.ImageSharp` Nuget package (which depends on `ZXing.Net` Nuget package)
 - One with `ZXing.Net.Bindings.ImageSharp` and `ZXing.Net` DLLs built in **Debug** mode from source on `https://github.com/micjahn/ZXing.Net`
 - One with `ZXing.Net.Bindings.ImageSharp` and `ZXing.Net` DLLs built in **Release** mode from source on `https://github.com/micjahn/ZXing.Net`
 
### Detail of each implementation
Each implementation has 2 ways of decoding barcodes:
 - in a Console Application, targeting .Net Core 2.2
 - in an Azure Function, targeting .Net Core 2.2
 
The 2 ways call the same decoding source code to ensure that there is no difference.

### Tests conclusion
Using Nuget packages or Release version of DLLs, the result provided is variable: barcode are not detected most of the time (around 1 good detection every 5 to 10 try)
