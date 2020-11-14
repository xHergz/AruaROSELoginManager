using AruaRoseLoginManager.Data;

namespace AruaRoseLoginManager.Helpers
{
    public interface IAccountDisplay: ILoginDisplay<Account>
    {
        void Prompt(Account info);
    }
}
