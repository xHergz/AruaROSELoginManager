//
// FILE     : AccountInfoWindow.cs
// PROJECT  : AruaROSE Login Manager
// AUTHOR   : xHergz
// DATE     : 2017-05-23
// 

using System;
using System.Windows.Forms;

using AruaROSELoginManager.Data;
using AruaROSELoginManager.Helpers;

namespace AruaROSELoginManager
{
    /// <summary>
    /// Creates a window to enter account information
    /// </summary>
    public partial class AccountInfoWindow : Form
    {
        /// <summary>
        /// The information entered in the window
        /// </summary>
        private Account _enteredAccount;

        /// <summary>
        /// Constants to change the initial textbox in focus when the window opens
        /// </summary>
        public enum ACCOUNT_INFO_FOCUS
        {
            Username,
            Password
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public AccountInfoWindow()
        {
            InitializeComponent();
            _enteredAccount = new Account("", "");
            this.ActiveControl = _usernameTextBox;
        }

        /// <summary>
        /// Constructor that sets the text box focus
        /// </summary>
        /// <param name="focus">The text box to focus on</param>
        public AccountInfoWindow(ACCOUNT_INFO_FOCUS focus)
        {
            InitializeComponent();
            _enteredAccount = new Account("", "");
            if(focus == ACCOUNT_INFO_FOCUS.Username)
            {
                this.ActiveControl = _usernameTextBox;
            }
            else
            {
                this.ActiveControl = _passwordTextBox;
            }            
        }

        /// <summary>
        /// Constructor that fills in a username and focuses on the password text box
        /// </summary>
        /// <param name="username">The username to fill in</param>
        public AccountInfoWindow(string username)
        {
            InitializeComponent();

            _enteredAccount = new Account(username, string.Empty);

            _usernameTextBox.Text = username;

            this.ActiveControl = _passwordTextBox;
        }

        /// <summary>
        /// Gets the Account object with the entered info
        /// </summary>
        public Account EnteredAccount
        {
            get { return _enteredAccount; }
        }

        /// <summary>
        /// Sets the entered account info when the okay button is clicked
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        private void _okayButton_Click(object sender, EventArgs e)
        {
            //Set the account info
            _enteredAccount.Username = _usernameTextBox.Text;
            if(_passwordTextBox.Text == string.Empty)
            {
                _enteredAccount.Password = string.Empty;
            }
            else
            {
                _enteredAccount.Password = MD5Generator.GetMd5Hash(_passwordTextBox.Text);
            }
            
            Close();
        }

        /// <summary>
        /// Clears the entered account info when the cancel button is clicked
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        private void _cancelButton_Click(object sender, EventArgs e)
        {
            //Clear the account info
            _enteredAccount.Username = "";
            _enteredAccount.Password = "";
            Close();
        }
    }
}
