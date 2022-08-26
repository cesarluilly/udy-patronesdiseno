// See https://aka.ms/new-console-template for more information


using DesignPattern.FactoryPattern;

//                          //Fabrica para las ventas de tienda
SaleFactory storeSaleFactory = new StoreSaleFactory(10);

//                          //Fabrica para las ventas por internet.
SaleFactory internetSaleFactory = new InternetSaleFactory(10);

//                          //Creamos un objeto de tipo tienda.
ISale sale1 = storeSaleFactory.GetSale();
sale1.Sell(15);

//                          //Creo un objeto para poder hacer
//                          //  una venta po internet.
ISale sale2 = internetSaleFactory.GetSale();
sale2.Sell(15);

//                          //Y de esta forma separamos 
//                          //  responsabilidades.
//                          //De tal forma que separamos la parte
//                          //  de la fabrica para despues
//                          //  crear el objeto.




