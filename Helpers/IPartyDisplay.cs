using System;
using System.Collections.Generic;

using AruaRoseLoginManager.Data;

namespace AruaRoseLoginManager.Helpers
{
    public interface IPartyDisplay: ILoginDisplay<Party>
    {
        event EventHandler<EventArgs> NewRequest;

        void Prompt(IEnumerable<string> accounts);

        void Prompt(IEnumerable<string> accounts, Party info);
    }
}
