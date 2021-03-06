# AruaROSE Login Manager
A WPF application is used to automatically log in to the free to play MMORPG, [AruaROSE](http://www.aruarose.com). You enter your account information which is saved in a XML file in your AppData folder. You can then use one of the login buttons on an account that will open the TRose.exe application with the command line arguments to automatically log you in to the specified server. The program can either store just the account name and will prompt you for the password only or can store both (password MD5 encrypted because it is supported by the game client).

![](https://i.imgur.com/rGP5n2f.png)

## Features
* Account List
    * Save accounts with username, password, description, and character names
	* Edit/Delete account information
	* Move accounts up/down in the list
* Party List
	* Create a party with 2 or more accounts that have a password saved to open multiple clients at once
	* Edit/Delete party information
	* Move parties up/down in the list
* Options
	* Choose to run the client as admin to make sure it has additional privileges
	* Choose a window size preset
* Info
	* Links to the Arua Armory, Arua Discord, Login Manager Source Code, and a forum thread to post suggestions/bugs
* Misc
	* Add custom emblems for the account list
	* Window size persists across uses
	* Backwards compatible with v1 (i.e. v1 can open and use v2 saves and vice versa)

## How to use
1. Download the latest release
	+ [Found Here](https://github.com/xHergz/AruaROSELoginManager/releases/download/v2.0.0/v2-0-0.zip)
2. Extract the contents to a folder
    + i.e. `C:\Users\<user>\AppData\Local\AruaROSELoginManager`
3. Run the program
    + [Instructions](https://imgur.com/a/k31URBX)
4. Close the application to save new data to the XML file

## Where is the info stored?
The info you enter is stored in a XML file saved to your AppData/Roaming folder. To get there you can open up the Windows search bar from the Windows button and type %AppData% and hit enter. You will see a AruaROSELoginManager folder with a XML file inside (if you have run the application and closed it). You will see if you specified a password for the account it is stored in an MD5 hash. Here is what the file contents will look like:

![](https://i.imgur.com/m1iH5GV.png)

## Custom emblems
The installer will provide 15 emblems that are taken from the game itself. If you wish to add your own emblems, simply go to the AruaROSELoginManager/Images folder. Delete any "emblemX.png" files you don't want and add any pictures you want to use as emblems. These need to be PNG images and be named emblemX.png where X is the order you want it displayed in. These must be in order or it won't load them. The resolution I used is 75x75, but any resolution will work. Here is an example:

![](https://i.imgur.com/zQdC24Z.png)

## Assets
+ Most of the icons used are from the [Material Design Icons](https://material.io/resources/icons/?style=baseline)
+ The emblems that come with the application are taken from the [AruaROSE Armory](http://armory.aruarose.com)

<!-- Imgur album with the pictures: https://imgur.com/a/k31URBX -->
