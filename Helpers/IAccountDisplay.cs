using AruaRoseLoginManager.Data;
using AruaRoseLoginManager.Enum;
using System;

namespace AruaRoseLoginManager.Helpers
{
    public interface IAccountDisplay: ILoginDisplay<Account>
    {
        event EventHandler<LoginWithPassEventArgs> PromptedLoginRequest;

        void Prompt(Account info);

        void PromptForPassword(string username, Server serverId);
    }
}
