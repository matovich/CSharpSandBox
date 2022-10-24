using System;
using System.Text;

namespace SandBoxCore
{
    public class PasswordEncoding
    {
        public string EncodePw(string user, string password)
        {
            string stringToEncode = String.Format("{0}:{1}", user, password);

            return Encode(stringToEncode);
        }

        public string Encode(string stringToEncode)
        {
            byte[] toEncodeAsBytes = Encoding.ASCII.GetBytes(stringToEncode);
            return Convert.ToBase64String(toEncodeAsBytes);
        }

        public string UnEncode(string value)
        {
            byte[] v2 = Convert.FromBase64String(value);
            return Encoding.ASCII.GetString(v2);
        }
    }
}