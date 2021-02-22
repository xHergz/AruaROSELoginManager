//
// FILE     : LinkButton.xaml.cs
// PROJECT  : AruaROSE Login Manager
// AUTHOR   : xHergz
// DATE     : 2021-02-18
// 

using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace AruaRoseLoginManager.Controls
{
    /// <summary>
    /// Interaction logic for LinkButton.xaml
    /// </summary>
    public partial class LinkButton : UserControl
    {
        /// <summary>
        /// The image source uri
        /// </summary>
        [Browsable(true)]
        public string ImageSource { get; set; }

        /// <summary>
        /// Button text
        /// </summary>
        [Browsable(true)]
        public string Text { get; set; }

        /// <summary>
        /// Button hyperlink
        /// </summary>
        [Browsable(true)]
        public string Link { get; set; }

        /// <summary>
        /// Button background colour
        /// </summary>
        [Browsable(true)]
        public string Colour { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public LinkButton()
        {
            InitializeComponent();
            _linkButton.DataContext = this;
            _linkImage.DataContext = this;
            _linkLabel.DataContext = this;
        }

        /// <summary>
        /// Event to handle clicking the button and opening the link
        /// </summary>
        /// <param name="sender">Event args</param>
        /// <param name="e">Event args</param>
        public void LinkButton_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(Link);
        }
    }
}
