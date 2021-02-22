//
// FILE     : PartyDisplay.xaml.cs
// PROJECT  : AruaROSE Login Manager
// AUTHOR   : xHergz
// DATE     : 2021-02-18
//

using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

using AruaRoseLoginManager.Data;
using AruaRoseLoginManager.Enum;
using AruaRoseLoginManager.Helpers;

namespace AruaRoseLoginManager.Controls
{
    /// <summary>
    /// Interaction logic for PartyDisplay.xaml
    /// </summary>
    public partial class PartyDisplay : UserControl, IPartyDisplay
    {
        /// <summary>
        /// The current panel being displayed
        /// </summary>
        private PanelMode _partyMode = PanelMode.Select;

        /// <summary>
        /// Constructor
        /// </summary>
        public PartyDisplay()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Event raised when the New Party button is clicked
        /// </summary>
        public event EventHandler<EventArgs> NewRequest;

        /// <summary>
        /// Event raised when one of the login buttons are clicked
        /// </summary>
        public event EventHandler<LoginEventArgs> LoginRequest;

        /// <summary>
        /// Event raised when saving a new party
        /// </summary>
        public event EventHandler<DataEventArgs<Party>> AddRequest;

        /// <summary>
        /// Event raised when deleting a party
        /// </summary>
        public event EventHandler<ListEventArgs> DeleteRequest;

        /// <summary>
        /// Event raised when selecting a party to edit
        /// </summary>
        public event EventHandler<ListEventArgs> EditRequest;

        /// <summary>
        /// Event raised when trying to save the editted party
        /// </summary>
        public event EventHandler<DataEventArgs<Party>> UpdateRequest;

        /// <summary>
        /// Event raised when trying to move a party within the list
        /// </summary>
        public event EventHandler<MoveListItemEventArgs> MoveRequest;

        /// <summary>
        /// Adds a new party to the list
        /// </summary>
        /// <param name="newItem">The new party</param>
        public void AddToDisplay(Party newItem)
        {
            ListDisplay newDisplay = new ListDisplay(
                _partyStackPanel.Children.Count,
                newItem
            );
            newDisplay.Login += PartyDisplay_LoginRequest;
            newDisplay.EditListItem += PartyDisplay_EditRequest;
            newDisplay.MoveListItem += PartyDisplay_MoveRequest;
            newDisplay.DeleteListItem += PartyDisplay_DeleteRequest;
            _partyStackPanel.Children.Add(newDisplay);
            for (int i = 0; i < _partyStackPanel.Children.Count; i++)
            {
                ListDisplay display = (ListDisplay)_partyStackPanel.Children[i];
                display.UpdateDisplay(i, _partyStackPanel.Children.Count);
            }
        }

        /// <summary>
        /// Clears the party list
        /// </summary>
        public void ClearDisplay()
        {
            _partyStackPanel.Children.Clear();
        }

        /// <summary>
        /// Populates the party form for a brand new party
        /// </summary>
        /// <param name="accounts">Accounts eligible to be added to a party</param>
        public void Prompt(IEnumerable<string> accounts)
        {
            _partyForm.ClearFields();
            _partyForm.PopulateAccounts(accounts);
            SwitchPanels(PanelMode.New);
        }

        /// <summary>
        /// Populates the party form for editting a party
        /// </summary>
        /// <param name="accounts">Accounts eligible to be added to the party</param>
        /// <param name="info">The current party info</param>
        public void Prompt(IEnumerable<string> accounts, Party info)
        {
            _partyForm.ClearFields();
            _partyForm.PopulateFields(info);
            _partyForm.PopulateAccounts(accounts);
            SwitchPanels(PanelMode.Edit);
        }

        /// <summary>
        /// Switch to a different screen within the party display
        /// </summary>
        /// <param name="newMode">New screen to display</param>
        public void SwitchPanels(PanelMode newMode)
        {
            _addPartyButton.Visibility = Visibility.Hidden;
            _partyStackPanel.Visibility = Visibility.Hidden;
            _partyDisplayScrollViewer.Visibility = Visibility.Hidden;
            _partyForm.Visibility = Visibility.Hidden;
            _partyMode = newMode;
            switch (newMode)
            {
                case PanelMode.New:
                    _partyForm.Visibility = Visibility.Visible;
                    _partyForm.FocusPrimary();
                    break;
                case PanelMode.Edit:
                    _partyForm.Visibility = Visibility.Visible;
                    break;
                case PanelMode.Login:

                    break;
                case PanelMode.Select:
                default:
                    _addPartyButton.Visibility = Visibility.Visible;
                    _partyStackPanel.Visibility = Visibility.Visible;
                    _partyDisplayScrollViewer.Visibility = Visibility.Visible;
                    break;
            }
        }

        /// <summary>
        /// Event handler for clicking the New Party button
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event args</param>
        private void NewPartyButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender != null && NewRequest != null)
            {
                NewRequest(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Event handler for clicking either of the login party buttons
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event args</param>
        private void PartyDisplay_LoginRequest(object sender, LoginEventArgs e)
        {
            if (sender != null && LoginRequest != null)
            {
                LoginRequest(sender, e);
            }
        }

        /// <summary>
        /// Event handler for clicking the edit button for a party
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event args</param>
        private void PartyDisplay_EditRequest(object sender, ListEventArgs e)
        {
            if (sender != null && EditRequest != null)
            {
                EditRequest(sender, e);
            }
        }

        /// <summary>
        /// Event handler for clicking one of the move buttons for a party
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event args</param>
        private void PartyDisplay_MoveRequest(object sender, MoveListItemEventArgs e)
        {
            if (sender != null && MoveRequest != null)
            {
                MoveRequest(sender, e);
            }
        }

        /// <summary>
        /// Event handler for clicking the delete button for a party
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event args</param>
        private void PartyDisplay_DeleteRequest(object sender, ListEventArgs e)
        {
            if (sender != null && DeleteRequest != null)
            {
                DeleteRequest(sender, e);
            }
        }

        /// <summary>
        /// Event handler for clicking the cancel button on the party form
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event args</param>
        private void PartyForm_Cancel(object sender, EventArgs e)
        {
            SwitchPanels(PanelMode.Select);
        }

        /// <summary>
        /// Event handler for clicking the save button on the party form
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event args</param>
        private void PartyForm_SaveParty(object sender, DataEventArgs<Party> e)
        {
            EventHandler<DataEventArgs<Party>> actionHandler = _partyMode == PanelMode.New
                ? AddRequest
                : UpdateRequest;
            if (sender != null && actionHandler != null)
            {
                actionHandler(sender, e);
                SwitchPanels(PanelMode.Select);
            }
        }

    }
}
