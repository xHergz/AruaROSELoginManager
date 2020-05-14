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
using System.Windows.Shapes;
using AruaRoseLoginManager.Enum;
using System.IO;

namespace AruaRoseLoginManager.Controls
{
    /// <summary>
    /// Interaction logic for ManagerPanel.xaml
    /// </summary>
    public partial class ManagerPanel : UserControl, IManagerPanel
    {
        private List<BitmapImage> emblems;

        public string RoseFolderPath { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool RunAsAdmin { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public WindowSize Size { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public event EventHandler<LoginEventArgs> Login;

        public event EventHandler AddAccount;
        public event EventHandler<AccountEventArgs> DeleteAccount;
        public event EventHandler<AccountEventArgs> UpdateAccount;
        public event EventHandler<MoveAccountEventArgs> MoveAccount;

        public ManagerPanel()
        {
            InitializeComponent();
        }

        event EventHandler<AccountEventArgs> IManagerPanel.AddAccount
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        public void AddAccountToDisplay(Account account)
        {
            throw new NotImplementedException();
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
            string emblemPath = ".\\Images\\emblem";
            string emblemExtension = ".png";

            while (File.Exists($"{emblemPath}{currentEmblem}{emblemExtension}"))
            {
                string iconPath = $"{emblemPath}{currentEmblem}{emblemExtension}";
                emblems.Add(new BitmapImage(new Uri(iconPath)));
                ++currentEmblem;
            }
        }
    }
}
