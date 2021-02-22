//
// FILE     : Party.cs
// PROJECT  : AruaROSE Login Manager
// AUTHOR   : xHergz
// DATE     : 2021-02-19
// 

using System.Collections.Generic;

namespace AruaRoseLoginManager.Data
{
    /// <summary>
    /// Holds the information for a party of characters
    /// </summary>
    public class Party
    {
        /// <summary>
        /// Party name (unique identifier)
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Account usernames in the party
        /// </summary>
        public List<string> Accounts { get; private set; }

        /// <summary>
        /// A description of the party
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Party name</param>
        /// <param name="accounts">Account usernames in the party</param>
        /// <param name="description">A description of the party</param>
        public Party(string name, List<string> accounts, string description = "")
        {
            Name = name;
            Accounts = accounts;
            Description = description;
        }
    }
}
