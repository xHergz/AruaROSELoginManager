//
// FILE     : TabButton.xaml.cs
// PROJECT  : AruaROSE Login Manager
// AUTHOR   : xHergz
// DATE     : 2021-02-18
//

using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

using AruaRoseLoginManager.Enum;

namespace AruaRoseLoginManager.Controls
{
    /// <summary>
    /// Interaction logic for TabButton.xaml
    /// </summary>
    public partial class TabButton : Button
    {
        /// <summary>
        /// Colour for not active tab buttons
        /// </summary>
        private SolidColorBrush _notActiveColour;

        /// <summary>
        /// Colour for active tab buttons
        /// </summary>
        private SolidColorBrush _activeColour;

        /// <summary>
        /// If the button is active or not
        /// </summary>
        private bool _active = false;

        /// <summary>
        /// Source URI for the button image
        /// </summary>
        [Browsable(true)]
        public string ImageSource { get; set; }

        /// <summary>
        /// Button text
        /// </summary>
        [Browsable(true)]
        public string Text { get; set; }

        /// <summary>
        /// Display panel ID linked to this button
        /// </summary>
        [Browsable(true)]
        public DisplayPanel Id { get; set; } 

        /// <summary>
        /// Currently displayed panel ID
        /// </summary>
        [Browsable(true)]
        public DisplayPanel Current { get; set; }

        /// <summary>
        /// If the button is currently active
        /// </summary>
        public bool Active
        {
            get { return _active; }
            set {
                if (value)
                {
                    _tabButton.Background = _activeColour;
                } else
                {
                    _tabButton.Background = _notActiveColour;
                }
                _active = value;
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public TabButton()
        {
            InitializeComponent();
            _notActiveColour = new SolidColorBrush(Color.FromRgb(127, 0, 0));
            _activeColour = new SolidColorBrush(Color.FromRgb(175, 0, 0));
            _tabImage.DataContext = this;
            _tabLabel.DataContext = this;
        }

        /// <summary>
        /// Event handler to show/hide the button text based on size
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event params</param>
        private void TabButton_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (e.NewSize.Width < 150)
            {
                _tabLabel.Visibility = Visibility.Collapsed;
            } else
            {
                _tabLabel.Visibility = Visibility.Visible;
            }
        }
    }
}
