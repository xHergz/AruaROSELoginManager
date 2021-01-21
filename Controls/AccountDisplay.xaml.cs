using AruaRoseLoginManager.Data;
using AruaRoseLoginManager.Enum;
using AruaRoseLoginManager.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for AccountDisplay.xaml
    /// </summary>
    public partial class AccountDisplay : UserControl, IAccountDisplay
    {
        private List<BitmapImage> _emblems;

        private int _currentEmblemIndex;

        private PanelMode _accountMode = PanelMode.Select;

        public AccountDisplay()
        {
            InitializeComponent();

            _currentEmblemIndex = 0;

            LoadEmblems();
        }

        public event EventHandler<LoginEventArgs> LoginRequest;

        public event EventHandler<LoginWithPassEventArgs> PromptedLoginRequest;

        public event EventHandler<DataEventArgs<Account>> AddRequest;

        public event EventHandler<ListEventArgs> DeleteRequest;

        public event EventHandler<ListEventArgs> EditRequest;

        public event EventHandler<DataEventArgs<Account>> UpdateRequest;

        public event EventHandler<MoveListItemEventArgs> MoveRequest;

        public void AddToDisplay(Account newItem)
        {
            ListDisplay newDisplay = new ListDisplay(
                AccountStackPanel.Children.Count,
                newItem,
                GetCurrentEmblem()
            );
            newDisplay.Login += AccountDisplay_LoginRequest;
            newDisplay.EditListItem += AccountDisplay_EditRequest;
            newDisplay.MoveListItem += AccountDisplay_MoveRequest;
            newDisplay.DeleteListItem += AccountDisplay_DeleteRequest;
            AccountStackPanel.Children.Add(newDisplay);
            for (int i = 0; i < AccountStackPanel.Children.Count; i++)
            {
                ListDisplay display = (ListDisplay)AccountStackPanel.Children[i];
                display.UpdateDisplay(i, AccountStackPanel.Children.Count);
            }
        }

        public void ClearDisplay()
        {
            _currentEmblemIndex = 0;
            AccountStackPanel.Children.Clear();
        }

        public void Prompt(Account info)
        {
            _accountForm.PopulateFields(info);
            SwitchAccountPanels(PanelMode.Edit);
        }

        public void PromptForPassword(string username, Server serverId)
        {
            SwitchAccountPanels(PanelMode.Login);
            _loginForm.PopulateFields(username, serverId);
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
                string iconPath = System.IO.Path.Combine(Environment.CurrentDirectory, emblemDirectory, $"{emblemPrefix}{currentEmblem}{emblemExtension}");
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

        private void SwitchAccountPanels(PanelMode newMode)
        {
            _addAccountButton.Visibility = Visibility.Hidden;
            AccountStackPanel.Visibility = Visibility.Hidden;
            _accountDisplayScrollViewer.Visibility = Visibility.Hidden;
            _accountForm.Visibility = Visibility.Hidden;
            _accountMode = newMode;
            switch (newMode)
            {
                case PanelMode.New:
                    _accountForm.ClearFields();
                    _accountForm.Visibility = Visibility.Visible;
                    break;
                case PanelMode.Edit:
                    _accountForm.Visibility = Visibility.Visible;
                    break;
                case PanelMode.Login:
                    _loginForm.Visibility = Visibility.Visible;
                    break;
                case PanelMode.Select:
                default:
                    _addAccountButton.Visibility = Visibility.Visible;
                    AccountStackPanel.Visibility = Visibility.Visible;
                    _accountDisplayScrollViewer.Visibility = Visibility.Visible;
                    break;
            }
        }

        private void AddAccountButton_Click(object sender, RoutedEventArgs e)
        {
            SwitchAccountPanels(PanelMode.New);
        }

        private void AccountDisplay_LoginRequest(object sender, LoginEventArgs e)
        {
            if (sender != null && LoginRequest != null)
            {
                LoginRequest(sender, e);
            }
        }

        private void AccountDisplay_EditRequest(object sender, ListEventArgs e)
        {
            if (sender != null && EditRequest != null)
            {
                EditRequest(sender, e);
            }
        }

        private void AccountDisplay_MoveRequest(object sender, MoveListItemEventArgs e)
        {
            if (sender != null && MoveRequest != null)
            {
                MoveRequest(sender, e);
            }
        }

        private void AccountDisplay_DeleteRequest(object sender, ListEventArgs e)
        {
            if (sender != null && DeleteRequest != null)
            {
                DeleteRequest(sender, e);
            }
        }

        private void AccountForm_Cancel(object sender, EventArgs e)
        {
            SwitchAccountPanels(PanelMode.Select);
        }

        private void AccountForm_SaveAccount(object sender, DataEventArgs<Account> e)
        {
            EventHandler<DataEventArgs<Account>> actionHandler = _accountMode == PanelMode.New
                ? AddRequest
                : UpdateRequest;
            if (sender != null && actionHandler != null)
            {
                actionHandler(sender, e);
                SwitchAccountPanels(PanelMode.Select);
            }
        }

        private void LoginForm_Login(object sender, LoginWithPassEventArgs e)
        {
            if (sender != null && PromptedLoginRequest != null)
            {
                PromptedLoginRequest(sender, e);
            } 
        }
    }
}
