using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.DependencyInjection
{
    public class Beer
    {
        private String _name;
        private String _brand;

        public String Name
        {
            get
            {
                return _name;
            }
        }

        public Beer(string name, string brand)
        {
            _name = name;
            _brand = brand;
        }
    }
}
