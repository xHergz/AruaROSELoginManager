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
        private string _identifier;

        /// <summary>
        /// Event to raise when the delete button is pressed
        /// </summary>
        public event EventHandler<ListEventArgs> DeleteListItem;

        public BasicListDisplay(string id, string description)
        {
            InitializeComponent();
            _identifier = id;
            _descriptionLabel.Text = description;
        }

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
