//
// FILE     : LoginForm.xaml.cs
// PROJECT  : AruaROSE Login Manager
// AUTHOR   : xHergz
// DATE     : 2021-02-18
//

using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

using AruaRoseLoginManager.Data;
using AruaRoseLoginManager.Enum;

namespace AruaRoseLoginManager.Controls
{
    /// <summary>
    /// Interaction logic for LoginForm.xaml
    /// </summary>
    public partial class LoginForm : UserControl
    {
        /// <summary>
        /// The server being logged in to
        /// </summary>
        private Server _serverId;

        /// <summary>
        /// Event to raise when the cancel button is clicked
        /// </summary>
        [Browsable(true)]
        public event EventHandler Cancel;

        /// <summary>
        /// Event to raise when the login button is clicked
        /// </summary>
        [Browsable(true)]
        public event EventHandler<LoginWithPassEventArgs> Login;

        /// <summary>
        /// Constructor
        /// </summary>
        public LoginForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Populates the form
        /// </summary>
        /// <param name="username">The username to log in with</param>
        /// <param name="serverId">The server to log in to</param>
        public void PopulateFields(string username, Server serverId)
        {
            _usernameTextBox.Text = username;
            _usernameTextBox.IsEnabled = false;
            _serverId = serverId;
        }

        /// <summary>
        /// Clear the form fields
        /// </summary>
        public void ClearFields()
        {
            _usernameTextBox.Clear();
            _passwordTextBox.Clear();
        }

        /// <summary>
        /// Focus on the primary input (password)
        /// </summary>
        public void FocusPrimary()
        {
            _passwordTextBox.Focus();
        }

        /// <summary>
        /// Event to handle the cancel button being clicked
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event args</param>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            if (sender != null && Cancel != null)
            {
                Cancel(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Event to handle the login button being clicked
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event args</param>
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender != null && Login != null)
            {
                LoginWithPassEventArgs args = new LoginWithPassEventArgs()
                {
                    Id = _usernameTextBox.Text,
                    ServerId = _serverId,
                    Password = _passwordTextBox.Password
                };
                Login(this, args);
            }
        }
    }
}
