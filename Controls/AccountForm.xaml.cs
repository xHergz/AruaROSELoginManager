using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

using AruaRoseLoginManager.Data;

namespace AruaRoseLoginManager.Controls
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class AccountForm : UserControl
    {
        public EventHandler<AccountEventArgs> SaveAccount;

        public AccountForm()
        {
            InitializeComponent();
        }

        private void SaveAccountButton_Click(object sender, RoutedEventArgs e)
        {
            if (!IsUsernameValid())
            {
                return;
            }

            if (sender != null && SaveAccount != null)
            {
                AccountEventArgs args = new AccountEventArgs()
                {
                    Account = new Account(
                        _usernameTextBox.Text,
                        _passwordTextBox.Text,
                        _descriptionTextBox.Text,
                        new List<string>()
                        {
                            _characterOneTextBox.Text,
                            _characterTwoTextBox.Text,
                            _characterThreeTextBox.Text,
                            _characterFourTextBox.Text,
                            _characterFiveTextBox.Text
                        }
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
