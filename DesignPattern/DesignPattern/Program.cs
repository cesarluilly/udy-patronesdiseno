// See https://aka.ms/new-console-template for more information
//      //Pattern State.
using DesignPattern.StatePattern;

var customerContext = new CustomerContext();
Console.WriteLine(customerContext.GetState());

//                          //Inicialemnte el cliente es nuevo
//                          //  y en este caso al invocar request()
//                          //  le asigna 100 a su cuenta.
//                          //  ya que estoy en el state NewState.
customerContext.Request(100);

Console.WriteLine(customerContext.GetState());

//                          //En este punto el cliente tiene un estado
//                          //  de NoDeudor y simula una compra de 50.
customerContext.Request(50);
Console.WriteLine(customerContext.GetState());

//                          //Me quedan 50 pesos en mi cuenta, por lo tanto
//                          //  sigo teniendo el estado de NoDeudor.
//                          //Pero ahora decido hacer una compra de 100
//                          //  pero como no tengo el saldo suficiente, me
//                          //  sigue dejando en el mismo estado.
customerContext.Request(100);
Console.WriteLine(customerContext.GetState());

//                          //Ahora quiero hacer una compra de 50 lo que ahora
//                          //  si se realiza la operacion y me deja en un estado
//                          //  como deudor, aunque tambien podria ser un estado sin
//                          //  saldo.
customerContext.Request(50);
Console.WriteLine(customerContext.GetState());

customerContext.Request(50);
Console.WriteLine(customerContext.GetState());

//                          //LO INTERESANTE DE AQUI, ES QUE SOLO ES UN
//                          //  METODO EL QUE REALIZA LAS DIFERENTES OPERACIONES.
//                          //ESTE PATRON SIRVE PARA QUE EL ESTADO QUE ES UN OBJETO, 
//                          //  TENGA EL FUNCIONAMIENTO AISLADO DE LOS DEMAS OBEJTOS,
//                          //  Y PUEDAMOS TENER NUEVOS ESTADOS QUE TENGAN NUEVOS 
//                          //  COMPORTAMIENTOS.
