//
// FILE     : MoveListItemEventArgs.cs
// PROJECT  : AruaROSE Login Manager
// AUTHOR   : xHergz
// DATE     : 2021-02-19
// 

using AruaRoseLoginManager.Enum;

namespace AruaRoseLoginManager.Data
{
    public class MoveListItemEventArgs : ListEventArgs
    {
        /// <summary>
        /// The direction to move the item
        /// </summary>
        public MovementDirection Direction;
    }
}
