
using LanguageExt;

namespace SandBoxCore
{
    public class LanguageExtensions
    {
        public static void Run()
        {
            var s = "Hello".Concat(" ").Concat("World").Concat("!");
            Console.WriteLine(s.Length());
            Console.WriteLine(new string(s.ToArray()));


            Console.WriteLine(BuildString());
        }

        public static string BuildString()
        {
            Option<string> firstName = Option<string>.None;
            Option<string> lastName = "Matovich";


            firstName = "Paul";

            //firstName = new string("Hello".Concat(" World").ToArray());

            var stringArray = new[] { firstName.Some(x => x).None(""), lastName.Some(x => x).None("") };

            return $"X{string.Join("-", stringArray)}";
        }
    }
}
