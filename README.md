# Movies
Clone of IMDB created using ASP.NET Core.

> Go to `Screenshot` folder to see the snapshot of UI

## Technology Stack
Incognito is created using - 

 - ASP.NET Core
 - Entity Framework Core
 - MS-SQL Server DB
 - JavaScript, jQuery
 - Bootbox
 - Bootstrap 3.

## Prerequisites
 - Visual Studio 2017
 - VS Code (Optional)
 - MS-SQL Server DB
 - ASP.NET Core 2.0 which has a hard requirement on .NET Core Runtime 2.0.0 and .NET Core SDK 2.0.0. Please install these items from [here](https://github.com/dotnet/core/blob/master/release-notes/download-archives/2.0.0-download.md)

**Visual Studio 2017**

Make sure you have .NET Core 2.0 installed. VS2017 will automatically install all the necessary bower & .NET dependencies when you open the project.

**VS Code**
> Note: I used full version of Visual Studio, same can be done using VS Code with few extra steps.
> Make sure you have the C# extension & .NET Core Debugger installed.
> Microsoft SQL Server DB is also needed.

## How to run on local using Visual Studio
-   Open the `Movies.sln` solution in Visual Studio
-   Build the solution
-   Modify the default connection string accordingly if needed.
-   Apply Migrations
-   Run Project (F5 or Ctrl+F5)


## How to run on local using VS Code and CMD
- Go to Project Directory
- Run `dotnet restore` 
- Apply Migrations - `dotnet ef database update`
- Run Project `dotnet run`