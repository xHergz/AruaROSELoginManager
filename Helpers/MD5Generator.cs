//
// FILE     : MD5Generator.cs
// PROJECT  : AruaROSE Login Manager
// AUTHOR   : xHergz
// DATE     : 2017-05-23
// 

using System.Text;
using System.Security.Cryptography;

namespace AruaROSELoginManager.Helpers
{
    /// <summary>
    /// Generates MD5 hashes from strings
    /// </summary>
    public class MD5Generator
    {
        /// <summary>
        /// Creates an MD5 hash from a string. 
        /// Source: https://msdn.microsoft.com/en-us/library/system.security.cryptography.md5(v=vs.110).aspx
        /// </summary>
        public static string GetMd5Hash(string input)
        {
            //Create MD5 Object
            MD5 md5Hash = MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
    }
}
