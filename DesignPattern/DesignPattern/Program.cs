// See https://aka.ms/new-console-template for more information


using DesignPattern.DependencyInjection;

var beer = new Beer("Pikatus", "Edinger");

var drinkWithBeer = new DrinkWithBeer(10, 1, beer);

drinkWithBeer.Build();



