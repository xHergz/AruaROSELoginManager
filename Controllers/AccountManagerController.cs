//
// FILE     : AccountManagerController.cs
// PROJECT  : AruaROSE Login Manager
// AUTHOR   : xHergz
// DATE     : 2017-09-30
// 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

using AruaRoseLoginManager.Controls;
using AruaROSELoginManager.DAL;
using AruaROSELoginManager.Data;
using AruaROSELoginManager.Enum;

namespace AruaROSELoginManager.Controllers
{
    public class AccountManagerController
    {
        /// <summary>
        /// The view panel for the account manager
        /// </summary>
        private ManagerPanel _viewPanel;

        /// <summary>
        /// The account datastore to access the accounts
        /// </summary>
        private IAccountDatastore _datastore;

        /// <summary>
        /// The list of all the accounts
        /// </summary>
        private List<Account> _accountList;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="panel">The view panel to reference</param>
        public AccountManagerController(ManagerPanel panel)
        {
            _viewPanel = panel;
            _datastore = new XmlAccountDatastore();
            _accountList = new List<Account>();
        }

        /// <summary>
        /// Initializes the event handlers and loads the data
        /// </summary>
        /// <returns>True on success</returns>
        public bool Initialize()
        {
            //Subscribe to the events
            _viewPanel.LoginRequest += AccountManagerPanel_LoginRequest;
            _viewPanel.AddAccountRequest += AccountManagerPanel_AddAccountRequest;

            //Load the existing accounts
            _accountList = _datastore.GetAllAccounts();
            RefreshList();

            _viewPanel.SetRoseFolderPath(_datastore.GetFilePath());
            _viewPanel.SetRunAsAdminCheckbox(_datastore.GetRunAsAdmin());

            return true;
        }

        /// <summary>
        /// Saves the data when closing the application
        /// </summary>
        public void Shutdown()
        {
            IEnumerable<string> orderedAccountList = _viewPanel.GetAllAccountNames();
            List<Account> saveList = new List<Account>();
            foreach(string account in orderedAccountList)
            {
                Account foundAccount = _accountList.FirstOrDefault(a => a.Username == account);
                if (foundAccount != null)
                {
                    saveList.Add(foundAccount);
                }
            }

            _datastore.SaveAccountData(_viewPanel.RoseFolderPath, _viewPanel.RunAsAdmin, saveList);
        }

        /// <summary>
        /// Refreshes the list
        /// </summary>
        private void RefreshList()
        {
            _accountList.ForEach(a => _viewPanel.AddAccount(a.Username, a.Password));
        }

        /// <summary>
        /// Opens a ROSE client with the given credentials to log in
        /// </summary>
        /// <param name="username">The username to log in</param>
        /// <param name="password">The password to use</param>
        private void AccountManagerPanel_LoginRequest(object sender, AccountLoginEventArgs e)
        {
            //Look up the password
            string password = _accountList.FirstOrDefault(a => a.Username == e.AccountName).Password;

            //Check if the passwords empty
            if (password == string.Empty)
            {
                //Prompt the user for the password
                password = _viewPanel.PromptForPassword(e.AccountName);
                if (password == string.Empty)
                {
                    //If the password is still empty, just return
                    return;
                }
            }

            //Start a thread for the new login process
            Thread loginThread = new Thread(() => LoginAccountThread(e.AccountName, password, e.ServerId, e.FilePath, e.RunAsAdmin));
            loginThread.Start();
        }

        /// <summary>
        /// Opens the rose client and logs in an account
        /// </summary>
        /// <param name="username">The user name to use</param>
        /// <param name="password">The password hash to use</param>
        /// <param name="roseFilePath">The path to the rose folder</param>
        /// <param name="runAsAdmin">Whether we should run as admin or not</param>
        private void LoginAccountThread(string username, string password, Server serverId, string roseFilePath, bool runAsAdmin)
        {
            //Start the process for TRose.exe
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.FileName = @"TRose.exe";
            if (roseFilePath == string.Empty)
            {
                _viewPanel.ShowMessageBox("Please select your AruaROSE folder below!");
            }
            else
            {
                startInfo.WorkingDirectory = roseFilePath;
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                startInfo.Arguments = "_account " + username + " _passwordMD5 " + password + " _server " + serverId.ToString("D") + " _channel 1";
                if (runAsAdmin)
                {
                    startInfo.Verb = "runas";
                }
                process.StartInfo = startInfo;
                try
                {
                    process.Start();
                }
                catch(Exception ex)
                {
                    _viewPanel.ShowMessageBox(ex.Message);
                }
            }
        }

        /// <summary>
        /// Handles the event raised when adding an account
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event args</param>
        private void AccountManagerPanel_AddAccountRequest(object sender, EventArgs e)
        {
            if (sender != null)
            {
                string accountName = string.Empty;
                string password = string.Empty;

                _viewPanel.PromptForAccountDetails(out accountName, out password);

                if (accountName != string.Empty)
                {
                    Account newAccount = new Account(accountName, password);
                    _accountList.Add(newAccount);
                    _viewPanel.AddAccount(accountName, password);
                }
            }
        }
    }
}
