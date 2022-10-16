using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Generator
{
    public enum TypeFormat
    {
        Json,
        Pipes
    }

    public enum TypeCharacter
    {
        Normal,
        UpperCase,
        LowerCase
    }
    public interface IBuilderGenerator
    {
        //                  //Siempre va a tener un reset
        //                  //  para resetear la configuracion.
        public void Reset();

        //                  //Recibimos el contenido y puede de diferentes lugares.
        public void SetContent(List<String> content);
        //                  //Path donde vamos a guardar el archivo.
        public void SetPath(String path);
        //                  //Formato del archivo.
        public void SetFormat(TypeFormat format);
        //                  //Tipo de caracteres.
        public void SetCharacter(TypeCharacter character = TypeCharacter.Normal);
    }
}
