//
// FILE     : AccountDisplay.xaml.cs
// PROJECT  : AruaROSE Login Manager
// AUTHOR   : xHergz
// DATE     : 2021-02-18
// 

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

using AruaRoseLoginManager.Data;
using AruaRoseLoginManager.Enum;
using AruaRoseLoginManager.Helpers;

namespace AruaRoseLoginManager.Controls
{
    /// <summary>
    /// Interaction logic for AccountDisplay.xaml
    /// </summary>
    public partial class AccountDisplay : UserControl, IAccountDisplay
    {
        /// <summary>
        /// List of emblem images
        /// </summary>
        private List<BitmapImage> _emblems;

        /// <summary>
        /// The current emblem index to use for the next account
        /// </summary>
        private int _currentEmblemIndex;

        /// <summary>
        /// The panel mode to determine which screen is being displayed
        /// </summary>
        private PanelMode _accountMode = PanelMode.Select;

        /// <summary>
        /// Constructor
        /// </summary>
        public AccountDisplay()
        {
            InitializeComponent();
            _currentEmblemIndex = 0;
            LoadEmblems();
        }

        /// <summary>
        /// Event raised when one of the Login buttons are pressed and the account has all the required info
        /// </summary>
        public event EventHandler<LoginEventArgs> LoginRequest;

        /// <summary>
        /// Event raised when one of the Login buttons are pressed and the account has no password
        /// </summary>
        public event EventHandler<LoginWithPassEventArgs> PromptedLoginRequest;

        /// <summary>
        /// Event raised when the user adds a new account
        /// </summary>
        public event EventHandler<DataEventArgs<Account>> AddRequest;

        /// <summary>
        /// Event raised when the user deletes an account
        /// </summary>
        public event EventHandler<ListEventArgs> DeleteRequest;

        /// <summary>
        /// Event raised when the user edits an account
        /// </summary>
        public event EventHandler<ListEventArgs> EditRequest;

        /// <summary>
        /// Event raised when the user updates an account
        /// </summary>
        public event EventHandler<DataEventArgs<Account>> UpdateRequest;

        /// <summary>
        /// Event raised when the user moves an account
        /// </summary>
        public event EventHandler<MoveListItemEventArgs> MoveRequest;

        /// <summary>
        /// Adds an account to the display
        /// </summary>
        /// <param name="newItem">The new account information</param>
        public void AddToDisplay(Account newItem)
        {
            ListDisplay newDisplay = new ListDisplay(
                _accountStackPanel.Children.Count,
                newItem,
                GetCurrentEmblem()
            );
            newDisplay.Login += AccountDisplay_LoginRequest;
            newDisplay.EditListItem += AccountDisplay_EditRequest;
            newDisplay.MoveListItem += AccountDisplay_MoveRequest;
            newDisplay.DeleteListItem += AccountDisplay_DeleteRequest;
            _accountStackPanel.Children.Add(newDisplay);
            for (int i = 0; i < _accountStackPanel.Children.Count; i++)
            {
                ListDisplay display = (ListDisplay)_accountStackPanel.Children[i];
                display.UpdateDisplay(i, _accountStackPanel.Children.Count);
            }
        }

        /// <summary>
        /// Removes all accounts from the display
        /// </summary>
        public void ClearDisplay()
        {
            _currentEmblemIndex = 0;
            _accountStackPanel.Children.Clear();
        }

        /// <summary>
        /// Prompts the user to edit an account by filling in the known data
        /// </summary>
        /// <param name="info"></param>
        public void Prompt(Account info)
        {
            _accountForm.PopulateFields(info);
            SwitchPanels(PanelMode.Edit);
        }

        /// <summary>
        /// Prompts the user for their password for an account
        /// </summary>
        /// <param name="username">The username to prompt for</param>
        /// <param name="serverId">The server they are tring to log into</param>
        public void PromptForPassword(string username, Server serverId)
        {
            SwitchPanels(PanelMode.Login);
            _loginForm.ClearFields();
            _loginForm.PopulateFields(username, serverId);
        }

        /// <summary>
        /// Loads all the emblems in the emblem directory. This will start at emblem1.png and load incrementally until it can't find
        /// a file. i.e. it will load emblem1.png, emblem2.png, emblem3.png and then stop if emblem4.png is not found.
        /// </summary>
        private void LoadEmblems()
        {
            int currentEmblem = 1;
            string emblemDirectory = "Emblems";
            string emblemPrefix = "emblem";
            string emblemExtension = ".png";

            _emblems = new List<BitmapImage>();
            while (File.Exists($"./{emblemDirectory}/{emblemPrefix}{currentEmblem}{emblemExtension}"))
            {
                string iconPath = System.IO.Path.Combine(Environment.CurrentDirectory, emblemDirectory, $"{emblemPrefix}{currentEmblem}{emblemExtension}");
                _emblems.Add(new BitmapImage(new Uri(iconPath)));
                ++currentEmblem;
            }
        }

        /// <summary>
        /// Retrieves the current emblem from the list of loaded images.
        /// </summary>
        /// <returns>The current emblem</returns>
        private BitmapImage GetCurrentEmblem()
        {
            BitmapImage currentEmblem = _emblems.ElementAt(_currentEmblemIndex);
            _currentEmblemIndex++;
            if (_currentEmblemIndex >= _emblems.Count)
            {
                _currentEmblemIndex = 0;
            }
            return currentEmblem;
        }

        /// <summary>
        /// Changes which panel is visible currently
        /// </summary>
        /// <param name="newMode">The panel mode to change to</param>
        public void SwitchPanels(PanelMode newMode)
        {
            _addAccountButton.Visibility = Visibility.Hidden;
            _accountStackPanel.Visibility = Visibility.Hidden;
            _accountDisplayScrollViewer.Visibility = Visibility.Hidden;
            _accountForm.Visibility = Visibility.Hidden;
            _loginForm.Visibility = Visibility.Hidden;
            _accountMode = newMode;
            switch (newMode)
            {
                case PanelMode.New:
                    _accountForm.ClearFields();
                    _accountForm.Visibility = Visibility.Visible;
                    _accountForm.FocusPrimary();
                    break;
                case PanelMode.Edit:
                    _accountForm.Visibility = Visibility.Visible;
                    break;
                case PanelMode.Login:
                    _loginForm.Visibility = Visibility.Visible;
                    _loginForm.FocusPrimary();
                    break;
                case PanelMode.Select:
                default:
                    _addAccountButton.Visibility = Visibility.Visible;
                    _accountStackPanel.Visibility = Visibility.Visible;
                    _accountDisplayScrollViewer.Visibility = Visibility.Visible;
                    break;
            }
        }

        /// <summary>
        /// Event handler for the New Account button
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event args</param>
        private void AddAccountButton_Click(object sender, RoutedEventArgs e)
        {
            SwitchPanels(PanelMode.New);
        }

        /// <summary>
        /// Event handler for clicking on one of the login buttons
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event args</param>
        private void AccountDisplay_LoginRequest(object sender, LoginEventArgs e)
        {
            if (sender != null && LoginRequest != null)
            {
                LoginRequest(sender, e);
            }
        }

        /// <summary>
        /// Event handler for clicking on the edit account button
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event args</param>
        private void AccountDisplay_EditRequest(object sender, ListEventArgs e)
        {
            if (sender != null && EditRequest != null)
            {
                EditRequest(sender, e);
            }
        }

        /// <summary>
        /// Event handler for clicking on one of the move account buttons
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event args</param>
        private void AccountDisplay_MoveRequest(object sender, MoveListItemEventArgs e)
        {
            if (sender != null && MoveRequest != null)
            {
                MoveRequest(sender, e);
            }
        }

        /// <summary>
        /// Event handler for clicking on the delete account button
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event args</param>
        private void AccountDisplay_DeleteRequest(object sender, ListEventArgs e)
        {
            if (sender != null && DeleteRequest != null)
            {
                DeleteRequest(sender, e);
            }
        }

        /// <summary>
        /// Event handler for clicking on the cancel button while entering account details
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event args</param>
        private void AccountForm_Cancel(object sender, EventArgs e)
        {
            SwitchPanels(PanelMode.Select);
        }

        /// <summary>
        /// Event handler for clicking on the save button while entering account details
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event args</param>
        private void AccountForm_SaveAccount(object sender, DataEventArgs<Account> e)
        {
            EventHandler<DataEventArgs<Account>> actionHandler = _accountMode == PanelMode.New
                ? AddRequest
                : UpdateRequest;
            if (sender != null && actionHandler != null)
            {
                actionHandler(sender, e);
                SwitchPanels(PanelMode.Select);
            }
        }

        /// <summary>
        /// Event handler for clicking the login button on the password prompt screen
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event args</param>
        private void LoginForm_Login(object sender, LoginWithPassEventArgs e)
        {
            if (sender != null && PromptedLoginRequest != null)
            {
                PromptedLoginRequest(sender, e);
                SwitchPanels(PanelMode.Select);
            } 
        }
    }
}
