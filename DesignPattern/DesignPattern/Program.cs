// See https://aka.ms/new-console-template for more information
using DesignPattern.Models;
using DesignPattern.RepositoryPattern;
using DesignPattern.UnitOfWorkPattern;

Console.WriteLine("Hello, World!");

using var context = new DesignPatternContext();

var unitOfWork = new UnitOfWork(context);

//                                      //Obtenemos el repositorio de Beers.
var beersRepo = unitOfWork.Beers;

//                                      //Creamos nueva cerveza y agregamos al repositorio.
var beer = new Beer(){
    Name = "Fuller",
    Style = "Porter"
    };
beersRepo.Add(beer);

var brandsRepo = unitOfWork.Brands;
var brand = new Brand()
{
    Name = "Fuller"
};
brandsRepo.Add(brand);

//                                      //Solo hacemos 1 conexion para guardar 2 elementos.
unitOfWork.Save();










