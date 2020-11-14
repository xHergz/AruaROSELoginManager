//
// FILE     : AccountLoginEventArgs.cs
// PROJECT  : AruaROSE Login Manager
// AUTHOR   : xHergz
// DATE     : 2017-09-30
// 

using AruaRoseLoginManager.Enum;

namespace AruaRoseLoginManager.Data
{
    public class LoginEventArgs : ListEventArgs
    {
        /// <summary>
        /// The server id to login to
        /// </summary>
        public Server ServerId { get; set; }
    }
}
