using AruaRoseLoginManager.Helpers;
using AruaRoseLoginManager.Data;
using System;
using System.Collections.Generic;
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
using AruaRoseLoginManager.Enum;
using System.IO;

namespace AruaRoseLoginManager.Controls
{
    /// <summary>
    /// Interaction logic for ManagerPanel.xaml
    /// </summary>
    public partial class ManagerPanel : UserControl, IManagerPanel
    {
        private List<BitmapImage> _emblems;

        private int _currentEmblemIndex;

        private AccountMode _accountMode = AccountMode.Select;

        public string RoseFolderPath { get; set; }

        public bool RunAsAdmin { get; set; }
        public WindowSize Size { get; set; }

        public event EventHandler<LoginEventArgs> Login;

        public event EventHandler<AccountEventArgs> AddAccount;

        public event EventHandler<AccountEventArgs> DeleteAccount;

        public event EventHandler<AccountEventArgs> UpdateAccount;

        public event EventHandler<MoveAccountEventArgs> MoveAccount;

        public event EventHandler LoginParty;

        public ManagerPanel()
        {
            InitializeComponent();
            _currentEmblemIndex = 0;
            LoadEmblems();
        }

        public void AddAccountToDisplay(Account account)
        {
            AccountDisplay newDisplay = new AccountDisplay(
                AccountStackPanel.Children.Count,
                AccountStackPanel.Children.Count + 1,
                GetCurrentEmblem(),
                account
            );
            newDisplay.LoginAccount += ManagerPanel_LoginRequest;
            newDisplay.EditAccount += AccountDisplay_EditRequest;
            newDisplay.MoveAccount += AccountDisplay_MoveRequest;
            newDisplay.DeleteAccount += AccountDisplay_DeleteRequest;
            AccountStackPanel.Children.Add(newDisplay);
            for(int i = 0; i < AccountStackPanel.Children.Count; i++)
            {
                AccountDisplay display = (AccountDisplay)AccountStackPanel.Children[i];
                display.UpdateDisplay(i, AccountStackPanel.Children.Count);
            }
        }

        public void ClearDisplay()
        {
            _currentEmblemIndex = 0;
            AccountStackPanel.Children.Clear();
        }

        public string PromptForPassword(string accountName)
        {
            throw new NotImplementedException();
        }

        public void ShowMessageBox(string message)
        {

        }

        private void LoadEmblems()
        {
            int currentEmblem = 1;
            string emblemDirectory = "Emblems";
            string emblemPrefix = "emblem";
            string emblemExtension = ".png";

            _emblems = new List<BitmapImage>();
            while (File.Exists($"./{emblemDirectory}/{emblemPrefix}{currentEmblem}{emblemExtension}"))
            {
                string iconPath = Path.Combine(Environment.CurrentDirectory, emblemDirectory, $"{emblemPrefix}{currentEmblem}{emblemExtension}");
                _emblems.Add(new BitmapImage(new Uri(iconPath)));
                ++currentEmblem;
            }
        }

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

        private void ManagerPanel_LoginRequest(object sender, LoginEventArgs e)
        {
            if (sender != null && e != null && Login != null)
            {
                e.RunAsAdmin = RunAsAdmin;
                e.FilePath = RoseFolderPath;
                Login(sender, e);
            }
        }

        private void AccountDisplay_EditRequest(object sender, AccountEventArgs e)
        {
            if (sender != null)
            {
                _accountForm.PopulateFields(e.Account);
                SwitchAccountPanels(AccountMode.Edit);
            }
        }

        private void AccountDisplay_MoveRequest(object sender, MoveAccountEventArgs e)
        {
            if (sender != null && MoveAccount != null)
            {
                MoveAccount(sender, e);
            }
        }

        private void AccountDisplay_DeleteRequest(object sender, AccountEventArgs e)
        {
            if (sender != null && DeleteAccount != null)
            {
                DeleteAccount(sender, e);
            }
        }

        private void SwitchAccountPanels(AccountMode newMode)
        {
            _addAccountButton.Visibility = Visibility.Hidden;
            AccountStackPanel.Visibility = Visibility.Hidden;
            _accountDisplayScrollViewer.Visibility = Visibility.Hidden;
            _accountForm.Visibility = Visibility.Hidden;
            _accountMode = newMode;
            switch(newMode)
            {
                case AccountMode.New:
                    _accountForm.Visibility = Visibility.Visible;
                    break;
                case AccountMode.Edit:
                    _accountForm.Visibility = Visibility.Visible;
                    break;
                case AccountMode.Login:
                    
                    break;
                case AccountMode.Select:
                default:
                    _addAccountButton.Visibility = Visibility.Visible;
                    AccountStackPanel.Visibility = Visibility.Visible;
                    _accountDisplayScrollViewer.Visibility = Visibility.Visible;
                    break;
            }
        }

        private void AddAccountButton_Click(object sender, RoutedEventArgs e)
        {
            SwitchAccountPanels(AccountMode.New);
        }

        private void AccountForm_Cancel(object sender, EventArgs e)
        {
            SwitchAccountPanels(AccountMode.Select);
        }

        private void AccountForm_SaveAccount(object sender, AccountEventArgs e)
        {
            EventHandler<AccountEventArgs> actionHandler = _accountMode == AccountMode.New
                ? AddAccount
                : UpdateAccount;
            if (sender != null && actionHandler != null)
            {
                actionHandler(sender, e);
                SwitchAccountPanels(AccountMode.Select);
            }
        }

        private void NewPartyButton_Click(object sender, RoutedEventArgs e)
        {
            LoginParty(sender, e);
        }
    }
}
