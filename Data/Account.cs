//
// FILE     : Account.cs
// PROJECT  : AruaROSE Login Manager
// AUTHOR   : xHergz
// DATE     : 2018-10-18
// 

using System.Collections.Generic;

namespace AruaRoseLoginManager.Data
{
    /// <summary>
    /// Holds the information for an account
    /// </summary>
    public class Account
    {
        /// <summary>
        /// Account username
        /// </summary>
        public string Username { get; private set; }

        /// <summary>
        /// Account MD5 password hash
        /// </summary>
        public string PasswordHash { get; private set; }

        /// <summary>
        /// A description of the account
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Characters on the account
        /// </summary>
        public List<string> Characters { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="username">The account username</param>
        /// <param name="passwordHash">The account MD5 password hash</param>
        /// <param name="description">A description of the account</param>
        /// <param name="characters">Characters on the account</param>
        public Account(string username, string passwordHash, string description = "", List<string> characters = null)
        {
            Username = username;
            PasswordHash = passwordHash;
            Description = description;
            Characters = characters ?? new List<string>();
        }
    }
}
