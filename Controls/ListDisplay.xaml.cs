//
// FILE     : ListDisplay.xaml.cs
// PROJECT  : AruaROSE Login Manager
// AUTHOR   : xHergz
// DATE     : 2021-02-18
//

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
        /// Flag to show extras like the emblem and password saved icon
        /// </summary>
        private bool _showExtras = true;

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

        /// <summary>
        /// Constructor (common)
        /// </summary>
        /// <param name="position">Position in the list</param>
        private ListDisplay(int position)
        {
            InitializeComponent();
            _position = position;
            _evenBackgroundColour = new SolidColorBrush(Color.FromRgb(EVEN_BACKGROUD_COLOUR_VALUE, EVEN_BACKGROUD_COLOUR_VALUE, EVEN_BACKGROUD_COLOUR_VALUE));
            _oddBackgroundColour = new SolidColorBrush(Color.FromRgb(ODD_BACKGROUND_COLOUR_VALUE, ODD_BACKGROUND_COLOUR_VALUE, ODD_BACKGROUND_COLOUR_VALUE));
        }

        /// <summary>
        /// Constructor (for accounts)
        /// </summary>
        /// <param name="position">Position in the list</param>
        /// <param name="info">Account info</param>
        /// <param name="emblem">Emblem to use</param>
        public ListDisplay(int position, Account info, ImageSource emblem) : this(position)
        {
            _itemIdentifier = info.Username;
            
            // Fill in account info
            _emblem.Source = emblem;
            _listItemIdentifier.Text = info.Username;
            _allInfoIncluded.Source = GetPasswordSavedIcon(info.PasswordHash);
            _listItemDescription.Text = info.Description;
            _listItemDetails.Text = string.Join(", ", info.Characters.ToArray());
        }

        /// <summary>
        /// Constructor (for parties)
        /// </summary>
        /// <param name="position">Position in the list</param>
        /// <param name="info">Party info</param>
        public ListDisplay(int position, Party info) : this(position)
        {
            _itemIdentifier = info.Name;
            _showExtras = false;

            // Fill in party info
            _listDisplayGrid.ColumnDefinitions[0].Width = new GridLength(0);
            _listItemIdentifier.Text = info.Name;
            _allInfoIncluded.Visibility = Visibility.Hidden;
            _listItemDescription.Text = info.Description;
            _listItemDetails.Text = string.Join(", ", info.Accounts.ToArray());
        }

        /// <summary>
        /// Updates the display based on a new position and how many total displays there are
        /// </summary>
        /// <param name="newPosition">New position in the list</param>
        /// <param name="totalDisplays">Total number of displays in the list</param>
        public void UpdateDisplay(int newPosition, int totalDisplays)
        {
            _position = newPosition;
            UpdateBackground();
            UpdateButtons(totalDisplays);
        }

        /// <summary>
        /// Determines if the password saved icon should be shown or not
        /// </summary>
        /// <param name="passwordHash">The password hash</param>
        /// <returns>The icon image to display</returns>
        private BitmapImage GetPasswordSavedIcon(string passwordHash)
        {
            string iconPath = string.IsNullOrWhiteSpace(passwordHash)
                ? "pack://application:,,,/Assets/exclamation-icon.png"
                : "pack://application:,,,/Assets/check-icon.png";
            return new BitmapImage(new Uri(iconPath));
        }

        /// <summary>
        /// Updates the background colour to be different for even and odd positions
        /// </summary>
        private void UpdateBackground()
        {
            // Even
            if (_position % 2 == 0)
            {
                _listDisplayGrid.Background = _evenBackgroundColour;
            }
            // Odd
            else
            {
                _listDisplayGrid.Background = _oddBackgroundColour;
            }
        }

        /// <summary>
        /// Updates the move buttons to be enabled/disabled based on position.
        /// </summary>
        /// <param name="totalDisplays">Total displays in the list</param>
        private void UpdateButtons(int totalDisplays)
        {
            // Hide the move up button if it's the first one
            if (_position == 0)
            {
                _moveUpButton.IsEnabled = false;
            }
            else
            {
                _moveUpButton.IsEnabled = true;
            }

            // Hide the move down button if it's the last one
            if (_position == totalDisplays - 1)
            {
                _moveDownButton.IsEnabled = false;
            }
            else
            {
                _moveDownButton.IsEnabled = true;
            }
        }

        /// <summary>
        /// Changes the display into its compact state by removing some elements
        /// </summary>
        private void CompactDisplay()
        {
            // Hide emblem
            _listDisplayGrid.ColumnDefinitions[0].Width = new GridLength(0);
            // Hide movement buttons
            _infoDisplayGrid.ColumnDefinitions[0].Width = new GridLength(0);
            // Hide Edit/Delete buttons
            _infoDisplayGrid.ColumnDefinitions[3].Width = new GridLength(0);
            _allInfoIncluded.Visibility = Visibility.Hidden;

        }

        /// <summary>
        /// Changes the display into its normal state by showing all elements
        /// </summary>
        private void NormalDisplay()
        {
            if (_showExtras)
            {
                _listDisplayGrid.ColumnDefinitions[0].Width = new GridLength(80);
                _allInfoIncluded.Visibility = Visibility.Visible;
            }
            // Show movement buttons
            _infoDisplayGrid.ColumnDefinitions[0].Width = new GridLength(35);
            // Show Edit/Delete buttons
            _infoDisplayGrid.ColumnDefinitions[3].Width = new GridLength(35);
        }

        /// <summary>
        /// Event handler for when the Arua login button is clicked
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event args</param>
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

        /// <summary>
        /// Event handler for when the classic login button is clicked
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event args</param>
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

        /// <summary>
        /// Event handler for when the seasonal login button is clicked
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event args</param>
        private void SeasonalLoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender != null && Login != null)
            {
                LoginEventArgs args = new LoginEventArgs()
                {
                    Id = _itemIdentifier,
                    ServerId = Server.Seasonal
                };
                Login(this, args);
            }
        }

        /// <summary>
        /// Event handler for when the delete button is clicked
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event args</param>
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

        /// <summary>
        /// Event handler for when the edit button is clicked
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event args</param>
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

        /// <summary>
        /// Event handler for when the move up button is clicked
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event args</param>
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

        /// <summary>
        /// Event handler for when the move down button is clicked
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event args</param>
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

        /// <summary>
        /// Event handler for when the display size changes
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event args</param>
        private void ListDisplayGrid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (e.NewSize.Width < 400)
            {
                CompactDisplay();
            } else
            {
                NormalDisplay();
            }
        }
    }
}
