using DesignPatterns.Models.Data;
using DesignPatterns.Repository;
using DesignPatternsAsp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DesignPatternsAsp.Controllers
{
    public class BeerController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public BeerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<BeerViewModel> beers = from d in _unitOfWork.Beers.Get()
                                               select new BeerViewModel
                                               {
                                                   Id = d.Pk,
                                                   Name = d.Name,
                                                   Style = d.Style,
                                               };
            return View("Index", beers);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var brands = _unitOfWork.Brands.Get();

            //                                      //View Bag nos sirve para que podamos
            //                                      //  mandar informacion a la vista.

            //                                      //El que va a ser el valor del select list en html
            //                                      //  va a ser el "BrandId" y el campo visual es el "Name"
            ViewBag.Brands = new SelectList(brands, "Pk", "Name");


            return View();
        }

        [HttpPost]
        public IActionResult Add(FormBeerViewModel beerVM)
        {
            if (
                //                                  //Con esto validamos el modelo.
                !ModelState.IsValid
                )
            {
                var brands = _unitOfWork.Brands.Get();
                ViewBag.Brands = new SelectList(brands, "Pk", "Name");
                //                                      //Y en caso de que esto sea invalido, 
                //                                      //  vamos a regresar a la misma vista pero 
                //                                      //  con los datos que tenia anteriomente.
                return View("Add", beerVM);
            }

            var beer = new Beer();
            beer.Name = beerVM.Name;
            beer.Style = beerVM.Style;
            if (beerVM.BrandId == null)
            {
                var brand = new Brand();
                brand.Name = beerVM.OtherBrand;
                _unitOfWork.Brands.Add(brand);
                _unitOfWork.Save();

                beer.PkBrand = brand.Pk;
            }
            else { beer.PkBrand = beerVM.BrandId; }
            _unitOfWork.Beers.Add(beer);
            //                                      //Como podemos ver, hasta este punto se va a hacer
            //                                      //  una sola conexion.
            _unitOfWork.Save();

            //                                      //Y si todo es exitoso entonces
            //                                      //  quiero que me regrese al Index.
            return RedirectToAction("Index");
        }
    }
}
