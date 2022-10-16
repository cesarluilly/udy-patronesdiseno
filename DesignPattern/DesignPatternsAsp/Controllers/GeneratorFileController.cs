using DesignPatterns.Repository;
using Microsoft.AspNetCore.Mvc;
using Tools.Generator;

namespace DesignPatternsAsp.Controllers
{
    public class GeneratorFileController : Controller
    {
        private IUnitOfWork _unitOfWork;
        private GeneratorConcreteBuilder _generatorConcreteBuilder;
        public GeneratorFileController(IUnitOfWork unitOfWork, GeneratorConcreteBuilder generatorConcreteBuilder)
        {
            _unitOfWork = unitOfWork;
            _generatorConcreteBuilder = generatorConcreteBuilder;
        }
        public IActionResult Index() { return View(); }

        public IActionResult CreateFile(int optionFile)
        {
            try
            {
                var beer = _unitOfWork.Beers.Get();
                List<String> content = beer.Select(d=> d.Name).ToList(); 
                String path = "file"+DateTime.Now.Ticks + new Random().Next(1000)+".txt";
                var generatorDirector = new GeneratorDirector(_generatorConcreteBuilder);

                if (optionFile == 1)
                    generatorDirector.CreateSimpleJsonGenerator(content, path);
                else
                    generatorDirector.CreateSimplePipeGenerator(content, path);

                var generator = _generatorConcreteBuilder.GetGenerator();
                generator.Save();
                return Json("Archivo Generado");
            }catch(Exception e) 
            {
                return BadRequest();
            }
        }
    }
}
