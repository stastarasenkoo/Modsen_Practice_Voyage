# Voyage
Subject area: passenger transportation
App name: Voyage
The application will provide the ability to purchase tickets for various modes of transport for three types of trips: intercity (from point A to point B and from point A to point B with waiting and then returning to point A), sightseeing. There are three types of users in the application: passengers, drivers, administrator. Each user must register in the application with further confirmation of the account. Each driver has his own personal account, which has a list of the next (for the day) trips, and for each trip there is a list of passengers with brief contact details for communication. The driver also has the ability to mark passengers who are already in the vehicle. Each passenger has the opportunity to order a ticket for any route he is interested in, as well as receive bonuses for trips. If the passenger ordered a ticket and did not get into the vehicle without canceling the trip in advance, he will be fined in the form of deducting bonuses. To order excursion routes, the user selects the appropriate section in the application and then the administrator contacts the user. When ordering a ticket for a circular trip, the driver waits for a certain period of time, and then goes to the starting point, without checking whether all passengers are present.

# Database Schema

![asdasda](https://user-images.githubusercontent.com/64153866/174499486-1f03687e-bbdc-4268-9b22-fcdfe4636e79.png)


# **Architecture**

The architecture will be a N-layer.

Advantages of N-Layer architecture:
- Good for simple web applications
- Easier implementation compared to other approaches.
- Increases software manageability through loose coupling.

![Screenshot_1](https://user-images.githubusercontent.com/64153866/174499364-6473fd9e-d532-47a9-94bd-caa122ef8f00.png)

# Application layers

Data Access:
- EF Migrations
- EF DbContext and model design

Business Logic:
This layer describes the business rules of the application.

WebApi:
- Swagger
- Authorization and authentication IdentityServer4
- Information logging

# Technology stack
- Database Microsoft SQL Server;
- Entity Framework;
- ASP.NET Core Web API;
- IdentityServer4;
- SeriLog;
- Mapster
- FluentValidation
- Rest

Benefits of Microsoft SQL Server:
- Interacts very well with other Microsoft products.

Benefits of Entity Framework:
- You do not need to know the details of SQL syntax;
- Entity Framework takes over the responsibility of converting C# code into SQL statements;
- Using LINQ queries to retrieve data from the database;

Rest will be used to interact with the client.

Benefits of rest:
- Internal support in ASP.NET Core
- The most popular solution for customer interaction
- Expandability

IdentityServer4 will be used for security.

Benefits of IdentityServer4:
- Flexibility and the ability to add custom validators;
- Detailed documentation;
- Providing endpoints, token management, scopes, grants and etc.;



