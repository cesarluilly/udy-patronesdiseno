using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.StatePattern
{
    public class CustomerContext
    {
        private IState _state;
        public decimal Residue 
        { 
            get { return this._residue; } 
            set { this._residue = value; }
        }
        private decimal _residue;

        public CustomerContext()
        {
            //              //Inicialmente el cliente tiene
            //              //  un estado inicial.
            _state = new NewState();
        }

        public void SetState(IState state) => _state = state;
        public IState GetState() => _state;
        public void Request(decimal amount) => _state.Action(this, amount);
        public void Discount(decimal amount) => _residue -= amount;
    }
}
