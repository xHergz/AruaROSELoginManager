//
// FILE     : PartyForm.xaml.cs
// PROJECT  : AruaROSE Login Manager
// AUTHOR   : xHergz
// DATE     : 2021-02-18
//

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

using AruaRoseLoginManager.Data;

namespace AruaRoseLoginManager.Controls
{
    /// <summary>
    /// Interaction logic for PartyForm.xaml
    /// </summary>
    public partial class PartyForm : UserControl
    {
        /// <summary>
        /// The list of currently selected accounts for the party
        /// </summary>
        private List<string> _selectedAccounts;

        /// <summary>
        /// The list of all currently available accounts
        /// </summary>
        private ObservableCollection<string> _availableAccounts;

        /// <summary>
        /// Event to raise when the cancel button is clicked
        /// </summary>
        [Browsable(true)]
        public event EventHandler Cancel;

        /// <summary>
        /// Event to raise when the save button is clicked
        /// </summary>
        [Browsable(true)]
        public event EventHandler<DataEventArgs<Party>> SaveParty;

        /// <summary>
        /// Constructor
        /// </summary>
        public PartyForm()
        {
            InitializeComponent();
            _selectedAccounts = new List<string>();
        }

        /// <summary>
        /// Populate the form with the party info
        /// </summary>
        /// <param name="party">Party info</param>
        public void PopulateFields(Party party)
        {
            _partyNameTextBox.Text = party.Name;
            _partyNameTextBox.IsEnabled = false;
            _descriptionTextBox.Text = party.Description;
            foreach(string account in party.Accounts)
            {
                _selectedAccounts.Add(account);
                AddAccountToList(account);
            }
        }

        /// <summary>
        /// Populate the list of eligible accounts for the party
        /// </summary>
        /// <param name="availableAccounts">The available accounts for the party</param>
        public void PopulateAccounts(IEnumerable<string> availableAccounts)
        {
            _availableAccounts = new ObservableCollection<string>(availableAccounts.Where(x => !_selectedAccounts.Any(account => account == x)));
            _accountComboBox.ItemsSource = _availableAccounts;
        }

        /// <summary>
        /// Clears the party form fields
        /// </summary>
        public void ClearFields()
        {
            _partyNameTextBox.IsEnabled = true;
            _partyNameTextBox.Clear();
            _descriptionTextBox.Clear();
            _selectedAccounts.Clear();
            _partyListStackPanel.Children.Clear();
        }

        /// <summary>
        /// Focuses on the primary input of the form (party name)
        /// </summary>
        public void FocusPrimary()
        {
            _partyNameTextBox.Focus();
        }

        /// <summary>
        /// Event handler for clicking the cancel button
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
        /// Event handler for clicking the save button
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event args</param>
        private void SavePartyButton_Click(object sender, RoutedEventArgs e)
        {
            if (!IsPartyNameValid())
            {
                return;
            }

            if (sender != null && SaveParty != null)
            {
                DataEventArgs<Party> args = new DataEventArgs<Party>()
                {
                    Data = new Party(
                        _partyNameTextBox.Text,
                        new List<string>(_selectedAccounts),
                        _descriptionTextBox.Text
                    )
                };
                ClearFields();
                SaveParty(this, args);
            }
        }

        /// <summary>
        /// Event handler for validating the party name on input
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event args</param>
        private void _partyNameError_TextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            IsPartyNameValid();
        }

        /// <summary>
        /// Validates a party name to not be empty or have any whitespace.
        /// </summary>
        /// <returns>True if valid, false if not</returns>
        private bool IsPartyNameValid()
        {
            if (string.IsNullOrWhiteSpace(_partyNameTextBox.Text))
            {
                _partyNameError.Visibility = Visibility.Visible;
                return false;
            }
            else if (_selectedAccounts.Count < 2)
            {
                _partyNameError.Visibility = Visibility.Hidden;
                _partyMembersError.Visibility = Visibility.Visible;
                return false;
            }

            _partyMembersError.Visibility = Visibility.Hidden;
            _partyNameError.Visibility = Visibility.Hidden;
            return true;
        }

        /// <summary>
        /// Adds an account to the party's list
        /// </summary>
        /// <param name="account">Account name to add</param>
        private void AddAccountToList(string account)
        {
            BasicListDisplay display = new BasicListDisplay(account, account);
            display.DeleteListItem += RemoveAccountFromList;
            _partyListStackPanel.Children.Add(display);
        }

        /// <summary>
        /// Removes an account from the party's list
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event args</param>
        private void RemoveAccountFromList(object sender, ListEventArgs e)
        {
            _selectedAccounts.Remove(e.Id);
            _availableAccounts.Add(e.Id);
            _partyListStackPanel.Children.Clear();
            foreach(string account in _selectedAccounts)
            {
                AddAccountToList(account);
            }
        }

        /// <summary>
        /// Event handler for clicking the add to party button
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event args</param>
        private void AddAccountButton_Click(object sender, RoutedEventArgs e)
        {
            if (_accountComboBox.SelectedItem != null)
            {
                string selectedAccount = _accountComboBox.SelectedItem.ToString();
                _selectedAccounts.Add(selectedAccount);
                _availableAccounts.Remove(selectedAccount);
                AddAccountToList(selectedAccount);
            }
        }
    }
}
