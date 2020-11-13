using AruaRoseLoginManager.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AruaRoseLoginManager.Controls
{
    /// <summary>
    /// Interaction logic for PartyForm.xaml
    /// </summary>
    public partial class PartyForm : UserControl
    {
        private List<string> _selectedAccounts;

        private ObservableCollection<string> _availableAccounts;

        [Browsable(true)]
        public event EventHandler Cancel;

        [Browsable(true)]
        public event EventHandler<DataEventArgs<Party>> SaveParty;

        public PartyForm()
        {
            InitializeComponent();
            _selectedAccounts = new List<string>();
        }

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

        public void PopulateAccounts(IEnumerable<string> availableAccounts)
        {
            _availableAccounts = new ObservableCollection<string>(availableAccounts.Where(x => !_selectedAccounts.Any(account => account == x)));
            _accountComboBox.ItemsSource = _availableAccounts;
        }

        public void ClearFields()
        {
            _partyNameTextBox.Clear();
            _descriptionTextBox.Clear();
            _selectedAccounts.Clear();
            _partyListStackPanel.Children.Clear();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            if (sender != null && Cancel != null)
            {
                Cancel(this, EventArgs.Empty);
            }
        }

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
                        _selectedAccounts,
                        _descriptionTextBox.Text
                    )
                };
                SaveParty(this, args);
            }
        }

        private void _partyNameError_TextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            IsPartyNameValid();
        }

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

        private void AddAccountToList(string account)
        {
            BasicListDisplay display = new BasicListDisplay(account, account);
            display.DeleteListItem += RemoveAccountFromList;
            _partyListStackPanel.Children.Add(display);
        }

        private void RemoveAccountFromList(object sender, ListEventArgs e)
        {
            _selectedAccounts.Remove(e.Id);
            _partyListStackPanel.Children.Clear();
            foreach(string account in _selectedAccounts)
            {
                AddAccountToList(account);
            }
        }

        private void AddAccountButton_Click(object sender, RoutedEventArgs e)
        {
            string selectedAccount = _accountComboBox.SelectedItem.ToString();
            _selectedAccounts.Add(selectedAccount);
            _availableAccounts.Remove(selectedAccount);
            AddAccountToList(selectedAccount);
        }
    }
}
