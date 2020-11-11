using AruaRoseLoginManager.Enum;
using AruaRoseLoginManager.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AruaRoseLoginManager.Helpers
{
    public interface IManagerPanel
    {
        string RoseFolderPath { get; set; }

        bool RunAsAdmin { get; set; }

        WindowSize Size { get; set; }

        event EventHandler<LoginEventArgs> Login;

        event EventHandler<AccountEventArgs> AddAccount;

        event EventHandler<ListEventArgs> DeleteAccount;

        event EventHandler<ListEventArgs> EditAccount;

        event EventHandler<AccountEventArgs> UpdateAccount;

        event EventHandler<MoveListItemEventArgs> MoveAccount;

        event EventHandler LoginParty;

        void AddAccountToDisplay(Account account);

        void ClearDisplay();

        void PromptForAccount(Account info);

        string PromptForPassword(string accountName);

        void ShowMessageBox(string message);
    }
}
