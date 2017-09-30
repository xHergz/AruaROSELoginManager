//
// FILE     : AccountManagerWindow.cs
// PROJECT  : AruaROSE Login Manager
// AUTHOR   : xHergz
// DATE     : 2017-09-30
//

using System;
using System.Windows.Forms;

using AruaROSELoginManager.Controllers;
using AruaROSELoginManager.Controls;

namespace AruaROSELoginManager
{
    public partial class AccountManagerWindow : Form
    {
        /// <summary>
        /// The main controller for the application
        /// </summary>
        private AccountManagerController _mainController;

        /// <summary>
        /// The main view for the application
        /// </summary>
        private AccountManagerPanel _mainView;

        /// <summary>
        /// Constructor
        /// </summary>
        public AccountManagerWindow()
        {
            InitializeComponent();

            _mainView = new AccountManagerPanel();
            _mainView.Dock = DockStyle.Fill;
            Controls.Add(_mainView);

            _mainController = new AccountManagerController(_mainView);
        }

        /// <summary>
        /// Initializes the controller when the window loads
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event args</param>
        private void AccountManagerWindow_Load(object sender, EventArgs e)
        {
            _mainController.Initialize();
        }

        /// <summary>
        /// Shuts down the main controller when the window is closing
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event args</param>
        private void AccountManagerWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            _mainController.Shutdown();
        }
    }
}
