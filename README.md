# Simple E-Commerce Website (ASP.NET Core MVC)

A beginner-friendly e-commerce starter built with ASP.NET Core MVC, Entity Framework Core, SQL Server, and session-based cart storage.

## Features
- Product catalog with search by name or category
- Product details page
- Session-based shopping cart
- EF Core SQL Server integration and sample product seeding
- Responsive layout

## Requirements
- .NET 10 SDK
- SQL Server LocalDB or a SQL Server instance

## Run locally
```bash
dotnet restore
dotnet run
```
Open the HTTPS URL printed in the terminal. Update `ConnectionStrings:DefaultConnection` in `appsettings.json` for your SQL Server instance.

For this learning project, startup uses `EnsureCreated()` and seeds sample products. For production, use EF Core migrations and implement authentication, orders, inventory concurrency, and payments.
