# Arcadia back-end
A .Net Core web app that implements GraphQL and EntityFramework.

## Setup
This project uses a local DB. You must create a local DB and configure the connection string. Also you must configure app's CORS to allow access for the front-end project.  
Follow these steps:

1) DB Connection - replace connection string in `appsettings.Development.json` file:
```json
`"ConnectionStrings": {
    "ArcadiaDatabase": "[YourConnectionString]"
  }`
```

2) CORS Configuration - replace the origin by using yours in `Startup.cs` file:
```c#
var corsBuilder = new CorsPolicyBuilder();
corsBuilder.AllowAnyHeader();
corsBuilder.AllowAnyMethod();
corsBuilder.WithOrigins("YourOrigin"); // replace this with your own origin
corsBuilder.AllowCredentials();
```

## Nuget Packages
* [graphql-dotnet](https://github.com/graphql-dotnet/graphql-dotnet)
* [graphiql-dotnet](https://github.com/JosephWoodward/graphiql-dotnet)
* EntityFramework
