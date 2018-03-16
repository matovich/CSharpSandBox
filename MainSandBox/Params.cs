using System.Globalization;
using System.Text;

namespace SandBox
{
    public class Params
    {
        public string Concatenate(int value, params string[] args)
        {
            var sb = new StringBuilder();

            foreach (string s in args)
                sb.Append(s);

            sb.Append(value.ToString(CultureInfo.InvariantCulture));
            return sb.ToString();
        }
    }
}