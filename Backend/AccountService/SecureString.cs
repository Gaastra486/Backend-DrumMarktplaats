using System.Security.Cryptography;
using System.Text;

namespace AccountService.Microservice
{
    public class SecureString
    {
        public static string ComputeStringToSha256Hash(string text)
        {
           
            // Create a SHA256 hash from string
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Computing Hash - returns here byte array
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(text));

                // now convert byte array to a string
                StringBuilder stringbuilder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    stringbuilder.Append(bytes[i].ToString("x2"));

                }
                return stringbuilder.ToString();
            }
        }
   
    }
}
