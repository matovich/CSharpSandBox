
namespace SandBoxCore
{
    public class LanguageExtensions
    {
        public static void Run()
        {
            var s = "Hello".Concat(" ").Concat("World").Concat("!");
            Console.WriteLine(s.Length());
            Console.WriteLine(new string(s.ToArray()));
        }
    }
}
