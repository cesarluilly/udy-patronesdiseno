using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.StrategyPattern
{
    public class Context
    {
        private IStrategy _strategy;
        public IStrategy Strategy
        {
            //              //Esto nos va a dar el poder de
            //              //  que podamos cambiar el 
            //              //  comportamiento de Run.
            //              //Es decir que en tiempo de ejecucion
            //              //  quiero que el objeto se comporte 
            //              //  como carro, o como motocicleta.
            set { _strategy = value; }
        }
        public Context(IStrategy strategy)
        {
            _strategy = strategy;
        }
        public void Run()
        {
            //              //Aqui es un metodo en donde
            //              //  no me importa como corras, 
            //              //  simplemente quiero que corras.
            _strategy.Run();
        }
    }
}
