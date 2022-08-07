using DesignPatterns.Repository;
using DesignPatternsAsp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatternsAsp.Controllers
{
    public class BeerController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public BeerController (IUnitOfWork unitOfWork)
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
    }
}
