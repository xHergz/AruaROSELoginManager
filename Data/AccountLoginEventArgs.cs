//
// FILE     : AccountLoginEventArgs.cs
// PROJECT  : AruaROSE Login Manager
// AUTHOR   : xHergz
// DATE     : 2017-09-30
// 

using System;
using AruaRoseLoginManager.Enum;

namespace AruaRoseLoginManager.Data
{
    public class AccountLoginEventArgs : EventArgs
    {
        /// <summary>
        /// The account name to login
        /// </summary>
        public string AccountName { get; set; }

        /// <summary>
        /// The character name to login if applicable
        /// </summary>
        public string CharacterName { get; set; }

        /// <summary>
        /// The server id to login to
        /// </summary>
        public Server ServerId { get; set; }

        /// <summary>
        /// The login type
        /// </summary>
        public LoginType LoginType { get; set; }

        /// <summary>
        /// The path to the rose folder
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// Whether or not to run as admin
        /// </summary>
        public bool RunAsAdmin { get; set; }
    }
}
