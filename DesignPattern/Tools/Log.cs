namespace Tools
{
    public sealed class Log
    {
        private static Log _instance = null;
        private String _path;
        private static object _protect = new object();

        public static Log GetInstance(String path)
        {
            lock (_protect)
            {
                if (_instance == null)
                {
                    _instance = new Log(path);
                }
            }
            return _instance;
        }

        private Log(String path)
        {
            _path = path;
        }

        public void Save(String message)
        {
            File.AppendAllText(_path, message + Environment.NewLine);
        }
    }
}