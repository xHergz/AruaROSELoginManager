//
// FILE     : AccountForm.xaml.cs
// PROJECT  : AruaROSE Login Manager
// AUTHOR   : xHergz
// DATE     : 2021-02-18
// 

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

using AruaRoseLoginManager.Data;
using AruaRoseLoginManager.Helpers;

namespace AruaRoseLoginManager.Controls
{
    /// <summary>
    /// Interaction logic for AccountForm.xaml
    /// </summary>
    public partial class AccountForm : UserControl
    {
        /// <summary>
        /// List of textboxes for character names
        /// </summary>
        private List<TextBox> _characterTextBoxes;

        /// <summary>
        /// Event to raise when clicking cancel
        /// </summary>
        [Browsable(true)]
        public event EventHandler Cancel;

        /// <summary>
        /// Event to raise when clicking save
        /// </summary>
        [Browsable(true)]
        public event EventHandler<DataEventArgs<Account>> SaveAccount;

        /// <summary>
        /// Constructor
        /// </summary>
        public AccountForm()
        {
            InitializeComponent();
            _characterTextBoxes = new List<TextBox>()
            {
                _characterOneTextBox,
                _characterTwoTextBox,
                _characterThreeTextBox,
                _characterFourTextBox,
                _characterFiveTextBox
            };
        }

        /// <summary>
        /// Populate the form fields
        /// </summary>
        /// <param name="account">Account info to populate with</param>
        public void PopulateFields(Account account)
        {
            _usernameTextBox.Text = account.Username;
            _usernameTextBox.IsEnabled = false;
            _passwordTextBox.Clear();
            _reinputPasswordTip.Visibility = Visibility.Visible;
            _descriptionTextBox.Text = account.Description;
            for(short i = 0; i < account.Characters.Count && i < _characterTextBoxes.Count; i++)
            {
                _characterTextBoxes[i].Text = account.Characters[i];
            }
        }

        /// <summary>
        /// Clear the form fields
        /// </summary>
        public void ClearFields()
        {
            _usernameTextBox.Clear();
            _usernameTextBox.IsEnabled = true;
            _passwordTextBox.Clear();
            _reinputPasswordTip.Visibility = Visibility.Hidden;
            _descriptionTextBox.Clear();
            foreach (TextBox textbox in _characterTextBoxes)
            {
                textbox.Clear();
            }
        }

        /// <summary>
        /// Focus on the primary input (username)
        /// </summary>
        public void FocusPrimary()
        {
            _usernameTextBox.Focus();
        }

        /// <summary>
        /// Event to handle clicking the cancel button
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
        /// Event to handle clicking the save button
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event args</param>
        private void SaveAccountButton_Click(object sender, RoutedEventArgs e)
        {
            if (!IsUsernameValid())
            {
                return;
            }

            if (sender != null && SaveAccount != null)
            {
                List<string> characters = new List<string>();
                foreach(TextBox charTextBox in _characterTextBoxes)
                {
                    if (!string.IsNullOrWhiteSpace(charTextBox.Text))
                    {
                        characters.Add(charTextBox.Text);
                    }
                }

                string passwordHash = string.IsNullOrWhiteSpace(_passwordTextBox.Password)
                    ? string.Empty
                    : MD5Generator.GetMd5Hash(_passwordTextBox.Password);

                DataEventArgs<Account> args = new DataEventArgs<Account>()
                {
                    Data = new Account(
                        _usernameTextBox.Text,
                        passwordHash,
                        _descriptionTextBox.Text,
                        characters
                    )
                };
                SaveAccount(this, args);
            }
        }

        /// <summary>
        /// Checks if the username is valid during input to display an error
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event args</param>
        private void _usernameError_TextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            IsUsernameValid();
        }

        /// <summary>
        /// Validates usernames. Valid usernames are not empty and contain no whitespace.
        /// </summary>
        /// <returns></returns>
        private bool IsUsernameValid()
        {
            if (string.IsNullOrWhiteSpace(_usernameTextBox.Text))
            {
                _usernameError.Visibility = Visibility.Visible;
                return false;
            }

            _usernameError.Visibility = Visibility.Hidden;
            return true;
        }
    }
}
