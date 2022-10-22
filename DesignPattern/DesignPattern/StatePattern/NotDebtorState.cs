using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.StatePattern
{
    public class NotDebtorState : IState
    {
        public void Action(CustomerContext customerContext, decimal amount)
        {
            //              //Nuestra compra es menor a lo que tengo.
            if (amount <= customerContext.Residue )
            {
                customerContext.Discount(amount);
                Console.WriteLine($"Solicitu permitida, gasta {amount} y le queda de saldo" +
                    $" {customerContext.Residue}");
                if (customerContext.Residue <= 0)
                    customerContext.SetState(new DebtorState());
            }
            else
            {
                Console.WriteLine($"No ajusta lo solicitado, " +
                    $"ya que tienes {customerContext.Residue} " +
                    $"y quieres gastar {amount}");
            }
        }
    }
}
