// See https://aka.ms/new-console-template for more information
using DesignPattern.Models;

Console.WriteLine("Hello, World!");

using var context = new DesignPatternContext();

var lst = context.Beers.ToList();

foreach (var beer in lst)
{
    Console.WriteLine(beer.Name);
}

















