//
// FILE     : AccountDisplayEventArgs.cs
// PROJECT  : AruaROSE Login Manager
// AUTHOR   : xHergz
// DATE     : 2017-09-30
// 

using System;

namespace AruaROSELoginManager.Data
{
    public class AccountDisplayEventArgs : EventArgs
    {
        /// <summary>
        /// The account name
        /// </summary>
        public string AccountName { get; set; }
    }
}
