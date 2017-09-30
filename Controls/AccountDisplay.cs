//
// FILE     : AccountDisplay.cs
// PROJECT  : AruaROSE Login Manager
// AUTHOR   : xHergz
// DATE     : 2017-09-30
// 

using System;
using System.Drawing;
using System.Windows.Forms;

using AruaROSELoginManager.Data;

namespace AruaROSELoginManager.Controls
{
    public partial class AccountDisplay : UserControl
    {
        /// <summary>
        /// Background colour for evenly numbered panels
        /// </summary>
        private static Color EVEN_BACKGROUND_COLOUR = Color.DarkGray;

        /// <summary>
        /// Background colour for oddly numbered panels
        /// </summary>
        private static Color ODD_BACKGROUND_COLOUR = Color.LightGray;

        /// <summary>
        /// Colour for the password saved label
        /// </summary>
        private static Color PASSWORD_SAVED_COLOUR = Color.Green;

        /// <summary>
        /// Colour for the password not saved label
        /// </summary>
        private static Color PASSWORD_NOT_SAVED_COLOR = Color.Red;

        /// <summary>
        /// Event to raise when the move up button is pressed
        /// </summary>
        public event EventHandler<AccountDisplayEventArgs> MoveUpPressed;

        /// <summary>
        /// Event to raise when the move down button is pressed
        /// </summary>
        public event EventHandler<AccountDisplayEventArgs> MoveDownPressed;

        /// <summary>
        /// Event to raise when the delete button is pressed
        /// </summary>
        public event EventHandler<AccountDisplayEventArgs> DeletePressed;

        /// <summary>
        /// Event to raise when the login button is pressed
        /// </summary>
        public event EventHandler<AccountDisplayEventArgs> LoginPressed;

        /// <summary>
        /// Returns the account name for the entry
        /// </summary>
        public string AccountName { get { return _accountNameLabel.Text; } }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="accountName">The account name</param>
        /// <param name="password">The password</param>
        public AccountDisplay(string accountName, string password)
        {
            InitializeComponent();

            _accountNameLabel.Text = accountName;

            if (password == string.Empty)
            {
                _passwordInfo.Text = Properties.Resources.PasswordNotSaved;
                _passwordInfo.ForeColor = PASSWORD_NOT_SAVED_COLOR;
            }
            else
            {
                _passwordInfo.Text = Properties.Resources.PasswordSaved;
                _passwordInfo.ForeColor = PASSWORD_SAVED_COLOUR;
            }
        }

        /// <summary>
        /// Sets the image for the entry
        /// </summary>
        /// <param name="image">The image to use</param>
        public void SetEmblem(Image image)
        {
            _emblemPicutreBox.Image = image;
        }

        /// <summary>
        /// Changes the colour to the even background
        /// </summary>
        public void DisplayEvenColour()
        {
            BackColor = EVEN_BACKGROUND_COLOUR;
        }

        /// <summary>
        /// Changes the colour to the odd background
        /// </summary>
        public void DisplayOddColour()
        {
            BackColor = ODD_BACKGROUND_COLOUR;
        }

        /// <summary>
        /// Inverts the background colour (From even to odd and vice versa)
        /// </summary>
        public void InvertColour()
        {
            if (BackColor == EVEN_BACKGROUND_COLOUR)
            {
                DisplayOddColour();
            }
            else
            {
                DisplayEvenColour();
            }
        }

        /// <summary>
        /// Handles the move up arrow click
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event args</param>
        private void _moveUpArrow_Click(object sender, EventArgs e)
        {
            if (sender != null && MoveUpPressed != null)
            {
                MoveUpPressed(this, GetAccountManagerEventArgs());
            }
        }

        /// <summary>
        /// Handles the move down arrow click
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event args</param>
        private void _moveDownArrow_Click(object sender, EventArgs e)
        {
            if (sender != null && MoveDownPressed != null)
            {
                MoveDownPressed(this, GetAccountManagerEventArgs());
            }
        }

        /// <summary>
        /// Handles the delete button click
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event args</param>
        private void _deleteButton_Click(object sender, EventArgs e)
        {
            if (sender != null && DeletePressed != null)
            {
                DeletePressed(this, GetAccountManagerEventArgs());
            }
        }

        /// <summary>
        /// Handles the login button click
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event args</param>
        private void _loginButton_Click(object sender, EventArgs e)
        {
            if (sender != null && LoginPressed != null)
            {
                LoginPressed(this, GetAccountManagerEventArgs());
            }
        }

        /// <summary>
        /// Creates the event args for passing the account display info
        /// </summary>
        /// <returns>The argument object</returns>
        private AccountDisplayEventArgs GetAccountManagerEventArgs()
        {
            return new AccountDisplayEventArgs()
            {
                AccountName = _accountNameLabel.Text
            };
        }
    }
}
