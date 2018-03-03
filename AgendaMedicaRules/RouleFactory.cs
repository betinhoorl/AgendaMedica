namespace AgendaMedicaRules
{
    public abstract class RouleFactory<T> where T : class, new()
    {
        private static T _CreateInstance;
        public static T CreateInstance
        {
            get
            {
                lock (typeof(RouleFactory<T>))
                {
                    if (_CreateInstance == null)
                    {
                        _CreateInstance = new T();
                    }
                }

                return _CreateInstance;
            }
        }
    }
}
