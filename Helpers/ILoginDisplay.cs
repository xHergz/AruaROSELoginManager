//
// FILE     : ILoginDisplay.cs
// PROJECT  : AruaROSE Login Manager
// AUTHOR   : xHergz
// DATE     : 2021-02-19
//

using System;

using AruaRoseLoginManager.Data;
using AruaRoseLoginManager.Enum;

namespace AruaRoseLoginManager.Helpers
{
    /// <summary>
    /// Interface for common things a display with login capabilities needs
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ILoginDisplay<T>
    {
        /// <summary>
        /// Event to raise when there is a login request
        /// </summary>
        event EventHandler<LoginEventArgs> LoginRequest;

        /// <summary>
        /// Event to raise when there is a request to add a new item to the display
        /// </summary>
        event EventHandler<DataEventArgs<T>> AddRequest;

        /// <summary>
        /// Event to raise when there is a request to delete an item from the display
        /// </summary>
        event EventHandler<ListEventArgs> DeleteRequest;

        /// <summary>
        /// Event to raise when there is a request to edit an item in the display
        /// </summary>
        event EventHandler<ListEventArgs> EditRequest;

        /// <summary>
        /// Event to raise when there is a request to update an item in the display
        /// </summary>
        event EventHandler<DataEventArgs<T>> UpdateRequest;

        /// <summary>
        /// Event to raise when there is a request to move an item in the display
        /// </summary>
        event EventHandler<MoveListItemEventArgs> MoveRequest;

        /// <summary>
        /// Adds a new item to the display
        /// </summary>
        /// <param name="newItem">New item to add</param>
        void AddToDisplay(T newItem);

        /// <summary>
        /// Clears the current display
        /// </summary>
        void ClearDisplay();

        /// <summary>
        /// Switches between the different panels of the display
        /// </summary>
        /// <param name="newMode"></param>
        void SwitchPanels(PanelMode newMode);
    }
}
