# TMCollections - ASP.NET Core Web API

**TMCollections** is a backend RESTful API built using ASP.NET Core 8.0 and Entity Framework Core. This API is designed to handle collection management workflows including Orders, Payments, and Address management for a business application.

---

## 📦 Features

- CRUD operations for:
  - Orders
  - Payments
  - Addresses
- Repository and Service layer architecture
- DTO-based input/output
- Entity Framework Core with Code First Migrations
- Clean, modular folder structure

---

## 🛠 Tech Stack

| Layer              | Technology              |
|-------------------|--------------------------|
| Framework         | ASP.NET Core 8.0         |
| ORM               | Entity Framework Core    |
| Database          | SQL Server (LocalDB or full SQL Server) |
| Dependency Injection | Built-in .NET Core DI |
| API Testing       | Swagger / Postman        |

---

## 🚀 How to Run This Project

### 🔧 Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- Visual Studio 2022 (or VS Code)
- SQL Server (or use LocalDB)
- Git

⚙️ Update DB (if required)
Run the following to apply EF Core migrations:
  dotnet ef database update
Or use Visual Studio's Package Manager Console:
  Update-Database
▶️ Run the App
    dotnet run
The API will start at: https://localhost:5001 or http://localhost:5000
Swagger UI: https://localhost:5001/swagger


### 📥 Clone the Repo

```bash
git clone https://github.com/pgghadge/TMCollections.git
cd TMCollections/TMCollections_Api
