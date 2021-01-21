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

        IAccountDisplay AccountDisplay { get; }

        IPartyDisplay PartyDisplay { get; }

        string PromptForPassword(string accountName);

        void ShowMessageBox(string message);
    }
}
