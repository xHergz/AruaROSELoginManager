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
using AruaRoseLoginManager.DAL;
using AruaRoseLoginManager.Data;
using AruaRoseLoginManager.Enum;
using AruaRoseLoginManager.Helpers;

namespace AruaRoseLoginManager.Controllers
{
    public class AccountManagerController
    {
        /// <summary>
        /// The view panel for the account manager
        /// </summary>
        private IManagerPanel _viewPanel;

        /// <summary>
        /// The account datastore to access the accounts
        /// </summary>
        private IAccountDatastore _datastore;

        /// <summary>
        /// The list of all the accounts
        /// </summary>
        private Dictionary<string, Account> _accountList;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="panel">The view panel to reference</param>
        public AccountManagerController(IManagerPanel panel)
        {
            _viewPanel = panel;
            _datastore = new XmlAccountDatastore();
            _accountList = new Dictionary<string, Account>();
        }

        /// <summary>
        /// Initializes the event handlers and loads the data
        /// </summary>
        /// <returns>True on success</returns>
        public bool Initialize()
        {
            //Subscribe to the events
            _viewPanel.Login += AccountManagerPanel_LoginRequest;
            _viewPanel.AddAccount += AccountManagerPanel_AddAccountRequest;
            _viewPanel.UpdateAccount += AccountManagerPanel_UpdateAccountRequest;

            //Load the existing accounts
            _accountList = _datastore.GetAllAccounts().ToDictionary(account => account.Username);
            RefreshList();

            _viewPanel.RoseFolderPath = _datastore.GetFilePath();
            _viewPanel.RunAsAdmin = _datastore.GetRunAsAdmin();

            return true;
        }

        /// <summary>
        /// Saves the data when closing the application
        /// </summary>
        public void Shutdown()
        {
            _datastore.SaveAccountData(
                _viewPanel.RoseFolderPath,
                _viewPanel.RunAsAdmin,
                _accountList.Values.ToList()
            );
        }

        /// <summary>
        /// Refreshes the list
        /// </summary>
        private void RefreshList()
        {
            _viewPanel.ClearDisplay();
            foreach (Account account in _accountList.Values) {
                _viewPanel.Login += AccountManagerPanel_LoginRequest;
                _viewPanel.AddAccountToDisplay(account);
            };
        }

        /// <summary>
        /// Opens a ROSE client with the given credentials to log in
        /// </summary>
        /// <param name="username">The username to log in</param>
        /// <param name="password">The password to use</param>
        private void AccountManagerPanel_LoginRequest(object sender, LoginEventArgs e)
        {
            string passwordHash = e.Account.PasswordHash;

            //Check if the passwords empty
            if (passwordHash == string.Empty)
            {
                //Prompt the user for the password
                passwordHash = _viewPanel.PromptForPassword(e.Account.Username);
                if (passwordHash == string.Empty)
                {
                    //If the password is still empty, just return
                    return;
                }
            }

            //Start a thread for the new login process
            Thread loginThread = new Thread(() => LoginAccountThread(
                e.Account.Username,
                passwordHash,
                e.ServerId,
                e.FilePath,
                e.RunAsAdmin
            ));
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
        private void AccountManagerPanel_AddAccountRequest(object sender, AccountEventArgs e)
        {
            if (sender != null)
            {
                if (!string.IsNullOrWhiteSpace(e.Account.Username))
                {
                    _accountList.Add(e.Account.Username, e.Account);
                    _viewPanel.AddAccountToDisplay(e.Account);
                }
            }
        }

        /// <summary>
        /// Handles the event raised when updating an account
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event args</param>
        private void AccountManagerPanel_UpdateAccountRequest(object sender, AccountEventArgs e)
        {
            if (
                sender != null
                && !string.IsNullOrWhiteSpace(e.Account.Username)
                && _accountList.ContainsKey(e.Account.Username)
            )
            {
                _accountList[e.Account.Username] = e.Account;
                RefreshList();
            }
        }
    }
}
