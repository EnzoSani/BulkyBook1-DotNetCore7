# BulkyBook (ASP.NET Core 6)

## Overview
BulkyBook is a sample e-commerce platform built on ASP.NET Core 6 MVC that showcases how to deliver a full shopping experience for physical products. The solution demonstrates a layered architecture with dedicated projects for the web application, domain models, data access, and shared utilities. It incorporates ASP.NET Core Identity for user management, Stripe for payment processing, and social authentication through Facebook to provide a production-style end-to-end workflow.

The application is organized into customer-facing and administrator areas. Customers can browse books, manage their shopping cart, check out securely, and review their order history. Administrators receive a role-based management dashboard for catalog maintenance, company accounts, and order fulfillment.

## Key Features
- **Modular architecture** using separate class library projects for models, data access, and utilities that are consumed by the MVC front end.
- **Entity Framework Core with the repository & unit-of-work pattern** for data persistence backed by SQL Server.
- **Identity membership system** with seeded roles (Admin, Employee, Individual, Company) and default administrator account to manage catalog content.
- **Customer and Admin areas** implemented with ASP.NET Core Areas to partition user experiences.
- **Shopping cart and checkout flow** with order tracking, shipping details, and integration with Stripe for secure payments.
- **Social login with Facebook** plus traditional email/password registration, password reset, and email notifications.
- **Stripe and MailKit integration** for payment processing and transactional email delivery (configurable in `appsettings.json`).

## Solution Structure
```
BulkyBook1-DotNetCore7/
├── BulkyBookWeb1/           # ASP.NET Core MVC front-end with Areas for Customer, Admin, and Identity
├── BulkyBook1.Models/       # POCO entities, view models, and Identity user extensions
├── BulkyBook1.DataAccess/   # Entity Framework Core DbContext, repositories, migrations, and seed logic
└── BulkyBook1.Utility/      # Shared helpers such as Stripe configuration and email sender
```

## Prerequisites
- [.NET 6 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
- SQL Server instance (LocalDB, SQL Express, or Azure SQL)
- Access credentials for:
  - Stripe (Publishable & Secret keys)
  - Facebook OAuth App (AppId & AppSecret)
  - SMTP provider for transactional email (used by `EmailSender`)

## Getting Started
1. **Clone the repository**
   ```bash
   git clone <repository-url>
   cd BulkyBook1-DotNetCore7
   ```
2. **Configure the application**
   - Update the `ConnectionStrings:DefaultConnection` in `BulkyBookWeb1/appsettings.json` (and `appsettings.Development.json` if used) to point to your SQL Server instance.
   - Provide your Stripe keys under the `Stripe` section (`Publishablekey`, `Secretkey`).
   - Replace the Facebook OAuth `AppId` and `AppSecret` configured in `Program.cs` with your own values or disable the provider if not required.
   - Update the SMTP credentials in `BulkyBook1.Utility/EmailSender.cs` to match your email provider settings.
3. **Restore NuGet packages**
   ```bash
   dotnet restore
   ```
4. **Apply database migrations**
   ```bash
   dotnet ef database update \
     --project BulkyBook1.DataAccess \
     --startup-project BulkyBookWeb1
   ```
   The `DbInitializer` will also run automatically on application start to apply pending migrations and seed the default roles and administrator account.
5. **Run the application**
   ```bash
   dotnet run --project BulkyBookWeb1
   ```
   Navigate to `https://localhost:5001` (or the port shown in the console) to access the storefront.

## Seeded Accounts & Roles
On first launch, the `DbInitializer` seeds the following roles:
- `Admin`
- `Employee`
- `Individual`
- `Company`

A default administrator user is also created:
- **Email:** `admin@enzosani.com`
- **Password:** `Admin123*`

Sign in with these credentials to access the Admin area and begin managing catalog data.

## Common Workflows
- **Managing Catalog Data:** Admin users can create and maintain Categories, Cover Types, Products, and Company accounts under the Admin area.
- **Handling Orders:** Administrators can review incoming orders, update order statuses, and manage shipping details from the Orders dashboard.
- **Shopping Experience:** Customers can browse the catalog, view product details, add items to the cart, and complete checkout using Stripe. Order history and status tracking are available through the customer area.

## Technology Stack
- ASP.NET Core 6 MVC
- Entity Framework Core & SQL Server
- ASP.NET Core Identity & Identity UI
- Stripe.NET SDK for payments
- MailKit for SMTP email delivery
- Facebook Authentication middleware

## Development Tips
- Enable Razor runtime compilation (already configured) for faster UI iteration during development.
- Use the repository interfaces in `BulkyBook1.DataAccess.IRepository` to keep controllers and services unit-testable.
- Additional EF Core migrations can be created via:
  ```bash
  dotnet ef migrations add <MigrationName> \
    --project BulkyBook1.DataAccess \
    --startup-project BulkyBookWeb1
  ```

