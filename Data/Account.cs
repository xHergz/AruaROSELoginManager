//
// FILE     : Account.cs
// PROJECT  : AruaROSE Login Manager
// AUTHOR   : xHergz
// DATE     : 2018-10-18
// 

using System.Collections.Generic;

namespace AruaROSELoginManager.Data
{
    /// <summary>
    /// Holds the information for an account
    /// </summary>
    public class Account
    {
        public string Username { get; private set; }

        public string Password { get; private set; }

        public string Description { get; private set; }

        public List<string> Characters { get; private set; }

        public Account(string username, string password, string description = "", List<string> characters = null)
        {
            Username = username;
            Password = password;
            Description = description;
            Characters = characters ?? new List<string>();
        }
    }
}
