using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.FactoryPattern
{
    //                          //El contexto sera una fabrica de ventas.


    //                          //**CREATOR**
    public abstract class SaleFactory
    {
        public abstract ISale GetSale();
    }

    //                          //**CONCRETE CREATOR**
    public class StoreSaleFactory : SaleFactory
    {
        //Esta fabrica tiene la responsabilida de agregar un extra a la venta por tienda.
        private decimal _extra;

        public StoreSaleFactory(decimal extra)
        {
            _extra = extra; 
        }
        public override ISale GetSale()
        {
            //                  //Vamos a implementar la creacion del objeto que
            //                  //  nos involucra. 
            return new StoreSale(_extra);
        }
    }

    //                          //**CONCRETE CREATOR**
    public class InternetSaleFactory : SaleFactory
    {
        //                      //Esta clase ya es la fabrica para crear las ventas
        //                      //  por internet.
        private decimal _discount;
        public InternetSaleFactory(decimal discount)
        {
            _discount = discount;
        }

        public override ISale GetSale()
        {
            //                   //Como vemos el descuenta y la responsabilidad cae en
            //                   //   InternetSaleFactory y es aqui en este metodo donde
            //                   //   creamos el objeto de ventas por internet.
           
            return new InternetSale(_discount);
        }
    }

    //                          //**CONCRET PRODUCT**
    //                          //Clase que va a traer el objeto, el producto real.

    public class StoreSale : ISale
    {
        private decimal _extra;
        public StoreSale(decimal extra)
        {
            _extra = extra;
        }
        public void Sell(decimal total)
        {
            Console.WriteLine($"La venta en TIENDA tiene un total de {total + _extra}");
        }
    }

    public class InternetSale : ISale
    {
        private decimal _discount;
        public InternetSale(decimal discount)
        {
            _discount = discount;   
        }

        public void Sell(decimal total)
        {
            Console.WriteLine($"La venta en INTERNET tiene un total de {total - _discount}");
        }
    }

    //                          //Interface que solo sirve para categorizar en este caso 
    //                          //  mis ventas.
    //                          //**PRODUCT**
    public interface ISale
    {
        public void Sell(decimal total);
    }
}
