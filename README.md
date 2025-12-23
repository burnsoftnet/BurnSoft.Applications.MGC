# BurnSoft.Applications.MGC

![](https://img.shields.io/badge/license-MIT-blue.svg?maxAge=3600) 

This library was created to perform the main database function that the [My Gun Collection](https://github.com/burnsoftnet/MyGunCollection) Application.
This application was seperated from the project to be added to the site nuget package so we can also use this in the [My Loaders Log(https://github.com/burnsoftnet/MyLoadersLog)]
and any other related program.

You can view the API Docs by [Clicking Here](docs/README.md)

Additional [Developer Notes](docs/DeveloperNotes.md) are available.


## Resources
- [BurnSoft.Universal](https://github.com/burnsoftnet/BurnSoft.Universal)


[![Donate](https://www.paypalobjects.com/en_US/i/btn/btn_donateCC_LG.gif)](https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=JSW8XEMQVH4BE)]


## Release Log

### v1.7.4.46

* Fixed unit Tests to run on full
* Updated Unit Tests
* Added GunFullDetails List to pull all the data that is used in the XML Export to maybe also be used in the application to speed up and corrent some details and reduce code
* Fixed some Database Connection closure issues in the Pictures and Hotfixes section
* Added Additional HotFix Function to wait for database to be unlocked in admin mode for x seconds.
* Added online API Docs
* Added Verification Functions for ID Linking in the Main Tables and Unit Tests for those functions.
* Added Function TO add Raiting to firearm.
* Added new Rating field to GunCollection List containers
* Added to HotFix 10 the Create Rating Column
* Added to Hotfix 10 to set all ratings in gun collection to 0 after Raiting column is created.
* FIXED issue with When Adding a firearm at times, that the default barrel id for the stock barrel doesn't return an ID
* FIXED issue with Importing a Firearm where the Default Barrel ID and Model ID return 0.
* Added Function to produce and look up the ID of the Rating list.
* Added Function for Settings Picture Order, Reseting orders and addition List functions for the Picture Table
* Added General Accessories Table and Functions
* Added General Accessories Link Table and Functions
* Added Another Column to the Gun Accessories Table to link between the two types of accessories. If this was done in the first place it would be just the general and the link, but right now this is an experiment and I will see if the link table is needed as tests go on.
* Created Function to Check if table exists for hotfix section
* Added AutoFill for General Accessories
* Added Move, Delete, and Copy from firearm accessories to General Accessories
* Added Move to firearm accessories and delete from general accessories.

### v1.7.0.4

* Fixed issue with The Login Function
* Fixed Issue with the Needs Hot Fix Function
* Added Categories to Unit Test to Group By Traits in Test Explorer.
* Added Additional Function to Check Login or Enable Login Option in database, mostly used for the unit tests, but Can also be used in the program if needed.

### v1.7.0.0

- Initial Release
- Broke Away from teh MyGunCollection Repo.