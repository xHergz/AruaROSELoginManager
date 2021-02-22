//
// FILE     : IManagerPanel.cs
// PROJECT  : AruaROSE Login Manager
// AUTHOR   : xHergz
// DATE     : 2021-02-19
//

using AruaRoseLoginManager.Data;

namespace AruaRoseLoginManager.Helpers
{
    /// <summary>
    /// An interface for the controller to interact with the manager panel front ends
    /// </summary>
    public interface IManagerPanel
    {
        /// <summary>
        /// Path to the folder that contains the ROSE client
        /// </summary>
        string RoseFolderPath { get; set; }

        /// <summary>
        /// Whether to run clients in admin mode
        /// </summary>
        bool RunAsAdmin { get; set; }

        /// <summary>
        /// The current window size
        /// </summary>
        WindowSize Size { get; set; }

        /// <summary>
        /// Account list display
        /// </summary>
        IAccountDisplay AccountDisplay { get; }

        /// <summary>
        /// Party list display
        /// </summary>
        IPartyDisplay PartyDisplay { get; }

        /// <summary>
        /// Displays a message box to the user
        /// </summary>
        /// <param name="message">The message to display</param>
        void ShowMessageBox(string message);
    }
}
