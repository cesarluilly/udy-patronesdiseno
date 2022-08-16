using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DesignPattern.Singleton
{
    public class Log
    {
        private readonly static Log _instance = new Log();
        private String _path = "log.txt";

        public static Log Instance
        {
            get { return _instance; }
        }

        private Log()
        {

        }

        public void Save(String message)
        {
            File.AppendAllText(_path, message + Environment.NewLine);
        }
    }
}
