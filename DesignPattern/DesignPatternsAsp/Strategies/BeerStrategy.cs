using DesignPatterns.Models.Data;
using DesignPatterns.Repository;
using DesignPatternsAsp.Models.ViewModels;

namespace DesignPatternsAsp.Strategies
{
    public class BeerStrategy : IBeerStrategy
    {
        public void Add(FormBeerViewModel beerVM, IUnitOfWork unitOfWork)
        {
            var beer = new Beer();
            beer.Name = beerVM.Name;
            beer.Style = beerVM.Style;
            beer.PkBrand = beerVM.BrandId;

            unitOfWork.Beers.Add(beer);
            unitOfWork.Save();
        }
    }
}
