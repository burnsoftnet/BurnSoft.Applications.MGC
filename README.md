# BurnSoft.Applications.MGC

![](https://img.shields.io/badge/license-MIT-blue.svg?maxAge=3600) 

This library was created to perform the main database function that the [My Gun Collection](https://github.com/burnsoftnet/MyGunCollection) Application.
This application was seperated from the project to be added to the site nuget package so we can also use this in the [My Loaders Log(https://github.com/burnsoftnet/MyLoadersLog)]
and any other related program.

## Resources
- [BurnSoft.Universal](https://github.com/burnsoftnet/BurnSoft.Universal)


[![Donate](https://www.paypalobjects.com/en_US/i/btn/btn_donateCC_LG.gif)](https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=JSW8XEMQVH4BE)]


## Release Log

### v1.7.x.x

* Fixed unit Tests to run on full
* Added GunFullDetails List to pull all the data that is used in the XML Export to maybe also be used in the application to speed up and corrent some details and reduce code
* Fixed some Database Connection closure issues in the Pictures and Hotfixes section
* Added Additional HotFix Function to wait for database to be unlocked in admin mode for x seconds.

### v1.7.0.4

* Fixed issue with The Login Function
* Fixed Issue with the Needs Hot Fix Function
* Added Categories to Unit Test to Group By Traits in Test Explorer.
* Added Additional Function to Check Login or Enable Login Option in database, mostly used for the unit tests, but Can also be used in the program if needed.

### v1.7.0.0

- Initial Release
- Broke Away from teh MyGunCollection Repo.