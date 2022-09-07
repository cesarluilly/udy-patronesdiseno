using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.BuilderPattern
{
    public class PreparedAlcoholicDrinkConcreteBuilder : IBuilder
    {
        private PreparedDrink _prepareDrink;

        public PreparedAlcoholicDrinkConcreteBuilder()
        {
            this.Reset();
        }
        public void AddIngredients(string ingredients)
        {
            if (_prepareDrink.Ingredients == null)
                _prepareDrink.Ingredients = new List<string>();

            _prepareDrink.Ingredients.Add(ingredients);
        }

        public void Mix()
        {
            String ingredients = _prepareDrink.Ingredients.Aggregate((i, j) => 
                i+", "+j);
            _prepareDrink.Result = $"Bebida preparada con {_prepareDrink.Alcohol} de alcohol " +
                $"con los siguientes ingredientes; {ingredients}";
            Console.WriteLine("Mezclamos los ingredientes");
        }

        public void Reset()
        {
            _prepareDrink = new PreparedDrink();
        }

        public void Rest(int time)
        {
            //              //El descanso es reposar la bebida 
            //              //  de haberse echa.
            Thread.Sleep(time);
            Console.WriteLine("Listo para beberse");
        }

        public void SetAlcohol(decimal alcohol)
        {
            _prepareDrink.Alcohol = alcohol;
        }

        public void SetMilk(int milk)
        {
            _prepareDrink.Milk = milk;
        }

        public void SetWater(int water)
        {
            _prepareDrink.Water = water;
        }

        public PreparedDrink GetPrepareDrink() => _prepareDrink;
    }
}
