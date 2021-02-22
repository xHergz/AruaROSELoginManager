//
// FILE     : BasicListDisplay.xaml.cs
// PROJECT  : AruaROSE Login Manager
// AUTHOR   : xHergz
// DATE     : 2021-02-18
// 

using System;
using System.Windows;
using System.Windows.Controls;

using AruaRoseLoginManager.Data;

namespace AruaRoseLoginManager.Controls
{
    /// <summary>
    /// Interaction logic for BasicListDisplay.xaml
    /// </summary>
    public partial class BasicListDisplay : UserControl
    {
        /// <summary>
        /// Unique identifier for the list item
        /// </summary>
        private string _identifier;

        /// <summary>
        /// Event to raise when the delete button is pressed
        /// </summary>
        public event EventHandler<ListEventArgs> DeleteListItem;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">A unqiue identifier for the list item</param>
        /// <param name="description">Description to display for the list item</param>
        public BasicListDisplay(string id, string description)
        {
            InitializeComponent();
            _identifier = id;
            _descriptionLabel.Text = description;
        }

        /// <summary>
        /// Event handler for the delete button
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event args</param>
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender != null && DeleteListItem != null)
            {
                ListEventArgs args = new ListEventArgs()
                {
                    Id = _identifier
                };
                DeleteListItem(this, args);
            }
        }
    }
}
