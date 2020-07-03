using System;

using AruaRoseLoginManager.Enum;

namespace AruaRoseLoginManager.Data
{
    public class MoveListItemEventArgs : EventArgs
    {
        public string Id;

        public MovementDirection Direction;
    }
}
