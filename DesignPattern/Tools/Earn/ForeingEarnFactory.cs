using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Earn
{
    public class ForeingEarnFactory : EarnFactory
    {
        //                  //Estas variables privadas son 
        //                  //  lo que dependen de crear un objeto
        //                  //  ForeignEarn
        private decimal _percentage;
        private decimal _extra;
        public ForeingEarnFactory(decimal percentage, decimal extra)
        {
            _percentage = percentage;
            _extra = extra;
        }

        public override IEarn GetEarn()
        {
            return new ForeingEarn(_percentage, _extra);
        }
    }
}
