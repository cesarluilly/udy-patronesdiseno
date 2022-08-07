// See https://aka.ms/new-console-template for more information
using DesignPattern.Models;
using DesignPattern.RepositoryPattern;

Console.WriteLine("Hello, World!");

using var context = new DesignPatternContext();
var beerRepository = new Repository<Beer>(context);
var beer = new Beer() { Name = "Fuller", Style = "Strong Ale" };
beerRepository.Add(beer);
beerRepository.Save();

foreach (var b in beerRepository.Get())
{
    Console.WriteLine(b.Name);
}
//                                              //Eliminamos el elemento.
beerRepository.Delete(4);

//                                              //Creamos un objeto de otro tipo.
var brandRepository = new Repository<Brand>(context);
var brand = new Brand() { Name = "FullerBrand"};

brandRepository.Add(brand);
brandRepository.Save();

foreach (var b in brandRepository.Get())
{
    Console.WriteLine(b.Name);
}













