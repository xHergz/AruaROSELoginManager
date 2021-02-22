//
// FILE     : IAccountDisplay.cs
// PROJECT  : AruaROSE Login Manager
// AUTHOR   : xHergz
// DATE     : 2021-02-19
// 

using System;

using AruaRoseLoginManager.Data;
using AruaRoseLoginManager.Enum;

namespace AruaRoseLoginManager.Helpers
{
    /// <summary>
    /// Interface specific for displaying the account list
    /// </summary>
    public interface IAccountDisplay: ILoginDisplay<Account>
    {
        /// <summary>
        /// Event to raise when prompting the user to enter their password for logging in
        /// </summary>
        event EventHandler<LoginWithPassEventArgs> PromptedLoginRequest;

        /// <summary>
        /// Fills in the Account form with known account data
        /// </summary>
        /// <param name="info">Current account data</param>
        void Prompt(Account info);

        /// <summary>
        /// Switch to the login screen to prompt for a password to login to an account
        /// </summary>
        /// <param name="username">The username to prompt for</param>
        /// <param name="serverId">The server being logged in to</param>
        void PromptForPassword(string username, Server serverId);
    }
}
