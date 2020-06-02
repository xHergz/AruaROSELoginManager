using AruaRoseLoginManager.Controllers;
using AruaRoseLoginManager.Controls;
using AruaRoseLoginManager.Helpers;
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

namespace AruaRoseLoginManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ManagerWindow : Window
    {
        private IManagerPanel _managerPanel;

        private AccountManagerController _controller;

        public ManagerWindow()
        {
            InitializeComponent();
            _managerPanel = new ManagerPanel();
            MainPanel.Children.Add((UserControl)_managerPanel);
            _controller = new AccountManagerController(_managerPanel);
            _controller.Initialize();
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _controller.Shutdown();
        }
    }
}
