using DesignPatterns.Models.Data;
using DesignPatterns.Repository;
using DesignPatternsAsp.Models.ViewModels;

namespace DesignPatternsAsp.Strategies
{
    public class BeerWithBrandStrategy : IBeerStrategy
    {
        public void Add(FormBeerViewModel beerVM, IUnitOfWork unitOfWork)
        {
            //              //Create the beer.
            var beer = new Beer();
            beer.Name = beerVM.Name;
            beer.Style = beerVM.Style;

            //              //Create the brand.
            var brand = new Brand();
            brand.Name = beerVM.OtherBrand;

            //              //Save the Brand
            unitOfWork.Brands.Add(brand);
            unitOfWork.Save();

            //              //Assign PkBrand to Beer and save.
            beer.PkBrand = brand.Pk;
            unitOfWork.Beers.Add(beer);
            unitOfWork.Save();
        }
    }
}
