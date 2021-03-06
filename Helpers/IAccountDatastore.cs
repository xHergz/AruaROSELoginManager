﻿//
// FILE     : IAccountDatastore.cs
// PROJECT  : AruaROSE Login Manager
// AUTHOR   : xHergz
// DATE     : 2017-05-23
// 

using System.Collections.Generic;

using AruaRoseLoginManager.Data;

namespace AruaRoseLoginManager.DAL
{
    /// <summary>
    /// Interface for the account datastore to adhere to so it can be changed easily
    /// </summary>
    public interface IAccountDatastore
    {
        /// <summary>
        /// Gets all the accounts from the datastore
        /// </summary>
        /// <returns>The list of accounts</returns>
        List<Account> GetAllAccounts();

        /// <summary>
        /// Gets all the parties from the datastore
        /// </summary>
        /// <returns></returns>
        List<Party> GetAllParties();

        /// <summary>
        /// Gets the file path of the ROSE directory
        /// </summary>
        /// <returns>The file path of the ROSE directory</returns>
        string GetFilePath();

        /// <summary>
        /// Gets the state of the run as admin flag
        /// </summary>
        /// <returns>True/False whether to run as admin</returns>
        bool GetRunAsAdmin();

        /// <summary>
        /// Gets the height and width saved for the window
        /// </summary>
        /// <returns>The window size object</returns>
        WindowSize GetWindowSize();

        /// <summary>
        /// Saves all the accounts to the datastore
        /// </summary>
        /// <param name="filePath">The file path of the ROSE directory</param>
        /// <param name="runAdAdmin">Whether or not to run as admin</param>
        /// <param name="allAccounts">The list of accounts to save</param>
        /// <param name="allParties">The list of parties to save</param>
        void SaveManagerData(string filePath, bool runAdAdmin, WindowSize size, List<Account> allAccounts, List<Party> allParties);
    }
}
