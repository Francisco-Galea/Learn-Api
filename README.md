# Learn-Api

Hello! This API is a test that I am doing while reading documentation, so it is possible that when you test it, some method fails.
Another point to keep in mind, I excluded from this repository a file called "appsettings.json". This file represents the connection between the application and the database, so this file is necessary for you to test its functionality, for that, I will show you how to create it.

Right click in the solution explorer to add a new file, select new class, and in the filter search for ".json". a file called "Application configuration file" will appear, add it to the project and configure the following lines:

{
"ConnectionStrings": 
{
"DefaultConnection": 
"Server=YourServerName; 
Database=YourDatabaseName; 
TrustServerCertificate=true;
Trusted_Connection=True;"
}, 
"Logging": 
{ 
"LogLevel": 
{ "Default": "Information", "Microsoft.AspNetCore": "Warning" } 
}, 
"AllowedHosts": "*" } 


And that's it, it should work.