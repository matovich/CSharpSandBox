namespace SandBoxCore
{
    internal class GenericPlay : IGenericInterface
    {
        public T GetSomething<T>(string s, int i) where T : new()
        {
            return new T();
        }

        public bool IsThing<T>(string s, T value, int i)
        {
            return true;
        }
    }
}