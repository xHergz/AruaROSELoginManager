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

        event EventHandler<AccountLoginEventArgs> Login;

        event EventHandler<AccountEventArgs> AddAccount;

        event EventHandler<AccountEventArgs> DeleteAccount;

        event EventHandler<AccountEventArgs> UpdateAccount;

        event EventHandler<MoveAccountEventArgs> MoveAccount;

        void AddAccountToDisplay(string accountName, bool passwordSaved, string description, List<string> characters);

        void PromptForPassword(string accountName);
    }
}
