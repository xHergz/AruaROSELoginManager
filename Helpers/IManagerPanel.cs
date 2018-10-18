using AruaROSELoginManager.Data;
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

        event EventHandler<AccountLoginEventArgs> Login;

        event EventHandler AddAccount;

        void AddNewAccount(string accountName, string description, List<string> characters);

        void PromptForPassword(string accountName);
    }
}
