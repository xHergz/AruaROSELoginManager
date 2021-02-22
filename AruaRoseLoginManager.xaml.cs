//
// FILE     : AruaRoseLoginManager.cs
// PROJECT  : AruaROSE Login Manager
// AUTHOR   : xHergz
// DATE     : 2021-02-20
//

using System;
using System.Windows;
using System.Windows.Controls;

using AruaRoseLoginManager.Controllers;
using AruaRoseLoginManager.Controls;
using AruaRoseLoginManager.Helpers;

namespace AruaRoseLoginManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ManagerWindow : Window
    {
        /// <summary>
        /// The front end of the manager
        /// </summary>
        private IManagerPanel _managerPanel;

        /// <summary>
        /// The back end of the manager
        /// </summary>
        private AccountManagerController _controller;

        /// <summary>
        /// Constructor
        /// </summary>
        public ManagerWindow()
        {
            InitializeComponent();
            _managerPanel = new ManagerPanel();
            MainPanel.Children.Add((UserControl)_managerPanel);
            _controller = new AccountManagerController(_managerPanel);
            _controller.Initialize();
        }

        /// <summary>
        /// Event handler for when the window is closed properly using the 'X'
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event args</param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _controller.Shutdown();
        }
    }
}
