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

## Where is the info stored?
The info you enter is stored in a XML file saved to your AppData/Roaming folder. To get there you can open up the Windows search bar from the Windows button and type %AppData% and hit enter. You will see a AruaROSELoginManager folder with an XML file inside if you have run the application and closed it. You will see if you specified a password for the account it is stored in an MD5 hash. Here is what the file contents will look like:

![](https://imgur.com/gtSaIHn.png)

## Custom emblems
The installer will install 15 emblems that are taken from the game itself. These images are not included here in the source code here. If you wish to add your own emblems, simply go to the AruaROSELoginManager/Images folder. Delete any "emblemX.png" files you don't want and add any pictures you want to use as emblems. These need to be PNG images and by named emblemX.png where X is the order you want it displayed in. These must be in order or it won't load them. Here is an example:

![](https://imgur.com/uri6n1f.png)

## Assets
+ The background is a screenshot taken by me in AruaROSE.
+ The "+" button was made by me in paint.
+ The up/down arrows and the delete button are from [FatCow](http://www.fatcow.com/free-icons)
+ The emblems that come with the installer are taken from the [AruaROSE Armory](http://armory.aruarose.com)

<!-- Imgur album with the pictures: https://imgur.com/a/wWsqK)) -->
