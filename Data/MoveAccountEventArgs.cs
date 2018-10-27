using System;

using AruaRoseLoginManager.Enum;

namespace AruaRoseLoginManager.Data
{
    public class MoveAccountEventArgs : EventArgs
    {
        public Account Account;

        public MovementDirection Direction;
    }
}
