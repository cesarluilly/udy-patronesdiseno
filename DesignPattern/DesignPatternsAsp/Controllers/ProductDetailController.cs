using Microsoft.AspNetCore.Mvc;
using Tools.Earn;

namespace DesignPatternsAsp.Controllers
{
    public class ProductDetailController : Controller
    {
        private LocalEarnFactory _localEarnFactory;
        private ForeingEarnFactory _foreignEarnFactory;
        public ProductDetailController(LocalEarnFactory localEarnFactory,
            ForeingEarnFactory foreignEarnFactory)
        {
            _localEarnFactory = localEarnFactory;
            _foreignEarnFactory = foreignEarnFactory;
        }


        public IActionResult Index(decimal total)
        {
            //              //Factories o fabricas.
            ForeingEarnFactory foreignEarnFactory = new ForeingEarnFactory(0.30m, 20);

            //              //Products.
            var localEarn = _localEarnFactory.GetEarn();
            var foreingEarn = _foreignEarnFactory.GetEarn();

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
