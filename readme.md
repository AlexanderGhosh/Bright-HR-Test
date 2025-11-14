# Code Kata
## Kata09: Back to the Checkout

Targets .NET 8 and .NET Standard 2.0 <br>
Language version 13

This is an implementation of https://github.com/brighthr/checkout-kata for the Bright HR Technical Test
It is a class library which provides interfaces and implementations for a point of sale checkout system. with support for a dynamic product catalogue and special offers.

### Usage
```bash
git clone https://github.com/AlexanderGhosh/Bright-HR-Test.git --branch main
cd Bright-HR-Test/Kata.Checkout 
dotnet build
```
You can then reference the built DLL in your own project.
You can Pack the project and use it in nuget
```bash
dotnet pack -c Release
```
Or run the unit tests to see it in action
```bash
cd ..
dotnet test
```

### Example
```csharp
using Kata.Checkout;
using Kata.Checkout.Promotion;

Dictionary<stirng, CatalogueItem> items = new Dictionary<string, CatalogueItem>
{
	{ "A", new CatalogueItem("A", 50, new MultiBuyPromotion(3, 130)) },
	{ "B", new CatalogueItem("B", 30, new MultiBuyPromotion(2, 45)) },
	{ "C", new CatalogueItem("C", 20) },
	{ "D", new CatalogueItem("D", 15) }
};
ICatalogue catalogue = new Catalogue(items);
ICheckout checkout = new Checkout(catalogue);

checkout.Scan("A");
checkout.Scan("A");
checkout.Scan("A");
checkout.Scan("B");
checkout.Scan("B");
checkout.Scan("B");
checkout.Scan("C");
checkout.Scan("D");

int total = checkout.GetTotalPrice(); 
Console.WriteLine(total);
// 240
```