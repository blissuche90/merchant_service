# GoTap.MerchantService

GoTap.MerchantService is a robust and scalable .NET 8 Web API built using **Clean Architecture**, **CQRS with MediatR**, and **Entity Framework Core**, designed to manage merchant data. The service includes input validation, external API communication (for country validation), and is built with testability, modularity, and maintainability in mind.

---

## 📦 Technologies

- **.NET 8**
- **ASP.NET Core Web API**
- **Entity Framework Core**
- **MediatR (CQRS pattern)**
- **FluentValidation**
- **REST Countries API integration**
- **xUnit, Moq, FluentAssertions (Testing)**
- **Swagger (API Documentation)**

---

## 🧩 Architecture Overview

This solution follows Clean Architecture with the following layered structure:

GoTap.MerchantService/
│
├── Domain/ → Entities and domain models
├── Application/ → CQRS (Commands, Queries), interfaces, validation
├── Infrastructure/ → External service implementations (e.g., Country validation)
├── Persistence/ → EF Core DbContext, Repository pattern
├── WebApi/ → ASP.NET Core Web API, controllers, DI config
└── Tests/ → Unit and integration tests

## 🚀 Getting Started

### 1. Clone the Repository

```bash
git clone 
cd GoTap.MerchantService

dotnet run --project GoTap.MerchantService.WebApi

Visit Swagger UI at:
https://localhost:5001/swagger

| Verb   | Route                 | Description                 |
| ------ | --------------------- | --------------------------- |
| POST   | `/api/merchants`      | Create a new merchant       |
| GET    | `/api/merchants/{id}` | Retrieve merchant by ID     |
| GET    | `/api/merchants`      | List all merchants          |
| PUT    | `/api/merchants/{id}` | Update an existing merchant |
| DELETE | `/api/merchants/{id}` | Delete a merchant           |


 Deployment Notes
✅ Build the solution using dotnet publish

✅ Set up appsettings for Production environment

✅ Configure HTTPS and reverse proxy (e.g., Nginx/IIS)

✅ Use CI/CD pipelines to automate test & deploy
