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
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class AccountForm : UserControl
    {
        private List<TextBox> _characterTextBoxes;

        [Browsable(true)]
        public event EventHandler Cancel;

        [Browsable(true)]
        public event EventHandler<AccountEventArgs> SaveAccount;

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

        public void PopulateFields(Account account)
        {
            _usernameTextBox.Text = account.Username;
            _usernameTextBox.IsEnabled = false;
            _reinputPasswordTip.Visibility = Visibility.Visible;
            _descriptionTextBox.Text = account.Description;
            for(short i = 0; i < account.Characters.Count && i < _characterTextBoxes.Count; i++)
            {
                _characterTextBoxes[i].Text = account.Characters[i];
            }
        }

        public void ClearFields()
        {
            _usernameTextBox.Clear();
            _passwordTextBox.Clear();
            _reinputPasswordTip.Visibility = Visibility.Hidden;
            _descriptionTextBox.Clear();
            foreach (TextBox textbox in _characterTextBoxes)
            {
                textbox.Clear();
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            if (sender != null && Cancel != null)
            {
                Cancel(this, EventArgs.Empty);
            }
        }

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

                AccountEventArgs args = new AccountEventArgs()
                {
                    Account = new Account(
                        _usernameTextBox.Text,
                        passwordHash,
                        _descriptionTextBox.Text,
                        characters
                    )
                };
                SaveAccount(this, args);
            }
        }

        private void _usernameError_TextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            IsUsernameValid();
        }

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
