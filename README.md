# .NET Quotex
## Targeted framework .NET Core 3.1. Front-end libraries like jQuery, Bootstrap are used in the app. AJAX is also used to send asynchronous requests.

### Overview

Simple ASP.NET Core MVC application for creating and drawing quotes from a database. 
Users must be registered and authenticated in order to have access to the main functionality of the application.
There are two roles in the application as an user with the role of Admin is created upon the creation of the database with username and password specified in the DbContext class.

There are two tables in the database with one-to-many relationship. One user can create as many quotes as they want.
There is some basic validation when registering and creating a quote.
A user with Admin role must approve all quotes sent by the users in order for them to be drawable by the users of the application.

```update-database``` <br/> command must be executed in the Package Manager Console in order for the database to be created as we are using Entity Framework
core for the creation of the database.
