# Video Game Catalogue

A two-page web application for browsing and editing a video game catalogue.  
Built with **ASP.NET Core** (backend) and **Angular** (frontend).

---

## Tech Stack

**Backend**
- ASP.NET Core Web API
- Entity Framework Core (Code First)
- SQL Server Express

**Frontend**
- Angular 22
- Bootstrap 5 / ng-bootstrap
- Angular Router

---

## Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- [SQL Server Express](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [Node.js 20+](https://nodejs.org/)
- [Angular CLI](https://angular.io/cli): `npm install -g @angular/cli`

---

## Getting Started

### 1. Clone the repository

```bash
git clone https://github.com/your-username/newton-assignment.git
cd newton-assignment
```

---

### 2. Backend setup

#### 2.1 Configure the connection string

Open `User Secrets` and update the connection string:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=NewtonDB;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

#### 2.2 Run migrations

Open the **Package Manager Console** in Visual Studio and run:

```powershell
Update-Database
```

Or via the .NET CLI:

```bash
cd NewtonServices
dotnet ef database update
```

This will create the database, all tables, and seed initial data automatically.

#### 2.3 Create the view

After running migrations, execute the script (VwAllVideoGames.sql) against your database in SQL Server Management Studio (or any SQL client), located in /DataBase:


#### 2.4 Run the backend

```bash
cd NewtonServices
dotnet run
```

The API will be available at `https://localhost:7129`.  
Swagger UI: `https://localhost:7129/swagger`

---

### 3. Frontend setup

```bash
cd VideoGames
npm install
ng serve
```

The app will be available at `http://localhost:5331`.


## Seed Data

The database is seeded automatically on migration with:

- 4 genres: Sport, Action, Shooter, Adventure
- 3 platforms: PlayStation, Xbox, PC
- 5 sample video games

Seed data is only applied in `DEBUG` mode.

---

## Notes

- SSL and authentication are not required per the assignment spec.
- CORS is configured to allow requests from `http://localhost:5331`.
- Error handling is centralized via a global `IExceptionHandler` — stack traces are never exposed to the client.
- Input validation is enforced on all DTOs using Data Annotations.
