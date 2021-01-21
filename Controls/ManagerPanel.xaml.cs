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
using Microsoft.WindowsAPICodePack.Dialogs;

namespace AruaRoseLoginManager.Controls
{
    /// <summary>
    /// Interaction logic for ManagerPanel.xaml
    /// </summary>
    public partial class ManagerPanel : UserControl, IManagerPanel
    {
        public string RoseFolderPath
        {
            get { return _folderTextBox.Text; }
            set { _folderTextBox.Text = value; }
        }

        public bool RunAsAdmin
        {
            get { return _runAsAdminCheckbox.IsChecked == null ? false : _runAsAdminCheckbox.IsChecked.Value; }
            set { _runAsAdminCheckbox.IsChecked = value; }
        }

        public WindowSize Size { get; set; }

        public IAccountDisplay AccountDisplay { get { return _accountDisplay; } }

        public IPartyDisplay PartyDisplay { get { return _partyDisplay; } }

        public ManagerPanel()
        {
            InitializeComponent();
            DataContext = this;
        }

        public string PromptForPassword(string accountName)
        {
            throw new NotImplementedException();
        }

        public void ShowMessageBox(string message)
        {

        }

        public void ChangeSize(bool compact)
        {
            if (compact)
            {
                Application.Current.MainWindow.Height = 650;
                Application.Current.MainWindow.Width = 325;
            } else
            {
                Application.Current.MainWindow.Height = 650;
                Application.Current.MainWindow.Width = 650;
            }
        }

        private void BrowseFolderButton_Click(object sender, RoutedEventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;
            CommonFileDialogResult result = dialog.ShowDialog();
            if (result == CommonFileDialogResult.Ok)
            {
                RoseFolderPath = dialog.FileName;
            }
        }

        private void SizeOption_Click(object sender, RoutedEventArgs e)
        {
            ChangeSize(_compactButton.IsChecked.Value);
        }
    }
}
