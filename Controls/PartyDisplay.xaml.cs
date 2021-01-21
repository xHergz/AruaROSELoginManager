using AruaRoseLoginManager.Data;
using AruaRoseLoginManager.Enum;
using AruaRoseLoginManager.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AruaRoseLoginManager.Controls
{
    /// <summary>
    /// Interaction logic for PartyDisplay.xaml
    /// </summary>
    public partial class PartyDisplay : UserControl, IPartyDisplay
    {
        private PanelMode _partyMode = PanelMode.Select;

        public PartyDisplay()
        {
            InitializeComponent();
        }

        public event EventHandler<EventArgs> NewRequest;

        public event EventHandler<LoginEventArgs> LoginRequest;

        public event EventHandler<DataEventArgs<Party>> AddRequest;

        public event EventHandler<ListEventArgs> DeleteRequest;

        public event EventHandler<ListEventArgs> EditRequest;

        public event EventHandler<DataEventArgs<Party>> UpdateRequest;

        public event EventHandler<MoveListItemEventArgs> MoveRequest;

        public void AddToDisplay(Party newItem)
        {
            ListDisplay newDisplay = new ListDisplay(
                PartyStackPanel.Children.Count,
                newItem
            );
            newDisplay.Login += PartyDisplay_LoginRequest;
            newDisplay.EditListItem += PartyDisplay_EditRequest;
            newDisplay.MoveListItem += PartyDisplay_MoveRequest;
            newDisplay.DeleteListItem += PartyDisplay_DeleteRequest;
            PartyStackPanel.Children.Add(newDisplay);
            for (int i = 0; i < PartyStackPanel.Children.Count; i++)
            {
                ListDisplay display = (ListDisplay)PartyStackPanel.Children[i];
                display.UpdateDisplay(i, PartyStackPanel.Children.Count);
            }
        }

        public void ClearDisplay()
        {
            PartyStackPanel.Children.Clear();
        }

        public void Prompt(IEnumerable<string> accounts)
        {
            _partyForm.ClearFields();
            _partyForm.PopulateAccounts(accounts);
            SwitchPartyPanels(PanelMode.New);
        }

        public void Prompt(IEnumerable<string> accounts, Party info)
        {
            _partyForm.PopulateAccounts(accounts);
            _partyForm.PopulateFields(info);
            SwitchPartyPanels(PanelMode.Edit);
        }

        private void SwitchPartyPanels(PanelMode newMode)
        {
            _addPartyButton.Visibility = Visibility.Hidden;
            PartyStackPanel.Visibility = Visibility.Hidden;
            _partyDisplayScrollViewer.Visibility = Visibility.Hidden;
            _partyForm.Visibility = Visibility.Hidden;
            _partyMode = newMode;
            switch (newMode)
            {
                case PanelMode.New:
                    _partyForm.ClearFields();
                    _partyForm.Visibility = Visibility.Visible;
                    break;
                case PanelMode.Edit:
                    _partyForm.Visibility = Visibility.Visible;
                    break;
                case PanelMode.Login:

                    break;
                case PanelMode.Select:
                default:
                    _addPartyButton.Visibility = Visibility.Visible;
                    PartyStackPanel.Visibility = Visibility.Visible;
                    _partyDisplayScrollViewer.Visibility = Visibility.Visible;
                    break;
            }
        }

        private void NewPartyButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender != null && NewRequest != null)
            {
                NewRequest(this, EventArgs.Empty);
            }
        }

        private void PartyDisplay_LoginRequest(object sender, LoginEventArgs e)
        {
            if (sender != null && LoginRequest != null)
            {
                LoginRequest(sender, e);
            }
        }

        private void PartyDisplay_EditRequest(object sender, ListEventArgs e)
        {
            if (sender != null && EditRequest != null)
            {
                EditRequest(sender, e);
            }
        }

        private void PartyDisplay_MoveRequest(object sender, MoveListItemEventArgs e)
        {
            if (sender != null && MoveRequest != null)
            {
                MoveRequest(sender, e);
            }
        }

        private void PartyDisplay_DeleteRequest(object sender, ListEventArgs e)
        {
            if (sender != null && DeleteRequest != null)
            {
                DeleteRequest(sender, e);
            }
        }

        private void PartyForm_Cancel(object sender, EventArgs e)
        {
            SwitchPartyPanels(PanelMode.Select);
        }

        private void PartyForm_SaveParty(object sender, DataEventArgs<Party> e)
        {
            EventHandler<DataEventArgs<Party>> actionHandler = _partyMode == PanelMode.New
                ? AddRequest
                : UpdateRequest;
            if (sender != null && actionHandler != null)
            {
                actionHandler(sender, e);
                SwitchPartyPanels(PanelMode.Select);
            }
        }

    }
}
