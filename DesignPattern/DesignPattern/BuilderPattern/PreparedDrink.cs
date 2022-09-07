using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.BuilderPattern
{
    public class PreparedDrink
    {
        //                  //Que pasaria si yo quisiera crear
        //                  //  bebida que sea margarita o 
        //                  //  una Piña colada, etc.
        //                  //Eso significaria tener muchos 
        //                  //  constructores y cada uno
        //                  //  con su propia configuracion 
        //                  //  para crear la bebida requerida.
        //                  //  y esto lo resuelve el Builder.
        public List<String> Ingredients = new List<String>();
        public int Milk;
        public int Water;
        public decimal Alcohol;

        public String Result;

        public PreparedDrink()
        {

        }
    }
}
