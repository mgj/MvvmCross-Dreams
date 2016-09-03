## MvvmCross DREAMS

[![Build status](https://ci.appveyor.com/api/projects/status/d4m23jnmblte0j5e?svg=true)](https://ci.appveyor.com/project/mgj/mvvmcross-dreams)

MvvmCross DREAMS is an opinionated take on how to make an MvvmCross app. You can clone DREAMS, rename the application label and bundle identifier and be productive in minutes. No more worrying about naming conventions, PCL profiles, android support dependencies or which logging framework to use.  

### Now available as Visual Studio project template!

DREAMS is now available as a project template to make it even easier for you to get up and running as fast as possible. Just follow these steps:

1. Install the DREAMS project template
2. Add new project - type MvvmCross DREAMS Core. OBS: Must be postfixed with ".Core" ! For example: "MyProject.Core"
3. Add new project - type "MvvmCross DREAMS Droid". OBS: Must be postfixed with ".Droid" ! For example: "MyProject.Droid"
4. Change the build action for MyProject.Core.Common.DreamsResources.resx to be "Embedded Resource" instead of "Content"
5. Build and deploy the app!

### Features

*   "Normal" full screen navigation
*   Burgermenu navigation
*   Network and background tasks
*   Logging to console/logcat and logfile
*   Threadsafe dialogs

### Model-View-ViewModel (MVVM)

 The solution in structured around the Model-View-ViewModel (MVVM) pattern. For those unfamiliar with this pattern it basically boils down to this:  

*   Model: Data models, database etc.
*   View: UI. On android this often includes xml layout files, and on iOS xib files.
*   ViewModel: A "synthesized" version of the view, in which all the underlying data which must be presented by the view is made readily available in a way that is easily digestible by the view.

In addition to the 3 main layers, there is a collection of classes we should mention as well:  

*   Services: In order to keep our ViewModels small, much business logic is made available through services. Ideally, ViewModels should only contain properties that the View can bind to - all heavy lifting and business logic *should* be handled by a service. In practice, however, there are often exceptions to this rule, and making services for *everything* business logic related is overkill.


### Whats in this thing?
The folder structure aims to have folders separated by their feature rather than their type.  

The solution is released with 5 screens:  

*   <img src="https://artm.dk/files/github/mvvmcross-dreams/screenshots/1.png" width="180" height="320"><br />
    FirstView: Shows simple text binding between input fields and textviews. Shows navigation and passing of data to other viewmodels
*   <img src="https://artm.dk/files/github/mvvmcross-dreams/screenshots/2.png" width="180" height="320"><br />
    SecondView: Shows async initialization  (fetching data from network to show in view). The fetched data response is cached in a Realm.io database.
*   <img src="https://artm.dk/files/github/mvvmcross-dreams/screenshots/3.png" width="180" height="320"><br />
    ThirdView: Shows how to use lists. On android, the example shows how to get the Material Design feeling by collapsing the toolbar (previously known as the actionbar) when the user scrolls the list.
*   <img src="https://artm.dk/files/github/mvvmcross-dreams/screenshots/4.png" width="180" height="320"><br />
    FourthView: Shows how to make a burger menu
*   <img src="https://artm.dk/files/github/mvvmcross-dreams/screenshots/5.png" width="180" height="320"><br />
    FifthView: Shows how to use dialogs in a threadsafe manner

The solution uses NLog to log to the console and to disk (a logfile).  

###  Thanks to

*   [Stuart Lodge](https://github.com/slodge) and the community for [MvvmCross]([mvx])
*   [Martijn van Dijk](https://github.com/martijn00) for his contributions to [MvvmCross][mvx]
*   [Tomasz Cielecki](https://github.com/cheesebaron) for his MvvmCross plugins and contributions to [MvvmCross][mvx]
*   [James Montemagno](https://github.com/jamesmontemagno) for his MvvmCross plugins 
*   [Realm.io](http://realm.io) - Brilliant database
*   [Polly](https://github.com/App-vNext/Polly) - Brilliant error handling library
*   [NLog](http://nlog-project.org/) - Brilliant logging library
*   [Artm.dk](https://artm.dk)


### License

[Apache 2.0](https://www.apache.org/licenses/LICENSE-2.0.html)

[mvx]: https://github.com/slodge/MvvmCross
