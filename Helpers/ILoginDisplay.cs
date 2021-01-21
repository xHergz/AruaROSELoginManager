using System;

using AruaRoseLoginManager.Data;

namespace AruaRoseLoginManager.Helpers
{
    public interface ILoginDisplay<T>
    {
        event EventHandler<LoginEventArgs> LoginRequest;

        event EventHandler<DataEventArgs<T>> AddRequest;

        event EventHandler<ListEventArgs> DeleteRequest;

        event EventHandler<ListEventArgs> EditRequest;

        event EventHandler<DataEventArgs<T>> UpdateRequest;

        event EventHandler<MoveListItemEventArgs> MoveRequest;

        void AddToDisplay(T newItem);

        void ClearDisplay();
    }
}
