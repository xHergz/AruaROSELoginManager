//
// FILE     : Party.cs
// PROJECT  : AruaROSE Login Manager
// AUTHOR   : xHergz
// DATE     : 2020-07-02
// 

using System.Collections.Generic;

namespace AruaRoseLoginManager.Data
{
    /// <summary>
    /// Holds the information for a party of characters
    /// </summary>
    public class Party
    {
        public string Name { get; private set; }

        public List<string> Accounts { get; private set; }

        public string Description { get; private set; }

        public Party(string name, List<string> accounts, string description = "")
        {
            Name = name;
            Accounts = accounts;
            Description = description;
        }
    }
}
