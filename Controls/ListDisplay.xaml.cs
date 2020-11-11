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
    public partial class ListDisplay : UserControl
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
        /// Unique identifier for actions carried out on the list
        /// </summary>
        private string _itemIdentifier;

        /// <summary>
        /// The background colour to use for odd positions
        /// </summary>
        private SolidColorBrush _oddBackgroundColour;

        /// <summary>
        /// The background colour to use for even positions
        /// </summary>
        private SolidColorBrush _evenBackgroundColour;

        /// <summary>
        /// The current account info for the display
        /// </summary>
        private Account _currentInfo;

        /// <summary>
        /// Event to raise when the delete button is pressed
        /// </summary>
        public event EventHandler<ListEventArgs> DeleteListItem;

        /// <summary>
        /// Event to raise when the edit button is pressed
        /// </summary>
        public event EventHandler<ListEventArgs> EditListItem;

        /// <summary>
        /// Event to raise when the Arua/Classic login buttons are pressed
        /// </summary>
        public event EventHandler<LoginEventArgs> Login;

        /// <summary>
        /// Event to raise when the move up/down buttons are pressed
        /// </summary>
        public event EventHandler<MoveListItemEventArgs> MoveListItem;

        private ListDisplay(int position)
        {
            InitializeComponent();
            _position = position;
            _evenBackgroundColour = new SolidColorBrush(Color.FromRgb(EVEN_BACKGROUD_COLOUR_VALUE, EVEN_BACKGROUD_COLOUR_VALUE, EVEN_BACKGROUD_COLOUR_VALUE));
            _oddBackgroundColour = new SolidColorBrush(Color.FromRgb(ODD_BACKGROUND_COLOUR_VALUE, ODD_BACKGROUND_COLOUR_VALUE, ODD_BACKGROUND_COLOUR_VALUE));
        }

        public ListDisplay(int position, Account info, ImageSource emblem) : this(position)
        {
            _currentInfo = info;
            _itemIdentifier = info.Username;
            
            // Fill in account info
            Emblem.Source = emblem;
            ListItemIdentifier.Text = info.Username;
            AllInfoIncluded.Source = GetPasswordSavedIcon(info.PasswordHash);
            ListItemDescription.Text = info.Description;
            ListItemDetails.Text = string.Join(", ", info.Characters.ToArray());
        }

        public ListDisplay(int position, Party info) : this(position)
        {
            _itemIdentifier = info.Name;

            // Fill in party info
            ListDisplayGrid.ColumnDefinitions[0].Width = new GridLength(0);
            ListItemIdentifier.Text = info.Name;
            AllInfoIncluded.Visibility = Visibility.Hidden;
            ListItemDescription.Text = info.Description;
            ListItemDetails.Text = string.Join(", ", info.Accounts.ToArray());
        }

        public void UpdateDisplay(int newPosition, int totalDisplays)
        {
            _position = newPosition;
            UpdateBackground();
            UpdateButtons(totalDisplays);
        }

        private BitmapImage GetPasswordSavedIcon(string passwordHash)
        {
            string iconPath = string.IsNullOrWhiteSpace(passwordHash)
                ? "pack://application:,,,/Assets/exclamation-circle-solid.png"
                : "pack://application:,,,/Assets/check-circle-solid.png";
            return new BitmapImage(new Uri(iconPath));
        }

        private void UpdateBackground()
        {
            // Even
            if (_position % 2 == 0)
            {
                ListDisplayGrid.Background = _evenBackgroundColour;
            }
            // Odd
            else
            {
                ListDisplayGrid.Background = _oddBackgroundColour;
            }
        }

        private void UpdateButtons(int totalDisplays)
        {
            // Hide the move up button if it's the first one
            if (_position == 0)
            {
                MoveUpButton.IsEnabled = false;
            }
            else
            {
                MoveUpButton.IsEnabled = true;
            }

            // Hide the move down button if it's the last one
            if (_position == totalDisplays - 1)
            {
                MoveDownButton.IsEnabled = false;
            }
            else
            {
                MoveDownButton.IsEnabled = true;
            }
        }

        private void AruaLoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender != null && Login != null)
            {
                LoginEventArgs args = new LoginEventArgs()
                {
                    Id = _itemIdentifier,
                    ServerId = Server.Arua
                };
                Login(this, args);
            }
        }

        private void ClassicLoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender != null && Login != null)
            {
                LoginEventArgs args = new LoginEventArgs()
                {
                    Id = _itemIdentifier,
                    ServerId = Server.Classic
                };
                Login(this, args);
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender != null && DeleteListItem != null)
            {
                ListEventArgs args = new ListEventArgs()
                {
                    Id = _itemIdentifier
                };
                DeleteListItem(this, args);
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender != null && EditListItem != null)
            {
                ListEventArgs args = new ListEventArgs()
                {
                    Id = _itemIdentifier
                };
                EditListItem(this, args);
            }
        }

        private void MoveUpButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender != null && MoveListItem != null)
            {
                MoveListItemEventArgs args = new MoveListItemEventArgs()
                {
                    Id = _itemIdentifier,
                    Direction = MovementDirection.Up
                };
                MoveListItem(this, args);
            }
        }

        private void MoveDownButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender != null && MoveListItem != null)
            {
                MoveListItemEventArgs args = new MoveListItemEventArgs()
                {
                    Id = _itemIdentifier,
                    Direction = MovementDirection.Down
                };
                MoveListItem(this, args);
            }
        }
    }
}
