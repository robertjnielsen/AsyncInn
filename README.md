# AsyncInn

_Authors:_
- [Harlen Lopez](https://github.com/harlenlopez)
- [Robert James Nielsen](https://github.com/robertjnielsen)

## Table Of Contents
I. [Overview](#overview)  
II. [Tools Used](#tools-used)  
III. [Getting Started](#getting-started)  
IV. [Visuals](#visuals)  
V. [Change Log](#change-log)  

## Overview

#### Problem Domain

The owners of “Async Inn” have approached you with plans to renovate their hotel chain. Currently they are tracking all the different locations and rooms in spreadsheets and binders. They currently have about 10 binders full of paperwork that consists of the difference between each location and the pricing for each room. The amount of time and paperwork it takes to manage the rooms and locations is costing the company both time and money. They are currently looking for a “better way” to maintain their business model.

They are currently looking for a RESTful API server that will allow them to better manage the assets in their hotels. They are anticipating the ability to modify and manage rooms, amenities, and new hotel locations as they are built. They have turned to you to assist them in persisting their data across a relational database and maintain its integrity as they make changes to the system.

#### Application Specifics

Here are the requirements that you obtained from your client during your exploration and requirements meeting.

The hotel is named “Async Inn” and has many nationwide locations. Each location will have a name, city, state, address, and phone number.

Async Inn prides themselves on their unique layout designs of each hotel room. They advertise as it being your “apartment for the night”. This means they have invested a lot of resources into how each room looks and feels. Some have one bedroom, others have 2 bedrooms, while a few are more of a cozy studio. The team mentioned that they like to label each room with a nickname to better tell the difference between each of the layouts and amenities each room has to offer. (for example, the Seattle location has two 2-bedroom suites, but one is named “Seahawks Snooze” while the other is named “Restful Rainier”, each with their own amenities.)

They also take pride in the amenities that each room has to offer. This can consist of features like “air conditioning”, “coffee maker”, “ocean view”, “mini bar”, the list goes on…They requested that they would like the amenities associated with each of the rooms as they do vary.

The rooms vary in price, per location, as well as per room number. They also have a few rooms that they want to advertise as pet friendly.

The number of rooms for each hotel varies. Some hotels have only a few rooms, while others may have dozens.

## Tools Used

- C#
- ASP.NET Core
- MVC
- Entity Framework Core
- Microsost SQL Server
- Visual Studio 2019

## Getting Started

Clone this repository to your local machine.

`$ git clone https://github.com/robertjnielsen/AsyncInn.git`

Once downloaded, you can either use the dotnet CLI utilities or Visual Studio 2019 to build the web application. The solution file is located in the `AsyncInn` subdirectory at the root of the repository.

```
$ cd AsyncInn/AsyncInn
$ dotnet build
```

The dotnet tools will automatically restore any NuGet dependencies. Before running the application, the provided code-first migration will need to be applied to the SQL server of your choice configured in the `/AsyncInn/AsyncInn/appsettings.json` file.

This requires the Microsoft.EntityFrameworkCore.Tools NuGet package and can be run from the NuGet Package Manager Console:

`Update-Database`

Once the database has been created, the application can be run. Options for running and debugging the application using IIS Express or Kestrel are provided within Visual Studio. From the command line, the following will start an instance of the Kestrel server to host the application:

```
cd AsyncInn/AsyncInn
dotnet run
```

## Visuals

#### AsyncInn ERD Image
![AsyncInn ERD](/Assets/Images/AsyncInnERD.png)

## Change Log

**1.4** - 20200406
- Documentation complete to current version.
- Updated DB.
- Created seed migration.
- Created seed data.

**1.3** - 20200406
- Documentation complete to current version.
- Updated DB.
- Created migration for new entities.
- Created DB entities.

**1.2** - 20200401
- Documentation complete to current version.
- DB updated.
- DB initial migration created.

**1.1** - 20200401
- App configured for Dependency Injection.
- DBContext registered in app Startup.cs file.
- Connection string for DB configured.
- DBContext data created.

**1.0** - 20200401
- Routing for MVC application created.
- Project / solution files created.
