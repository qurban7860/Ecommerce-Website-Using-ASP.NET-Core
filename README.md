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
- SQL Server LocalDB (included with Visual Studio) or a SQL Server instance

## Run locally

```bash
dotnet restore
dotnet run
```

Open the HTTPS URL printed in the terminal. Update `ConnectionStrings:DefaultConnection` in `appsettings.json` if you use a SQL Server instance other than LocalDB.

## Database note

This learning project uses `EnsureCreated()` and seeds sample products on startup. For production, use EF Core migrations and add authentication, order processing, inventory concurrency, and payment workflows.

## Scope

Checkout, payment processing, user accounts, admin product management, and order processing are intentionally left for future iterations.
