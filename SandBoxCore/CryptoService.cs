using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace SandBoxCore
{
    public class CryptoService
    {
        //public static string EncryptText(string openText)
        //{
        //    var rc2CSP = new RC2CryptoServiceProvider();
        //    var encryptor = rc2CSP.CreateEncryptor(Convert.FromBase64String(c_key), Convert.FromBase64String(c_iv));
        //    using (var msEncrypt = new MemoryStream())
        //    {
        //        using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
        //        {
        //            var toEncrypt = Encoding.Unicode.GetBytes(openText);

        //            csEncrypt.Write(toEncrypt, 0, toEncrypt.Length);
        //            csEncrypt.FlushFinalBlock();

        //            var encrypted = msEncrypt.ToArray();

        //            return Convert.ToBase64String(encrypted);
        //        }
        //    }
        //}


        public static string DecryptText2(string encryptedText)
        {
            var credentials = System.Net.CredentialCache.DefaultCredentials;


            return string.Empty;
        }

        public static string DecryptText(string encryptedText)
        {
            var rc2CSP = new RC2CryptoServiceProvider();



            var decryptor = rc2CSP.CreateDecryptor(Convert.FromBase64String("de071660"), Convert.FromBase64String(""));
         //   var decryptor = rc2CSP.CreateDecryptor();
            using (var msDecrypt = new MemoryStream(Convert.FromBase64String(encryptedText)))
            {
                using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    var bytes = new List<byte>();
                    int b;
                    do
                    {
                        b = csDecrypt.ReadByte();
                        if (b != -1)
                        {
                            bytes.Add(Convert.ToByte(b));
                        }

                    }
                    while (b != -1);

                    return Encoding.Unicode.GetString(bytes.ToArray());
                }
            }
        }
    }
}
