//
// FILE     : AccountPanel.cs
// PROJECT  : AruaROSE Login Manager
// AUTHOR   : xHergz
// DATE     : 2017-05-23
// 

using System;
using System.Windows.Forms;

namespace AruaROSELoginManager
{
    /// <summary>
    /// Panel control set up to hold account information
    /// </summary>
    class AccountPanel
    {
        /// <summary>
        /// The panel height
        /// </summary>
        private const int PanelHeight = 100;

        /// <summary>
        /// The panel width
        /// </summary>
        private const int PanelWidth = 425;

        /// <summary>
        /// The path to the up arrow picture
        /// </summary>
        private const string UpArrowPath = "AruaROSELoginManager.Assets.move_up.png";

        /// <summary>
        /// The path to the down arrow picture
        /// </summary>
        private const string DownArrowPath = "AruaROSELoginManager.Assets.move_down.png";

        /// <summary>
        /// The path to the delete button picture
        /// </summary>
        private const string DeleteButtonPath = "AruaROSELoginManager.Assets.delete.png";

        /// <summary>
        /// The base panel
        /// </summary>
        private Panel _panel;

        /// <summary>
        /// The picture box to hold the emblem
        /// </summary>
        private PictureBox _emblemBox;

        /// <summary>
        /// The picture box to hold the up arrow button
        /// </summary>
        private PictureBox _upArrow;

        /// <summary>
        /// The picture box to hold the down arrow button
        /// </summary>
        private PictureBox _downArrow;

        /// <summary>
        /// The picture box to hold the delete button
        /// </summary>
        private PictureBox _deleteButton;

        /// <summary>
        /// The label to display the account name
        /// </summary>
        private Label _accountName;

        /// <summary>
        /// The label to display if there is a password saved or not
        /// </summary>
        private Label _passwordMessage;

        /// <summary>
        /// The button to log in the selected account
        /// </summary>
        private Button _loginButton;

        /// <summary>
        /// Account information for the panel
        /// </summary>
        private Account _account;

        /// <summary>
        /// The id of the panel
        /// </summary>
        private int _panelId;

        /// <summary>
        /// The position in the list of the panel
        /// </summary>
        private int _position;

        /// <summary>
        /// The delegate to call when the login button is pressed
        /// </summary>
        /// <param name="username">Username of the selected account</param>
        /// <param name="password">Password of the selected account</param>
        public delegate void LoginButtonPressed(string username, string password);

        /// <summary>
        /// The delegate to call when an action button is pressed
        /// </summary>
        /// <param name="panelId">The id of the panel which was pressed</param>
        /// <param name="action">The action the button represents</param>
        public delegate void ActionButtonPressed(int panelId, PANEL_MANIPULATION action);

        /// <summary>
        /// The handler for the Login Button being pushed
        /// </summary>
        public LoginButtonPressed LoginAccountMethod;

        /// <summary>
        /// The handler for an action button being pushed
        /// </summary>
        public ActionButtonPressed ActionButtonMethod;

        /// <summary>
        /// The different actions each button represents
        /// </summary>
        public enum PANEL_MANIPULATION { PANEL_UP, PANEL_DOWN, PANEL_DELETE }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="number">The number the panel is assigned</param>
        /// <param name="emblem">The emblem image to display</param>
        /// <param name="account">The account of the panel</param>
        /// <param name="password">The password of the panel</param>
        public AccountPanel(int number, System.Drawing.Image emblem, string account, string password)
        {

            _account = new Account(account, password);
            _panelId = number;
            _position = number;

            System.Reflection.Assembly thisExe;
            thisExe = System.Reflection.Assembly.GetExecutingAssembly();

            //Initialize the controls
            //The panel to hold everything
            _panel = new Panel();
            _panel.Location = new System.Drawing.Point(0, number * PanelHeight);
            _panel.Size = new System.Drawing.Size(PanelWidth, PanelHeight);
            _panel.BorderStyle = BorderStyle.Fixed3D;
            UpdateColour();
            

            //The emblem picture
            _emblemBox = new PictureBox();
            _emblemBox.Image = emblem;
            _emblemBox.SizeMode = PictureBoxSizeMode.StretchImage;
            _emblemBox.Location = new System.Drawing.Point(10, 10);
            _emblemBox.Size = new System.Drawing.Size(75, 75);

            //The up/down arrows and the delete button
            _upArrow = new PictureBox();
            _upArrow.Image = System.Drawing.Image.FromStream(thisExe.GetManifestResourceStream(UpArrowPath));
            _upArrow.SizeMode = PictureBoxSizeMode.StretchImage;
            _upArrow.Location = new System.Drawing.Point(95, 3);
            _upArrow.Size = new System.Drawing.Size(25, 25);
            _upArrow.Click += upArrow_Click;

            _downArrow = new PictureBox();
            _downArrow.Image = System.Drawing.Image.FromStream(thisExe.GetManifestResourceStream(DownArrowPath));
            _downArrow.SizeMode = PictureBoxSizeMode.StretchImage;
            _downArrow.Location = new System.Drawing.Point(95, 33);
            _downArrow.Size = new System.Drawing.Size(25, 25);
            _downArrow.Click += downArrow_Click;

            _deleteButton = new PictureBox();
            _deleteButton.Image = System.Drawing.Image.FromStream(thisExe.GetManifestResourceStream(DeleteButtonPath));
            _deleteButton.SizeMode = PictureBoxSizeMode.StretchImage;
            _deleteButton.Location = new System.Drawing.Point(94, 65);
            _deleteButton.Size = new System.Drawing.Size(25, 25);
            _deleteButton.Click += deleteButton_Click;

            //The account name and password
            _accountName = new Label();
            _accountName.Location = new System.Drawing.Point(126, 10);
            _accountName.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 15.25f);
            _accountName.AutoSize = true;
            _accountName.Text = account;

            _passwordMessage = new Label();
            _passwordMessage.Location = new System.Drawing.Point(128, 40);
            _passwordMessage.AutoSize = true;
            if (password == string.Empty)
            {
                _passwordMessage.Text = "Password NOT Saved";
                _passwordMessage.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                _passwordMessage.Text = "Password Saved";
                _passwordMessage.ForeColor = System.Drawing.Color.Green;
            }

            //The login button
            _loginButton = new Button();
            _loginButton.Location = new System.Drawing.Point(318, 10);
            _loginButton.Size = new System.Drawing.Size(100, 75);
            _loginButton.Font = new System.Drawing.Font("Segoe UI", 12.0f, System.Drawing.FontStyle.Bold);
            _loginButton.Text = "Login";
            _loginButton.Click += loginButton_Click;

            _panel.Controls.Add(_emblemBox);
            _panel.Controls.Add(_upArrow);
            _panel.Controls.Add(_downArrow);
            _panel.Controls.Add(_deleteButton);
            _panel.Controls.Add(_accountName);
            _panel.Controls.Add(_passwordMessage);
            _panel.Controls.Add(_loginButton);
        }

        /// <summary>
        /// Gets the panels id
        /// </summary>
        public int ID
        {
            get { return _panelId; }
        }

        /// <summary>
        /// Gets the base panel object
        /// </summary>
        public Panel Panel
        {
            get { return _panel; }
        }

        /// <summary>
        /// Gets the X position of the panel
        /// </summary>
        public int XPosition
        {
            get { return _panel.Location.X; }
        }

        /// <summary>
        /// Gets the Y position of the panel
        /// </summary>
        public int YPosition
        {
            get { return _panel.Location.Y; }
        }

        /// <summary>
        /// Gets the position in the list of current panel
        /// </summary>
        public int Position
        {
            get { return _position; }
            set { _position = value; }
        }

        /// <summary>
        /// Gets the account name the panel is representing
        /// </summary>
        public string AccountName
        {
            get { return _account.Username; }
        }
        
        /// <summary>
        /// Gets the password the panel is representing
        /// </summary>
        public string Password
        {
            get { return _account.Password; }
        }

        /// <summary>
        /// Moves the panel to the given location
        /// </summary>
        /// <param name="xPos">The new y position</param>
        /// <param name="yPos">The nex x position</param>
        public void Move(int xPos, int yPos)
        {
            if(yPos < YPosition)
            {
                //Adjust the position for the panel moving up
                _position--;
            }
            else
            {
                //Adjust the position for the panel moving down
                _position++;
            }

            //Adjust the panel colour
            UpdateColour();

            _panel.Location = new System.Drawing.Point(xPos, yPos);
        }

        /// <summary>
        /// Remove the panel
        /// </summary>
        public void Remove()
        {
            _panel.Dispose();
        }

        /// <summary>
        /// Update the colour of the panel based on the position in the list
        /// </summary>
        private void UpdateColour()
        {
            //Alternate the color every other panel
            if (_position % 2 == 0)
            {
                _panel.BackColor = System.Drawing.Color.Gray;
            }
            else
            {
                _panel.BackColor = System.Drawing.Color.LightGray;
            }
        }

        /// <summary>
        /// Calls the handler to log in the account when the login button is clicked
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="args">Event arguments</param>
        private void loginButton_Click(object sender, EventArgs args)
        {
            LoginAccountMethod(_account.Username, _account.Password);
        }

        /// <summary>
        /// Calls the handler for the move up action when the up arrow is clicked
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="args">Event arguments</param>
        private void upArrow_Click(object sender, EventArgs args)
        {
            ActionButtonMethod(_panelId, PANEL_MANIPULATION.PANEL_UP);
        }

        /// <summary>
        /// Calls the handler for the move down action when the down arrow is clicked
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="args">Event arguments</param>
        private void downArrow_Click(object sender, EventArgs args)
        {
            ActionButtonMethod(_panelId, PANEL_MANIPULATION.PANEL_DOWN);
        }

        /// <summary>
        /// Calls the handler for the delete action when the delete button is clicked
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="args">Event arguments</param>
        private void deleteButton_Click(object sender, EventArgs args)
        {
            ActionButtonMethod(_panelId, PANEL_MANIPULATION.PANEL_DELETE);
        }

    }
}
