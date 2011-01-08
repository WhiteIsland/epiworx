using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Epiworx.Security;

namespace Epiworx.WebMvc.Helpers
{
    public static class UrlHelperExtensions
    {
        public static string Gravatar(this UrlHelper url)
        {
            var user = (BusinessIdentity)Csla.ApplicationContext.User.Identity;

            return string.Format(
                "http://www.gravatar.com/avatar/{0}",
                MD5Hash(user.Email.ToLower()));
        }

        public static string Gravatar(this UrlHelper url, string emailAddress)
        {
            return string.Format(
                "http://www.gravatar.com/avatar/{0}",
                MD5Hash(emailAddress.ToLower()));
        }

        public static string Gravatar(this UrlHelper url, string emailAddress, int size)
        {
            return string.Format(
                "http://www.gravatar.com/avatar/{0}?s={1}",
                MD5Hash(emailAddress.ToLower()),
                size);
        }

        private static string MD5Hash(string input)
        {
            var hash = new StringBuilder();
            var cryptoProvider = new MD5CryptoServiceProvider();
            byte[] bytes = cryptoProvider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }

            return hash.ToString();
        }
    }
}