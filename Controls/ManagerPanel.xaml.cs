//
// FILE     : ManagerPanel.xaml.cs
// PROJECT  : AruaROSE Login Manager
// AUTHOR   : xHergz
// DATE     : 2021-02-18
//

using System.Windows;
using System.Windows.Controls;

using Microsoft.WindowsAPICodePack.Dialogs;

using AruaRoseLoginManager.Data;
using AruaRoseLoginManager.Enum;
using AruaRoseLoginManager.Helpers;

namespace AruaRoseLoginManager.Controls
{
    /// <summary>
    /// Interaction logic for ManagerPanel.xaml
    /// </summary>
    public partial class ManagerPanel : UserControl, IManagerPanel
    {
        /// <summary>
        /// Current window size
        /// </summary>
        private WindowSize _windowSize;

        /// <summary>
        /// Path to the directory with the ROSE client
        /// </summary>
        public string RoseFolderPath
        {
            get { return _folderTextBox.Text; }
            set { _folderTextBox.Text = value; }
        }

        /// <summary>
        /// Whether to run the clients as admin
        /// </summary>
        public bool RunAsAdmin
        {
            get { return _runAsAdminCheckbox.IsChecked == null ? false : _runAsAdminCheckbox.IsChecked.Value; }
            set { _runAsAdminCheckbox.IsChecked = value; }
        }

        /// <summary>
        /// Window size
        /// </summary>
        public WindowSize Size
        {
            get
            {
                return _windowSize;
            }
            set
            {
                ChangeSize(value);
                _windowSize = value;
            }
        }

        /// <summary>
        /// The account display panel
        /// </summary>
        public IAccountDisplay AccountDisplay { get { return _accountDisplay; } }

        /// <summary>
        /// The party display panel
        /// </summary>
        public IPartyDisplay PartyDisplay { get { return _partyDisplay; } }

        /// <summary>
        /// Constructor
        /// </summary>
        public ManagerPanel()
        {
            InitializeComponent();
            DataContext = this;

            ChangeDisplay(DisplayPanel.Accounts);
        }

        /// <summary>
        /// Displays a message box to the user
        /// </summary>
        /// <param name="message">Message to display</param>
        public void ShowMessageBox(string message)
        {
            MessageBox.Show(message, "AruaROSE Login Manager", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK);
        }

        /// <summary>
        /// Changes the size of the window
        /// </summary>
        /// <param name="size">New size</param>
        public void ChangeSize(WindowSize size)
        {
            Application.Current.MainWindow.Height = size.Height;
            Application.Current.MainWindow.Width = size.Width;
        }

        /// <summary>
        /// Change which tab display is active
        /// </summary>
        /// <param name="panel">The new panel to display</param>
        private void ChangeDisplay(DisplayPanel panel)
        {
            _accountsButton.Active = false;
            _partiesButton.Active = false;
            _optionssButton.Active = false;
            _infoButton.Active = false;
            _accountDisplay.Visibility = Visibility.Hidden;
            _accountDisplay.SwitchPanels(PanelMode.Select);
            _partyDisplay.Visibility = Visibility.Hidden;
            _partyDisplay.SwitchPanels(PanelMode.Select);
            _optionsDisplay.Visibility = Visibility.Hidden;
            _infoDisplay.Visibility = Visibility.Hidden;

            switch (panel)
            {
                case DisplayPanel.Accounts:
                    _accountsButton.Active = true;
                    _accountDisplay.Visibility = Visibility.Visible;
                    break;
                case DisplayPanel.Parties:
                    _partiesButton.Active = true;
                    _partyDisplay.Visibility = Visibility.Visible;
                    break;
                case DisplayPanel.Options:
                    _optionssButton.Active = true;
                    _optionsDisplay.Visibility = Visibility.Visible;
                    break;
                case DisplayPanel.Info:
                    _infoButton.Active = true;
                    _infoDisplay.Visibility = Visibility.Visible;
                    break;
            }
        }

        /// <summary>
        /// Event handler for clicking the browse for folder button.
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event args</param>
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

        /// <summary>
        /// Event handler for resizing the window to the 'normal' size
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event args</param>
        private void NormalButton_Click(object sender, RoutedEventArgs e)
        {
            Size = WindowSize.Default;
        }

        /// <summary>
        /// Event handler for resizing the window to the 'compact' size
        /// </summary>
        /// <param name="sender">Event args</param>
        /// <param name="e">Event args</param>
        private void CompactButton_Click(object sender, RoutedEventArgs e)
        {
            Size = WindowSize.Compact;
        }

        /// <summary>
        /// Event handler for switching to the accounts tab
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event args</param>
        private void AccountsButton_Click(object sender, RoutedEventArgs e)
        {
            ChangeDisplay(DisplayPanel.Accounts);
        }

        /// <summary>
        /// Event handler for switching to the parties tab
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event args</param>
        private void PartiesButton_Click(object sender, RoutedEventArgs e)
        {
            ChangeDisplay(DisplayPanel.Parties);
        }

        /// <summary>
        /// Event handler for switching to the options tab
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event args</param>
        private void OptionsButton_Click(object sender, RoutedEventArgs e)
        {
            ChangeDisplay(DisplayPanel.Options);
        }

        /// <summary>
        /// Event handler for switching to the info button tab
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event args</param>
        private void InfoButton_Click(object sender, RoutedEventArgs e)
        {
            ChangeDisplay(DisplayPanel.Info);
        }
    }
}
