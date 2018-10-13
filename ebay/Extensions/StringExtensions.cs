using System;
using System.Text;

namespace EbayNet.Extensions
{
    public static class StringExtensions
    {
        public static string Base64Encode(this string @this)
        {
            if (string.IsNullOrEmpty(@this))
            {
                return @this;
            }

            var plainTextBytes = Encoding.UTF8.GetBytes(@this);
            return Convert.ToBase64String(plainTextBytes);
        }

        public static string Base64Decode(this string @this)
        {
            var base64EncodedBytes = Convert.FromBase64String(@this);
            return Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }
}