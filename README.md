# AwesomeColours
This project was generated with [Angular CLI](https://github.com/angular/angular-cli) version 6.0.0.


# Getting Started

## Start API
1.  Open `AwesomeColours.Api.sln` in Visual Studio 2019.
2.  Update `ColoursDbConnection` in `appsettings.json` and point to your instance of SQL DB or use `localhost`.
3.  Start debugging of API project in Visual Studio.

## Start UI web client
1.  Open `AwesomeColours.Web` folder in VS Code.  
2.  Run `npm install` and next `npm start` in terminal under `AwesomeColours.Web`.
3.  Navigate to `http://localhost:4200/`


# Assumptions
1.  API doesn't provide any form of authentication or autorisation - this can be added in later time
2.  API can be easily extended with Identy Server integration and suport berear token authentication
3.  API uses EF Core Code First approach to create and provide all CRUD operations, this will be set up on first API run
4.  Test data is seeded on first API run into a new DB as well - this might take some time