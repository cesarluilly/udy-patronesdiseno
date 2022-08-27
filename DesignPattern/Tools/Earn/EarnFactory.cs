using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Earn
{
    public abstract class EarnFactory
    {
        //                  //En esta clase abstracta tiene una
        //                  //  regla para crear objetos en los
        //                  //  lugares donde se implemente.
        public abstract IEarn GetEarn();
    }
}
