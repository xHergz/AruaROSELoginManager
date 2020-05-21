using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

using AruaRoseLoginManager.Data;
using AruaRoseLoginManager.Enum;

namespace AruaRoseLoginManager.Controls
{
    /// <summary>
    /// Interaction logic for AccountDisplay.xaml
    /// </summary>
    public partial class AccountDisplay : UserControl
    {
        /// <summary>
        /// Used to make #EAEAEA/rgb(234, 234, 234)
        /// </summary>
        private const byte ODD_BACKGROUND_COLOUR_VALUE = 234;

        /// <summary>
        /// Used to make #FAFAFA/rgb(250, 250, 250)
        /// </summary>
        private const byte EVEN_BACKGROUD_COLOUR_VALUE = 250;

        /// <summary>
        /// Tracks the position of the display in the stack view
        /// </summary>
        private int _position;

        /// <summary>
        /// The account info for the display
        /// </summary>
        private Account _accountInfo;

        /// <summary>
        /// The background colour to use for odd positions
        /// </summary>
        private SolidColorBrush _oddBackgroundColour;

        /// <summary>
        /// The background colour to use for even positions
        /// </summary>
        private SolidColorBrush _evenBackgroundColour;        

        /// <summary>
        /// Event to raise when the delete button is pressed
        /// </summary>
        public event EventHandler<AccountEventArgs> DeleteAccount;

        /// <summary>
        /// Event to raise when the edit button is pressed
        /// </summary>
        public event EventHandler<AccountEventArgs> EditAccount;

        /// <summary>
        /// Event to raise when the Arua/Classic login buttons are pressed
        /// </summary>
        public event EventHandler<LoginEventArgs> LoginAccount;

        /// <summary>
        /// Event to raise when the move up/down buttons are pressed
        /// </summary>
        public event EventHandler<MoveAccountEventArgs> MoveAccount;

        public AccountDisplay(int position, int totalDisplays, ImageSource emblem, Account info)
        {
            InitializeComponent();
            _position = position;
            _accountInfo = info;
            _evenBackgroundColour = new SolidColorBrush(Color.FromRgb(EVEN_BACKGROUD_COLOUR_VALUE, EVEN_BACKGROUD_COLOUR_VALUE, EVEN_BACKGROUD_COLOUR_VALUE));
            _oddBackgroundColour = new SolidColorBrush(Color.FromRgb(ODD_BACKGROUND_COLOUR_VALUE, EVEN_BACKGROUD_COLOUR_VALUE, EVEN_BACKGROUD_COLOUR_VALUE));

            // Fill in account info
            Emblem.Source = emblem;
            AccountName.Text = info.Username;
            PasswordSaved.Source = GetPasswordSavedIcon(info.PasswordHash);
            AccountDescription.Text = info.Description;
            AccountCharacters.Text = string.Join(", ", info.Characters.ToArray());

            UpdateDisplay(position, totalDisplays);
        }

        public void UpdateDisplay(int newPosition, int totalDisplays)
        {
            _position = newPosition;
            UpdateBackground();
            UpdateButtons(totalDisplays);
        }

        private BitmapImage GetPasswordSavedIcon(string passwordHash)
        {
            string iconPath = passwordHash == null
                ? "pack://application:,,,/Assets/exclamation-circle-solid.png"
                : "pack://application:,,,/Assets/check-circle-solid.png";
            return new BitmapImage(new Uri(iconPath));
        }

        private void UpdateBackground()
        {
            // Even
            if (_position % 2 == 0)
            {
                Background = _evenBackgroundColour;
            }
            // Odd
            else
            {
                Background = _oddBackgroundColour;
            }
        }

        private void UpdateButtons(int totalDisplays)
        {
            // Hide the move up button if it's the first one
            if (_position == 1)
            {
                MoveUpButton.Visibility = Visibility.Hidden;
            }
            else
            {
                MoveUpButton.Visibility = Visibility.Visible;
            }

            // Hide the move down button if it's the last one
            if (_position == totalDisplays)
            {
                MoveDownButton.Visibility = Visibility.Hidden;
            }
            else
            {
                MoveUpButton.Visibility = Visibility.Visible;
            }
        }

        private void AruaLoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender != null && LoginAccount != null)
            {
                LoginEventArgs args = new LoginEventArgs()
                {
                    Account = _accountInfo,
                    ServerId = Server.Arua
                };
                LoginAccount(this, args);
            }
        }

        private void ClassicLoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender != null && LoginAccount != null)
            {
                LoginEventArgs args = new LoginEventArgs()
                {
                    Account = _accountInfo,
                    ServerId = Server.Classic
                };
                LoginAccount(this, args);
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender != null && DeleteAccount != null)
            {
                AccountEventArgs args = new AccountEventArgs()
                {
                    Account = _accountInfo
                };
                DeleteAccount(this, args);
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender != null && EditAccount != null)
            {
                AccountEventArgs args = new AccountEventArgs()
                {
                    Account = _accountInfo
                };
                EditAccount(this, args);
            }
        }

        private void MoveUpButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender != null && MoveAccount != null)
            {
                MoveAccountEventArgs args = new MoveAccountEventArgs()
                {
                    Account = _accountInfo,
                    Direction = MovementDirection.Up
                };
                MoveAccount(this, args);
            }
        }

        private void MoveDownButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender != null && MoveAccount != null)
            {
                MoveAccountEventArgs args = new MoveAccountEventArgs()
                {
                    Account = _accountInfo,
                    Direction = MovementDirection.Down
                };
                MoveAccount(this, args);
            }
        }
    }
}
