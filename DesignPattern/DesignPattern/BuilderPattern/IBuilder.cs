using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.BuilderPattern
{
    public interface IBuilder
    {
        //                  //Para regresar al objeto a una 
        //                  //  creacion en blanco.
        public void Reset();
        public void SetAlcohol(decimal alcohol);
        public void SetWater(int water);
        public void SetMilk(int milk);

        public void AddIngredients(String ingredients);
        public void Mix();  //Mesclar
        public void Rest(int time); //Descanso.

    }
}
