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
        private List<BitmapImage> emblems;

        private int currentEmblemIndex;

        public string RoseFolderPath { get; set; }

        public bool RunAsAdmin { get; set; }
        public WindowSize Size { get; set; }

        public event EventHandler<LoginEventArgs> Login;

        public event EventHandler<AccountEventArgs> AddAccount;
        public event EventHandler<AccountEventArgs> DeleteAccount;
        public event EventHandler<AccountEventArgs> UpdateAccount;
        public event EventHandler<MoveAccountEventArgs> MoveAccount;

        public ManagerPanel()
        {
            InitializeComponent();
            currentEmblemIndex = 0;
            LoadEmblems();
        }

        public void AddAccountToDisplay(Account account)
        {
            AccountDisplay newDisplay = new AccountDisplay(
                AccountStackPanel.Children.Count + 1,
                AccountStackPanel.Children.Count,
                GetCurrentEmblem(),
                account
            );
            AccountStackPanel.Children.Add((UserControl)newDisplay);
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

            emblems = new List<BitmapImage>();
            while (File.Exists($"./{emblemDirectory}/{emblemPrefix}{currentEmblem}{emblemExtension}"))
            {
                string iconPath = Path.Combine(Environment.CurrentDirectory, emblemDirectory, $"{emblemPrefix}{currentEmblem}{emblemExtension}");
                emblems.Add(new BitmapImage(new Uri(iconPath)));
                ++currentEmblem;
            }
        }

        private BitmapImage GetCurrentEmblem()
        {
            BitmapImage currentEmblem = emblems.ElementAt(currentEmblemIndex);
            currentEmblemIndex++;
            if (currentEmblemIndex >= emblems.Count)
            {
                currentEmblemIndex = 0;
            }
            return currentEmblem;
        }
    }
}
