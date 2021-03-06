﻿//
// FILE     : XmlAccountDatastore.cs
// PROJECT  : AruaROSE Login Manager
// AUTHOR   : xHergz
// DATE     : 2017-05-23
// 

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

using AruaRoseLoginManager.Data;

namespace AruaRoseLoginManager.DAL
{
    /// <summary>
    /// Stores/Loads account information with an XML file
    /// </summary>
    public class XmlAccountDatastore : IAccountDatastore
    {
        /// <summary>
        /// The save files name
        /// </summary>
        private const string FILE_NAME = "AccountManager.xml";

        /// <summary>
        /// The parent element name
        /// </summary>
        private const string MANAGER_ELEMENT = "AccountManager";

        /// <summary>
        /// The account element name
        /// </summary>
        private const string ACCOUNT_ELEMENT = "Account";

        /// <summary>
        /// The character element name
        /// </summary>
        private const string CHARACTER_ELEMENT = "Character";

        /// <summary>
        /// The party element name
        /// </summary>
        private const string PARTY_ELEMENT = "Party";

        /// <summary>
        /// The member element name (account that is part of a party)
        /// </summary>
        private const string MEMBER_ELEMENT = "Member";

        /// <summary>
        /// The parent elements attribute to hold the ROSE folder path
        /// </summary>
        private const string FOLDER_ATTRIBUTE = "roseFolder";

        /// <summary>
        /// The parent elements attribute to hold the run as admin flag
        /// </summary>
        private const string RUN_AS_ADMIN_ATTRIBUTE = "runAsAdmin";

        /// <summary>
        /// The parent elements attribute to hold the window height
        /// </summary>
        private const string WINDOW_HEIGHT_ATTRIBUTE = "windowHeight";

        /// <summary>
        /// The parent elements attribute to hold window width
        /// </summary>
        private const string WINDOW_WIDTH_ATTRIBUTE = "windowWidth";

        /// <summary>
        /// The account elements attribute to hold the username
        /// </summary>
        private const string USERNAME_ATTRIBUTE = "username";

        /// <summary>
        /// The account elements attribute to hold the password
        /// </summary>
        private const string PASSWORD_ATTRIBUTE = "password";

        /// <summary>
        /// The account elements attribute to hold the description
        /// </summary>
        private const string DESCRIPTION_ATTRIBUTE = "description";

        /// <summary>
        /// The party element's attribute to hold the name.
        /// </summary>
        private const string NAME_ATTRIBUTE = "name";

        /// <summary>
        /// The document object of the save file
        /// </summary>
        private XDocument _saveFile;

        /// <summary>
        /// The path to the folder to save in
        /// </summary>
        private string _folderPath;

        /// <summary>
        /// The complete path to the save file itself
        /// </summary>
        private string _completeFilePath;

        /// <summary>
        /// Constructor
        /// </summary>
        public XmlAccountDatastore()
        {
            //Get the app data folder
            _folderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
                + @"\AruaROSELoginManager\";

            //Make sure the app data folder exists from the installer
            if (!Directory.Exists(_folderPath))
            {
                Directory.CreateDirectory(_folderPath);
            }

            _completeFilePath = _folderPath + FILE_NAME;
        }

        /// <summary>
        /// Loads all the account from the XML document
        /// </summary>
        /// <returns>A list of Account's loaded</returns>
        public List<Account> GetAllAccounts()
        {
            List<Account> loadedAccounts = new List<Account>();

            if (File.Exists(_completeFilePath))
            {
                _saveFile = XDocument.Load(_completeFilePath);
                XElement root = _saveFile.Element(MANAGER_ELEMENT);

                //Loop through the Account elements
                foreach (XElement accountElement in root.Elements(ACCOUNT_ELEMENT))
                {
                    string currentUsername = (string)accountElement.Attribute(USERNAME_ATTRIBUTE);
                    string currentPassword = (string)accountElement.Attribute(PASSWORD_ATTRIBUTE);
                    string description = (string)accountElement.Attribute(DESCRIPTION_ATTRIBUTE);
                    List<string> characters = new List<string>();
                    foreach (XElement characterElement in accountElement.Elements(CHARACTER_ELEMENT))
                    {
                        characters.Add(characterElement.Value);
                    }
                    Account current = new Account(currentUsername, currentPassword, description, characters);
                    loadedAccounts.Add(current);
                }
            }            

            return loadedAccounts;
        }

        /// <summary>
        /// Loads all the parties from the XML document
        /// </summary>
        /// <returns>The list of parties</returns>
        public List<Party> GetAllParties()
        {
            List<Party> loadedParties = new List<Party>();

            if (File.Exists(_completeFilePath))
            {
                _saveFile = XDocument.Load(_completeFilePath);
                XElement root = _saveFile.Element(MANAGER_ELEMENT);

                //Loop through the Account elements
                foreach (XElement partyElement in root.Elements(PARTY_ELEMENT))
                {
                    string currentPartyName = (string)partyElement.Attribute(NAME_ATTRIBUTE);
                    string description = (string)partyElement.Attribute(DESCRIPTION_ATTRIBUTE);
                    List<string> accounts = new List<string>();
                    foreach (XElement accountElement in partyElement.Elements(MEMBER_ELEMENT))
                    {
                        accounts.Add(accountElement.Value);
                    }
                    Party current = new Party(currentPartyName, accounts, description);
                    loadedParties.Add(current);
                }
            }

            return loadedParties;
        }

        /// <summary>
        /// Gets the file path for the ROSE folder
        /// </summary>
        /// <returns>ROSE folder file path</returns>
        public string GetFilePath()
        {
            string filePath = string.Empty;

            if (File.Exists(_completeFilePath))
            {
                _saveFile = XDocument.Load(_completeFilePath);

                //Loops through the parent element (Should only be one)
                foreach (XElement accountManagerElement in _saveFile.Descendants(MANAGER_ELEMENT))
                {
                    filePath = (string)accountManagerElement.Attribute(FOLDER_ATTRIBUTE);
                }
            }            

            return filePath;
        }

        /// <summary>
        /// Gets the status for running as admin
        /// </summary>
        /// <returns>True/False whether to run as admin</returns>
        public bool GetRunAsAdmin()
        {
            bool runAsAdmin = false;

            if (File.Exists(_completeFilePath))
            {
                _saveFile = XDocument.Load(_completeFilePath);

                //Loops through the parent element (Should only be one)
                foreach (XElement accountManagerElement in _saveFile.Descendants(MANAGER_ELEMENT))
                {
                    runAsAdmin = (bool)accountManagerElement.Attribute(RUN_AS_ADMIN_ATTRIBUTE);
                }
            }

            return runAsAdmin;
        }

        /// <summary>
        /// Loads the window size from the XML document
        /// </summary>
        /// <returns>The window size with width and height</returns>
        public WindowSize GetWindowSize()
        {
            WindowSize windowSize = WindowSize.Default;

            if (File.Exists(_completeFilePath))
            {
                _saveFile = XDocument.Load(_completeFilePath);
                XElement accountManagerElement =_saveFile.Descendants(MANAGER_ELEMENT).FirstOrDefault();
                if (
                    accountManagerElement != null
                    && accountManagerElement.Attribute(WINDOW_WIDTH_ATTRIBUTE) != null
                    && accountManagerElement.Attribute(WINDOW_HEIGHT_ATTRIBUTE) != null
                    && int.TryParse(accountManagerElement.Attribute(WINDOW_WIDTH_ATTRIBUTE).Value, out int width)
                    && int.TryParse(accountManagerElement.Attribute(WINDOW_HEIGHT_ATTRIBUTE).Value, out int height)
                )
                {
                    windowSize = new WindowSize() { Height = height, Width = width };
                }
            }

            return windowSize;
        }

        /// <summary>
        /// Saves all the login manager data to the XML file
        /// </summary>
        /// <param name="filePath">The path to the ROSE folder</param>
        /// <param name="allAccounts">The list of accounts to save</param>
        public void SaveManagerData(string filePath, bool runAdAdmin, WindowSize size, List<Account> allAccounts, List<Party> allParties)
        {
            _saveFile = new XDocument();

            //Create the manager element with the file path
            XElement managerElement = new XElement(MANAGER_ELEMENT);
            managerElement.Add(new XAttribute(FOLDER_ATTRIBUTE, filePath));
            managerElement.Add(new XAttribute(RUN_AS_ADMIN_ATTRIBUTE, runAdAdmin));
            managerElement.Add(new XAttribute(WINDOW_HEIGHT_ATTRIBUTE, size.Height));
            managerElement.Add(new XAttribute(WINDOW_WIDTH_ATTRIBUTE, size.Width));

            //Create the account elements
            foreach (Account account in allAccounts)
            {
                XElement accountElement = new XElement(ACCOUNT_ELEMENT);
                accountElement.Add(new XAttribute(USERNAME_ATTRIBUTE, account.Username));
                accountElement.Add(new XAttribute(PASSWORD_ATTRIBUTE, account.PasswordHash));
                if (!string.IsNullOrWhiteSpace(account.Description))
                {
                    accountElement.Add(new XAttribute(DESCRIPTION_ATTRIBUTE, account.Description));
                }
                foreach(string characterName in account.Characters)
                {
                    accountElement.Add(new XElement(CHARACTER_ELEMENT, characterName));
                }

                managerElement.Add(accountElement);
            }

            // Create the party elements
            foreach(Party party in allParties)
            {
                XElement partyElement = new XElement(PARTY_ELEMENT);
                partyElement.Add(new XAttribute(NAME_ATTRIBUTE, party.Name));
                if (!string.IsNullOrWhiteSpace(party.Description))
                {
                    partyElement.Add(new XAttribute(DESCRIPTION_ATTRIBUTE, party.Description));
                }
                foreach (string accountName in party.Accounts)
                {
                    partyElement.Add(new XElement(MEMBER_ELEMENT, accountName));
                }

                managerElement.Add(partyElement);
            }

            _saveFile.Add(managerElement);
            _saveFile.Save(_completeFilePath);  
        }
    }
}
