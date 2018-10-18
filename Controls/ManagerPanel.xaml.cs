using AruaRoseLoginManager.Helpers;
using AruaROSELoginManager.Data;
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

namespace AruaRoseLoginManager.Controls
{
    /// <summary>
    /// Interaction logic for ManagerPanel.xaml
    /// </summary>
    public partial class ManagerPanel : UserControl, IManagerPanel
    {

        public string RoseFolderPath { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool RunAsAdmin { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public event EventHandler<AccountLoginEventArgs> Login;

        public event EventHandler AddAccount;

        public ManagerPanel()
        {
            InitializeComponent();
        }

        public void AddNewAccount(string accountName, string description, List<string> characters)
        {
            throw new NotImplementedException();
        }

        public void PromptForPassword(string accountName)
        {
            throw new NotImplementedException();
        }
    }
}
