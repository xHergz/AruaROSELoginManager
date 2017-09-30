# AruaROSELoginManager
A Windows Form application that automatically logs in accounts to AruaROSE

## What is this?
This application is used to automatically login the free to play MMORPG, [AruaROSE](http://www.aruarose.com). You enter your account information which is saved in an XML file in your AppData folder. You can then use "Login" button on an account that will open the TRose.exe application with the command line arguments to automatically log you in. The program can either store just the account name and will prompt you for the password only or can store both (password MD5 encrypted because it is supported by the game client).

## How to setup
1. Run the installer
	+ [Found Here](https://www.mediafire.com/file/q4jltrm8hz15vca/AruaROSELoginManagerSetup.msi)
2. Choose the destination folder
3. Run the program

## How to use
1. Open the application
2. Use the Locate button to find your AruaROSE folder.

![](https://imgur.com/xffXUQH.png)

3. Use the + button to add an account

![](https://imgur.com/MHNAaIr.png)

4. Use the actions buttons
	+ Login: Opens a new game client that will be logged in to that account.
  	+ Up Arrow: Move that account up in the list.
  	+ Down Arrow: Move that account down in the list.
  	+ X Button: Delete that account from the list.

![](https://imgur.com/aLBjfCM.png)

5. Close the application to save the new data to the XML File

[Pictures](https://imgur.com/a/wWsqK)
