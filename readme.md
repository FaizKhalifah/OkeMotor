# How to set up the project

## Install the following package 
- postgresq1
- Entity Core
- Entity framework tools
- Identity UI

Command with nugget package manager : 
- Install-Package Npgsql.EntityFrameworkCore.PostgreSQL
- Install-Package Microsoft.AspNetCore.Identity.EntityFrameworkCore
- Install-Package Microsoft.EntityFrameworkCore.Tools
- Install-Package Microsoft.AspNetCore.Identity.UI

## Set up postgre Database
- Create your database
- Connect your database with the visual studio through appsettings.json

# Model and Migration
## User model with Identity
- Create Application User Model inheriting the Identity User class
- Set up your database connection in program.cs file
- Migrate the database using command in package console : Add-Migration InitialCreate
- And then enter Update-Database
- To undo migration use Remove-Migration
