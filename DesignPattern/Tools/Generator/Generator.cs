using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Tools.Generator
{
    public class Generator
    {
        public List<String> Content { get; set; }
        public String Path { get; set; }
        public TypeFormat Format { get; set; }
        public TypeCharacter Character { get; set; }
        public void Save()
        {
            String result = "";
            result = Format == TypeFormat.Json ? GetJson() : GetPipe();
            if (Character == TypeCharacter.UpperCase) result = result.ToUpper();
            if (Character == TypeCharacter.LowerCase) result = result.ToLower();

            File.WriteAllText(Path,result);
        }

        private String GetJson() => JsonSerializer.Serialize(Content);
        private String GetPipe() => Content.Aggregate((accum, current) => accum + "|" + current);
    }
}
