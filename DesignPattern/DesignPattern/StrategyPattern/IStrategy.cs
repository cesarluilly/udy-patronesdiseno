using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.StrategyPattern
{
    //                      //Se va a trabajar en una estrategia
    //                      //  de vehiculos de transporte
    //                      //  y cualquier vehiculo que lo que
    //                      //  es correr o caminar.
    //                      //Entonces la estrategia es distinta
    //                      //  para los distintos objetos de bici, 
    //                      //  carro, patineta pero es la misma 
    //                      //  accion de correr.
    public interface IStrategy
    {
        public void Run();
    }
}
