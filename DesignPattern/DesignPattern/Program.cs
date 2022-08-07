// See https://aka.ms/new-console-template for more information
using DesignPattern.Models;
using DesignPattern.RepositoryPattern;

Console.WriteLine("Hello, World!");

using var context = new DesignPatternContext();

var beerRepository = new BeerRepository(context);
var beer = new Beer();
beer.Name = "Heineken";
beer.Style = "Light";

beerRepository.Add(beer);
beerRepository.Save();

foreach (var b in beerRepository.Get())  
{
    Console.WriteLine(b.Name);
}

















