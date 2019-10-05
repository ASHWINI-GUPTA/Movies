# Movies
Clone of IMDB created using ASP.NET Core.

> Go to `Screenshot` folder to see the snapshot of UI

## Technology Stack
Incognito is created using - 

 - ASP.NET Core
 - Entity Framework Core
 - MS-SQL Server

## Prerequisites
 - Visual Studio 2019 (Optional)
 - VS Code 
 - MS-SQL Server
 - .NET Core 3.0

**Visual Studio 2019**

Make sure you have .NET Core 3.0 installed. VS2019 will automatically install all the necessary bower & .NET dependencies when you open the project.

**VS Code**
> Note: I used Visual Studio, same can be done using VS Code with few extra steps.
> Make sure you have the C# extension installed.

## How to run on local using Visual Studio
-   Open the `Movies.sln` solution in Visual Studio
-   Build the solution
-   Modify the default connection string accordingly, if needed.
-   Apply Migrations
-   Run Project (F5 or Ctrl+F5)


## How to run on local using VS Code and CMD
- Go to Project Directory
- Run `dotnet restore` 
- Apply Migrations - `dotnet ef database update` (EF tool are no more included with .NET Core SDK's `dotnet tool install --global dotnet-ef` to install EF tools locally.)
- Run Project `dotnet run`
