using Microsoft.AspNetCore.Mvc;
using Tools.Earn;

namespace DesignPatternsAsp.Controllers
{
    public class ProductDetailController : Controller
    {
        public IActionResult Index(decimal total)
        {
            //              //Factories o fabricas.
            LocalEarnFactory localEarnFactory = new LocalEarnFactory(0.20m);
            ForeingEarnFactory foreignEarnFactory = new ForeingEarnFactory(0.30m, 20);

            //              //Products.
            var localEarn = localEarnFactory.GetEarn();
            var foreingEarn = foreignEarnFactory.GetEarn();

            //              //Total.

            //              //Un Viewgab es un diccionario dinamico
            //              //  en donde se le pueden agregar elementos.

            //              //Mandamos al viewbag el total mas su ganancia.
            ViewBag.totalLocal = total + localEarn.Earn(total);
            ViewBag.totalForeing = total + foreingEarn.Earn(total);

            return View();
        }
    }
}
