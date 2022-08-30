using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.DependencyInjection
{
    //                      //Esta bebida tiene un objeto llamado cerveza, ,
    //                      //  
    public class DrinkWithBeer
    {
        private Beer _beer;
        private decimal _water;
        private decimal _sugar;
        public DrinkWithBeer(decimal water, decimal sugar, Beer beer)
        {
            _sugar = sugar;
            _water = water; 
            _beer = beer; 
        }
        public void Build()
        {
            Console.WriteLine($"Preparamos bebida que tiene agua {_water} " + 
                $" azucar {_sugar} y cerveza {_beer.Name}");
        }
    }
}
