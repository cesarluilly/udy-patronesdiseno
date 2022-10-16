using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Generator
{
    //                      //Director es como el ingeniero, el arquitecto, el
    //                      //  el bartender, el que sabe como prepara las 
    //                      //  cosas
    public class GeneratorDirector
    {
        private IBuilderGenerator _builderGenerator;
        public GeneratorDirector(IBuilderGenerator generatorBuilder)
        {
            SetBuilder(generatorBuilder);
        }

        public void SetBuilder(IBuilderGenerator builderGenerator) => 
            _builderGenerator = builderGenerator;
        public void CreateSimpleJsonGenerator(List<String> content, String path) 
        {
            _builderGenerator.Reset();
            _builderGenerator.SetContent(content);
            _builderGenerator.SetPath(path);
            _builderGenerator.SetFormat(TypeFormat.Json);
        }
        public void CreateSimplePipeGenerator(List<String> content, String path)
        {
            _builderGenerator.Reset();
            _builderGenerator.SetContent(content);
            _builderGenerator.SetPath(path);
            _builderGenerator.SetFormat(TypeFormat.Pipes);
            _builderGenerator.SetCharacter(TypeCharacter.UpperCase);
        }
    }
}
