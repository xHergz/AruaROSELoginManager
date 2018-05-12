//
// FILE     : AccountManagerPanel.cs
// PROJECT  : AruaROSE Login Manager
// AUTHOR   : xHergz
// DATE     : 2017-09-30
// 

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

using AruaROSELoginManager.Data;

namespace AruaROSELoginManager.Controls
{
    public partial class AccountManagerPanel : UserControl
    {
        /// <summary>
        /// The list of emblem images
        /// </summary>
        private List<Image> _emblemImages;

        /// <summary>
        /// Keeps track of the current emblem to incriment which one is displayed
        /// </summary>
        private int _currentEmblemIndex;

        /// <summary>
        /// Event to raise when there is a login request
        /// </summary>
        public event EventHandler<AccountLoginEventArgs> LoginRequest;

        /// <summary>
        /// Event to raise when there is an add account request
        /// </summary>
        public event EventHandler AddAccountRequest;

        /// <summary>
        /// Returns the rose folder path
        /// </summary>
        public string RoseFolderPath { get { return _rosePathTextBox.Text; } }

        /// <summary>
        /// Returns the state of the run as admin checkbox
        /// </summary>
        public bool RunAsAdmin { get { return _runAsAdminCheckBox.Checked; } }

        /// <summary>
        /// Constructor
        /// </summary>
        public AccountManagerPanel()
        {
            InitializeComponent();

            System.Reflection.Assembly thisExe;
            thisExe = System.Reflection.Assembly.GetExecutingAssembly();

            //Load the background
            BackgroundImage = Image.FromStream(thisExe.GetManifestResourceStream("AruaROSELoginManager.Assets.background.png"));

            _emblemImages = new List<Image>();
            LoadEmblems();
        }

        /// <summary>
        /// Adds an account to the list
        /// </summary>
        /// <param name="accountName">The account name</param>
        /// <param name="password">The password</param>
        public void AddAccount(string accountName, string password)
        {
            AccountDisplay newAccountDisplay = new AccountDisplay(accountName, password);
            newAccountDisplay.Margin = new Padding(0);
            // If there is an even number of controls in the flow layout, this will be even
            if (_accountFlowLayout.Controls.Count % 2 == 0)
            {
                newAccountDisplay.DisplayEvenColour();
            }
            else
            {
                newAccountDisplay.DisplayOddColour();
            }
            newAccountDisplay.SetEmblem(GetCurrentEmblem());
            newAccountDisplay.MoveUpPressed += AccountDisplay_MoveUpPressed;
            newAccountDisplay.MoveDownPressed += AccountDisplay_MoveDownPressed;
            newAccountDisplay.DeletePressed += AccountDisplay_DeletePressed;
            newAccountDisplay.LoginAruaPressed += AccountDisplay_LoginPressed;
            newAccountDisplay.LoginClassicPressed += AccountDisplay_LoginPressed;
            _accountFlowLayout.Controls.Add(newAccountDisplay);
        }

        /// <summary>
        /// Sets the rose folder path
        /// </summary>
        /// <param name="path">The path</param>
        public void SetRoseFolderPath(string path)
        {
            _rosePathTextBox.Text = path;
        }

        /// <summary>
        /// Sets the state of the run as admin checkbox
        /// </summary>
        /// <param name="state">The state</param>
        public void SetRunAsAdminCheckbox(bool state)
        {
            _runAsAdminCheckBox.Checked = state;
        }

        /// <summary>
        /// Pops up a message box
        /// </summary>
        /// <param name="message">The message to display</param>
        public void ShowMessageBox(string message)
        {
            MessageBox.Show(message);
        }

        /// <summary>
        /// Prompts the user to enter their password
        /// </summary>
        /// <param name="accountName">The account name</param>
        /// <returns>The password entered</returns>
        public string PromptForPassword(string accountName)
        {
            AccountInfoWindow infoWindow = new AccountInfoWindow(accountName);
            infoWindow.ShowDialog();
            return infoWindow.EnteredAccount.Password;
        }

        /// <summary>
        /// Prompts the user for their account details
        /// </summary>
        /// <param name="accountName">The account name to be filled in</param>
        /// <param name="password">The password to be filled in</param>
        public void PromptForAccountDetails(out string accountName, out string password)
        {
            AccountInfoWindow infoWindow = new AccountInfoWindow();
            infoWindow.ShowDialog();
            accountName = infoWindow.EnteredAccount.Username;
            password = infoWindow.EnteredAccount.Password;
        }

        /// <summary>
        /// Gets all the accounts for the display list
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetAllAccountNames()
        {
            List<string> accountList = new List<string>();
            foreach (Control c in _accountFlowLayout.Controls)
            {
                AccountDisplay currentDisplay = (AccountDisplay)c;
                accountList.Add(currentDisplay.AccountName);
            }

            return accountList;
        }

        /// <summary>
        /// Loads all the emblems available
        /// </summary>
        private void LoadEmblems()
        {
            int currentEmblem = 1;
            string emblemPath = ".\\Images\\emblem";
            string emblemExtension = ".png";

            while (File.Exists($"{emblemPath}{currentEmblem}{emblemExtension}"))
            {
                Image newEmblem = Image.FromFile($"{emblemPath}{currentEmblem}{emblemExtension}");
                _emblemImages.Add(newEmblem);
                ++currentEmblem;
            }
        }

        /// <summary>
        /// Gets the current emblem
        /// </summary>
        /// <returns>The image data</returns>
        private Image GetCurrentEmblem()
        {
            Image currentEmblem = null;

            if (_emblemImages.Count > 0)
            {
                currentEmblem = _emblemImages[_currentEmblemIndex];
                if (_currentEmblemIndex == _emblemImages.Count - 1)
                {
                    _currentEmblemIndex = 0;
                }
                else
                {
                    ++_currentEmblemIndex;
                }
            }

            return currentEmblem;
        }

        /// <summary>
        /// Updates the display colours to make sure they are alternating
        /// </summary>
        private void UpdateDisplayColours()
        {
            int currentIndex = 0;
            foreach(Control c in _accountFlowLayout.Controls)
            {
                AccountDisplay currentDisplay = (AccountDisplay)c;
                if (currentIndex % 2 == 0)
                {
                    currentDisplay.DisplayEvenColour();
                }
                else
                {
                    currentDisplay.DisplayOddColour();
                }
                currentIndex++;
            }
        }

        /// <summary>
        /// Moves an account display item up
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event args</param>
        private void AccountDisplay_MoveUpPressed(object sender, AccountDisplayEventArgs e)
        {
            AccountDisplay accountDisplayToMove = (AccountDisplay)sender;
            int currentIndex = _accountFlowLayout.Controls.IndexOf(accountDisplayToMove);
            // If the current index is 0 we cant move it up anymore
            if (currentIndex != 0)
            {
                _accountFlowLayout.Controls.SetChildIndex(accountDisplayToMove, currentIndex - 1);
                UpdateDisplayColours();
            }
        }

        /// <summary>
        /// MOves an account display item down
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event args</param>
        private void AccountDisplay_MoveDownPressed(object sender, AccountDisplayEventArgs e)
        {
            Control accountDisplayToMove = (Control)sender;
            int currentIndex = _accountFlowLayout.Controls.IndexOf(accountDisplayToMove);
            // If the current index is 0 we cant move it up anymore
            if (currentIndex < _accountFlowLayout.Controls.Count - 1)
            {
                _accountFlowLayout.Controls.SetChildIndex(accountDisplayToMove, currentIndex + 1);
                UpdateDisplayColours();
            }
        }

        /// <summary>
        /// Deletes an account from the list
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event args</param>
        private void AccountDisplay_DeletePressed(object sender, AccountDisplayEventArgs e)
        {
            _accountFlowLayout.Controls.Remove((Control)sender);
            UpdateDisplayColours();
        }

        /// <summary>
        /// Raises a login request event from a login button being pressed
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event args</param>
        private void AccountDisplay_LoginPressed(object sender, AccountDisplayEventArgs e)
        {
            if (sender != null && LoginRequest != null)
            {
                AccountLoginEventArgs args = new AccountLoginEventArgs()
                {
                    AccountName = e.AccountName,
                    ServerId = e.ServerId,
                    FilePath = _rosePathTextBox.Text,
                    RunAsAdmin = _runAsAdminCheckBox.Checked
                };
                LoginRequest(sender, args);
            }
        }

        /// <summary>
        /// Raises an add account request
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event args</param>
        private void _addAccountPictureBox_Click(object sender, EventArgs e)
        {
            if (sender != null && AddAccountRequest != null)
            {
                AddAccountRequest(sender, e);
            }
        }

        /// <summary>
        /// Opens the folder browsing dialoug so the user can find their rose file
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event args</param>
        private void _rosePathButton_Click(object sender, EventArgs e)
        {
            if (sender != null)
            {
                FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
                folderBrowser.Description = "Select your AruaROSE Folder";
                DialogResult result = folderBrowser.ShowDialog();

                if (result == DialogResult.OK)
                {
                    _rosePathTextBox.Text = folderBrowser.SelectedPath;
                }
            }
        }
    }
}
