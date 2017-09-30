//
// FILE     : IAccountDatastore.cs
// PROJECT  : AruaROSE Login Manager
// AUTHOR   : xHergz
// DATE     : 2017-05-23
// 

using System.Collections.Generic;

using AruaROSELoginManager.Data;

namespace AruaROSELoginManager.DAL
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
        /// Saves all the accounts to the datastore
        /// </summary>
        /// <param name="filePath">The file path of the ROSE directory</param>
        /// <param name="allAccounts">The list of accounts to save</param>
        /// <param name="runAdAdmin">Whether or not to run as admin</param>
        void SaveAccountData(string filePath, bool runAdAdmin, List<Account> allAccounts);
    }
}
