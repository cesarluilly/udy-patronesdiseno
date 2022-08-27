using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Earn
{
    //                      //Todos lo productos que yo cree 
    //                      //  esta interface, van a tener un
    //                      //  metodo que va a calcular la 
    //                      //  ganancia.
    public interface IEarn
    {
        public decimal Earn(decimal amount);
    }
}
