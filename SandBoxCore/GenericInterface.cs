namespace SandBoxCore
{
    internal interface IGenericInterface
    {
        // new means that the type passed in needs to have a no-parameter constructor.
        T GetSomething<T>(string s, int i) where T : new();

        bool IsThing<U>(string s, U value, int i);
    }
}