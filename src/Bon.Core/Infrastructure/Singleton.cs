namespace Bon.Core.Infrastructure
{
    public class Singleton<T> : BaseSingleton
        where T : new()
    {
        private static Lazy<T> instance;

        static Singleton()
        {
            instance = new Lazy<T>(() => new T());
        }

        public static T Instance => instance.Value;

        private static bool isInstanceSet = false;

        public static void SetInstance(T value)
        {
            if (isInstanceSet)
                throw new InvalidOperationException(
                    $"Singleton instance of type {typeof(T)} has already been initialized."
                );

            instance = new Lazy<T>(() => value);
            isInstanceSet = true;
        }
    }
}
