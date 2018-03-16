using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security;

namespace SandBox
{
    public class SecureStringPlay
    {
        private readonly SecureString _secureString;

        public SecureStringPlay()
        {
            var password = new[] {'p', 'a', 's', 's', 'w', 'o', 'r', 'd', '0'};
            _secureString = new SecureString();
            foreach (char character in password)
                _secureString.AppendChar(character);
        }

        public string GetPassword()
        {
            return GetPassword(_secureString);
        }

        public string GetPassword(SecureString secureString)
        {
            IntPtr unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = Marshal.SecureStringToBSTR(secureString);
                return Marshal.PtrToStringBSTR(unmanagedString);
            }
            finally
            {
                Marshal.ZeroFreeBSTR(unmanagedString);
            }
        }

        public IEnumerable<char> GetCharacterArray()
        {
            IntPtr unmanagedString = Marshal.SecureStringToBSTR(_secureString);
            var characters = new List<char>();

            try
            {
                unsafe
                {
                    var character = (char*) unmanagedString.ToPointer();
                    do
                    {
                        characters.Add(*character);
                    } while (*character++ != 0);
                }
            }
            finally
            {
                Marshal.ZeroFreeBSTR(unmanagedString);
            }

            return characters;
        }
    }
}