//
// FILE     : Account.cs
// PROJECT  : AruaROSE Login Manager
// AUTHOR   : xHergz
// DATE     : 2017-05-23
// 

namespace AruaROSELoginManager.Data
{
    /// <summary>
    /// Holds the information for an account
    /// </summary>
    public class Account
    {
        /// <summary>
        /// The account username
        /// </summary>
        private string _username;

        /// <summary>
        /// The account password 
        /// </summary>
        private string _password;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="username">The username to use</param>
        /// <param name="password">The password to use</param>
        public Account(string username, string password)
        {
            _username = username;
            _password = password;
        }

        /// <summary>
        /// Gets/Sets the Username of the account
        /// </summary>
        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        /// <summary>
        /// Gets/Sets the Password of the account
        /// </summary>
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
    }
}
