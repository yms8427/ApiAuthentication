using System.Security.Cryptography;
using System.Text;

namespace BilgeAdam.SecuredApp.Services.Extensions
{
    public static class StringExtensions
    {
        public static string ComputeHash(this string randomString)
        {
            var crypt = new SHA256Managed();
            byte[] crypto = crypt.ComputeHash(Encoding.ASCII.GetBytes(randomString));
            var builder = new StringBuilder();
            foreach (byte theByte in crypto)
            {
                builder.Append(theByte.ToString("x2"));
            }
            return builder.ToString();
        }
    }
}
