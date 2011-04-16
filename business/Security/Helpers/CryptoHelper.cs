using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Epiworx.Core.Helpers
{
    public class CryptographyHelper
    {
        // We are going to pass in the key portion in our method calls
        private static byte[] Key = { };
        private static byte[] IV = { 18, 52, 86, 120, 144, 171, 205, 239 };

        public static string Decrypt(string text, string encryptionKey)
        {
            // Check for valid length encryption key 
            if (encryptionKey.Length < 8)
            {
                throw new Exception("Encryption Key must be a minimum of 8 characters long");
            }

            if (text.Trim().Length == 0)
            {
                return string.Empty;
            }

            var inputByteArray = new byte[text.Length + 1];

            // We are going to make things easy by insisting on an 8 byte legal key length
            CryptographyHelper.Key = System.Text.Encoding.UTF8.GetBytes(encryptionKey.Substring(0, 8));
            var des = new DESCryptoServiceProvider();

            // We have a base 64 encoded string so first must decode to regular unencoded (encrypted) string
            inputByteArray = Convert.FromBase64String(text);

            // Now decrypt the regular string
            var ms = new MemoryStream();

            var cs = new CryptoStream(ms, des.CreateDecryptor(Key, IV), CryptoStreamMode.Write);

            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();

            System.Text.Encoding encoding = System.Text.Encoding.UTF8;

            return encoding.GetString(ms.ToArray());
        }

        public static string Encrypt(string text, string encryptionKey)
        {
            // Check for valid length encryption key 
            if (encryptionKey.Length < 8)
            {
                throw new Exception("Encryption Key must be a minimum of 8 characters long");
            }

            Key = System.Text.Encoding.UTF8.GetBytes(encryptionKey.Substring(0, 8));
            var des = new DESCryptoServiceProvider();

            // Convert our input string to a byte array
            var inputByteArray = Encoding.UTF8.GetBytes(text);

            // Now encrypt the bytearray
            var ms = new MemoryStream();
            var cs = new CryptoStream(ms, des.CreateEncryptor(Key, IV), CryptoStreamMode.Write);

            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();

            // Now return the byte array as a "safe for XMLDOM" Base64 String
            return Convert.ToBase64String(ms.ToArray());
        }
    }
}
