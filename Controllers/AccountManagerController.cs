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
        /// The list of all the parties
        /// </summary>
        private Dictionary<string, Party> _partyList;

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
            _viewPanel.AccountDisplay.LoginRequest += AccountManagerPanel_LoginRequest;
            _viewPanel.AccountDisplay.PromptedLoginRequest += AccountManagerPanel_PromptedLoginRequest;
            _viewPanel.AccountDisplay.AddRequest += AccountManagerPanel_AddAccountRequest;
            _viewPanel.AccountDisplay.EditRequest += AccountManagerPanel_EditAccountRequest;
            _viewPanel.AccountDisplay.UpdateRequest += AccountManagerPanel_UpdateAccountRequest;
            _viewPanel.AccountDisplay.MoveRequest += AccountManagerPanel_MoveAccountRequest;
            _viewPanel.AccountDisplay.DeleteRequest += AccountManagerPanel_DeleteAccountRequest;
            _viewPanel.PartyDisplay.LoginRequest += AccountManagerPanel_LoginPartyRequest;
            _viewPanel.PartyDisplay.NewRequest += AccountManagerPanel_NewPartyRequest;
            _viewPanel.PartyDisplay.AddRequest += AccountManagerPanel_AddPartyRequest;
            _viewPanel.PartyDisplay.EditRequest += AccountManagerPanel_EditPartyRequest;
            _viewPanel.PartyDisplay.UpdateRequest += AccountManagerPanel_UpdatePartyRequest;
            _viewPanel.PartyDisplay.MoveRequest += AccountManagerPanel_MovePartyRequest;
            _viewPanel.PartyDisplay.DeleteRequest += AccountManagerPanel_DeletePartyRequest;

            //Load the existing accounts
            _accountList = _datastore.GetAllAccounts().ToDictionary(account => account.Username);
            _partyList = _datastore.GetAllParties().ToDictionary(party => party.Name);
            RefreshAccountList();
            RefreshPartyList();

            _viewPanel.RoseFolderPath = _datastore.GetFilePath();
            _viewPanel.RunAsAdmin = _datastore.GetRunAsAdmin();
            _viewPanel.Size = _datastore.GetWindowSize();

            return true;
        }

        /// <summary>
        /// Saves the data when closing the application
        /// </summary>
        public void Shutdown()
        {
            _datastore.SaveManagerData(
                _viewPanel.RoseFolderPath,
                _viewPanel.RunAsAdmin,
                _viewPanel.Size,
                _accountList.Values.ToList(),
                _partyList.Values.ToList()
            );
        }

        /// <summary>
        /// Refreshes the account list
        /// </summary>
        private void RefreshAccountList()
        {
            _viewPanel.AccountDisplay.ClearDisplay();
            foreach (Account account in _accountList.Values) {
                _viewPanel.AccountDisplay.AddToDisplay(account);
            };
        }

        /// <summary>
        /// Refreshes the party list
        /// </summary>
        private void RefreshPartyList()
        {
            _viewPanel.PartyDisplay.ClearDisplay();
            foreach(Party party in _partyList.Values)
            {
                _viewPanel.PartyDisplay.AddToDisplay(party);
            }
        }

        /// <summary>
        /// Opens a ROSE client with the given credentials to log in
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event args</param>
        private void AccountManagerPanel_LoginRequest(object sender, LoginEventArgs e)
        {
            LoginAccount(_accountList[e.Id], e.ServerId, _viewPanel.RoseFolderPath, _viewPanel.RunAsAdmin);
        }

        /// <summary>
        /// Opens a ROSE client with the credentials given when the user enters the password
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event args</param>
        private void AccountManagerPanel_PromptedLoginRequest(object sender, LoginWithPassEventArgs e)
        {
            string passwordHash = MD5Generator.GetMd5Hash(e.Password);
            Account account = new Account(e.Id, passwordHash);
            LoginAccount(account, e.ServerId, _viewPanel.RoseFolderPath, _viewPanel.RunAsAdmin);
        }

        /// <summary>
        /// Checks if the required information is there before starting a thread to open the ROSE client
        /// </summary>
        /// <param name="account">The account information to log in</param>
        /// <param name="serverId">The server to select</param>
        /// <param name="roseFolderPath">Path to the folder containing the rose client</param>
        /// <param name="runAsAdmin">Whether to run as admin or not</param>
        private void LoginAccount(Account account, Server serverId, string roseFolderPath, bool runAsAdmin)
        {
            string passwordHash = account.PasswordHash;
            if (string.IsNullOrWhiteSpace(passwordHash))
            {
                _viewPanel.AccountDisplay.PromptForPassword(account.Username, serverId);
                return;
            }
            //Start a thread for the new login process
            Thread loginThread = new Thread(() => LoginAccountThread(
                account.Username,
                account.PasswordHash,
                serverId,
                roseFolderPath,
                runAsAdmin
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
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo
            {
                FileName = @"TRose.exe"
            };
            if (roseFilePath == string.Empty)
            {
                _viewPanel.ShowMessageBox("Please select your AruaROSE folder in the Options tab.");
                return;
            }
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
            catch (Exception ex)
            {
                _viewPanel.ShowMessageBox(ex.Message);
            }
        }

        /// <summary>
        /// Event handler for adding an account
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event args</param>
        private void AccountManagerPanel_AddAccountRequest(object sender, DataEventArgs<Account> e)
        {
            if (sender != null)
            {
                if (!string.IsNullOrWhiteSpace(e.Data.Username))
                {
                    _accountList.Add(e.Data.Username, e.Data);
                    _viewPanel.AccountDisplay.AddToDisplay(e.Data);
                }
            }
        }

        /// <summary>
        /// Event handler for editting an account
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event args</param>
        private void AccountManagerPanel_EditAccountRequest(object sender, ListEventArgs e)
        {
            if (sender != null && _accountList.ContainsKey(e.Id))
            {
                _viewPanel.AccountDisplay.Prompt(_accountList[e.Id]);
            }
        }

        /// <summary>
        /// Event handler for an account
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event args</param>
        private void AccountManagerPanel_UpdateAccountRequest(object sender, DataEventArgs<Account> e)
        {
            if (
                sender != null
                && !string.IsNullOrWhiteSpace(e.Data.Username)
                && _accountList.ContainsKey(e.Data.Username)
            )
            {
                _accountList[e.Data.Username] = e.Data;
                RefreshAccountList();
            }
        }

        /// <summary>
        /// Event handler for moving an account
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event args</param>
        private void AccountManagerPanel_MoveAccountRequest(object sender, MoveListItemEventArgs e)
        {
            List<Account> orderedList = _accountList.Values.ToList();
            Account accountToMove = orderedList.Find(account => account.Username == e.Id);
            int currentIndex = orderedList.IndexOf(accountToMove);
            if (sender != null && currentIndex != -1)
            {
                int newIndex = e.Direction == MovementDirection.Up
                    ? currentIndex - 1
                    : currentIndex + 1;
                orderedList.RemoveAt(currentIndex);
                orderedList.Insert(newIndex, accountToMove);
                _accountList = orderedList.ToDictionary(account => account.Username);
                RefreshAccountList();
            }
        }

        /// <summary>
        /// Event handler for deleting an account
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event args</param>
        private void AccountManagerPanel_DeleteAccountRequest(object sender, ListEventArgs e)
        {
            if (sender != null)
            {
                _accountList.Remove(e.Id);
                List<Party> affectedParties = _partyList.Values.Where(x => x.Accounts.Contains(e.Id)).ToList();
                foreach (Party party in affectedParties)
                {
                    _partyList.Remove(party.Name);
                }
                RefreshAccountList();
                RefreshPartyList();
            }
        }

        /// <summary>
        /// Event handler for logging in a party
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event args</param>
        private void AccountManagerPanel_LoginPartyRequest(object sender, LoginEventArgs e)
        {
            Party party = _partyList[e.Id];
            foreach(string account in party.Accounts)
            {
                LoginAccount(_accountList[account], e.ServerId, _viewPanel.RoseFolderPath, _viewPanel.RunAsAdmin);
            }
        }

        /// <summary>
        /// Event handler for prompting for a new party
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event args</param>
        private void AccountManagerPanel_NewPartyRequest(object sender, EventArgs e)
        {
            if (sender != null)
            {
                IEnumerable<string> accounts = _accountList.Values
                    .Where(x => !string.IsNullOrWhiteSpace(x.PasswordHash))
                    .Select(x => x.Username);
                _viewPanel.PartyDisplay.Prompt(accounts);
            }
        }

        /// <summary>
        /// Event handler for adding a new party
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event args</param>
        private void AccountManagerPanel_AddPartyRequest(object sender, DataEventArgs<Party> e)
        {
            if (sender != null)
            {
                if (!string.IsNullOrWhiteSpace(e.Data.Name))
                {
                    _partyList.Add(e.Data.Name, e.Data);
                    _viewPanel.PartyDisplay.AddToDisplay(e.Data);
                }
            }
        }

        /// <summary>
        /// Event handler for editing a party
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event args</param>
        private void AccountManagerPanel_EditPartyRequest(object sender, ListEventArgs e)
        {
            if (sender != null && _partyList.ContainsKey(e.Id))
            {
                IEnumerable<string> accounts = _accountList.Values
                    .Where(x => !string.IsNullOrWhiteSpace(x.PasswordHash))
                    .Select(x => x.Username);
                _viewPanel.PartyDisplay.Prompt(accounts, _partyList[e.Id]);
            }
        }

        /// <summary>
        /// Event handler for updating a party
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event args</param>
        private void AccountManagerPanel_UpdatePartyRequest(object sender, DataEventArgs<Party> e)
        {
            if (
                sender != null
                && !string.IsNullOrWhiteSpace(e.Data.Name)
                && _partyList.ContainsKey(e.Data.Name)
            )
            {
                _partyList[e.Data.Name] = e.Data;
                RefreshPartyList();
            }
        }

        /// <summary>
        /// Event handler for moving a party
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event args</param>
        private void AccountManagerPanel_MovePartyRequest(object sender, MoveListItemEventArgs e)
        {
            List<Party> orderedList = _partyList.Values.ToList();
            Party partyToMove = orderedList.Find(party => party.Name == e.Id);
            int currentIndex = orderedList.IndexOf(partyToMove);
            if (sender != null && currentIndex != -1)
            {
                int newIndex = e.Direction == MovementDirection.Up
                    ? currentIndex - 1
                    : currentIndex + 1;
                orderedList.RemoveAt(currentIndex);
                orderedList.Insert(newIndex, partyToMove);
                _partyList = orderedList.ToDictionary(party => party.Name);
                RefreshPartyList();
            }
        }

        /// <summary>
        /// Event handler for deleting a party
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event args</param>
        private void AccountManagerPanel_DeletePartyRequest(object sender, ListEventArgs e)
        {
            if (sender != null)
            {
                _partyList.Remove(e.Id);
                RefreshPartyList();
            }
        }
    }
}
