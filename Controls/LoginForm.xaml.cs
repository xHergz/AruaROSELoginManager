using AruaRoseLoginManager.Data;
using AruaRoseLoginManager.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for LoginForm.xaml
    /// </summary>
    public partial class LoginForm : UserControl
    {
        private Server _serverId;

        [Browsable(true)]
        public event EventHandler Cancel;

        [Browsable(true)]
        public event EventHandler<LoginWithPassEventArgs> Login;

        public LoginForm()
        {
            InitializeComponent();
        }

        public void PopulateFields(string username, Server serverId)
        {
            _usernameTextBox.Text = username;
            _usernameTextBox.IsEnabled = false;
            _serverId = serverId;
        }

        public void ClearFields()
        {
            _usernameTextBox.Clear();
            _passwordTextBox.Clear();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            if (sender != null && Cancel != null)
            {
                Cancel(this, EventArgs.Empty);
            }
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender != null && Login != null)
            {
                LoginWithPassEventArgs args = new LoginWithPassEventArgs()
                {
                    Id = _usernameTextBox.Text,
                    ServerId = _serverId,
                    Password = _passwordTextBox.Password
                };
                Login(this, args);
            }
        }
    }
}
