﻿using AruaRoseLoginManager.Enum;
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

        event EventHandler<AccountEventArgs> DeleteAccount;

        event EventHandler<AccountEventArgs> UpdateAccount;

        event EventHandler<MoveAccountEventArgs> MoveAccount;

        void AddAccountToDisplay(Account account);

        string PromptForPassword(string accountName);

        void ShowMessageBox(string message);
    }
}
