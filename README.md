# 🎮 Game Store API

A simple **.NET Web API** project built to learn and demonstrate the **core backend concepts** in a clean and structured way.  
This API simulates a small **Game Store system** where users can register, log in, and manage games by category.

---

## 🧠 Project Purpose

This project is **not a large-scale API**, but rather a **learning-oriented project** built to understand and practice:

- ✅ **Entity Framework Core** (for database managment "ORM")
- ✅ **Dependency Injection (DI)** (to manage services and dependencies efficiently)
- ✅ **Repository Pattern** (Data access layer separation)
- ✅ **Minimal APIs** (Lightweight endpoint setup)
- ✅ **Authentication & Authorization** using **JWT**
- ✅ **DTOs & Mappings** (Clean data transfer)
- ✅ **Layered / Structured Architecture** (Organized project structure)

The goal is to learn **the essential backend concepts in .NET**, understand how layers communicate, and how to keep your code **clean, testable, and scalable**.

---

## 🧩 Project Architecture

The project is organized into clear layers:

<img width="385" height="605" alt="image" src="https://github.com/user-attachments/assets/74d929ba-76d2-4ded-bcbd-6539adc12470" />


### 🔹 Layer Responsibilities

| Layer | Description |
|-------|--------------|
| **Entities** | Represents the database tables |
| **Data** | Handles Entity Framework configuration and migrations |
| **DTOs** | Used for sending and receiving clean data |
| **Mapping** | Converts between DTOs and Entities |
| **Repositories** | Manages all database operations (CRUD) |
| **Endpoints** | Defines the API routes and core business logic |
| **Program.cs** | Configures services, middleware, and app startup |

---

## 🧱 Technologies Used

- **.NET (ASP.NET Core Minimal API)**
- **Entity Framework Core with SQLite**
- **JWT Authentication**
- **Swagger / OpenAPI** (API documentation)
- **C#**
- **LINQ**
- **Dependency Injection**

---

## 🔐 Authentication

The API uses **JWT (JSON Web Token)** authentication.

- `POST /auth/register` → Create a new user
- `POST /auth/login` → Login and get a JWT token  
  Then you can use the token to access protected endpoints (like creating or deleting a game).

---

## 🎮 Game Management Endpoints

| Method | Endpoint | Description | Auth |
|--------|-----------|--------------|------|
| `GET` | `/games` | Get all games | Public |
| `GET` | `/games/{id}` | Get a single game by ID | Public |
| `POST` | `/games` | Add a new game | Admin only |
| `PUT` | `/games/{id}` | Update a game | Admin only |
| `DELETE` | `/games/{id}` | Delete a game | Admin only |

---

## 🏷️ Kind (Game Category) Endpoints

| Method | Endpoint | Description |
|--------|-----------|--------------|
| `GET` | `/kinds` | Get all game categories |
| `POST` | `/kinds` | Add new game category |
---

## 🧰 Database Setup

The database is automatically created and migrated when the app starts:

```csharp
await app.MigrateDbAsync();
```
---
## ⚙️ How to Run

1. **Clone the Repository**
   ```bash
   git clone https://github.com/jumanasaif/GameAPI_ASP.git
   
2. **Open the Project** 
    Open the solution file (.sln) using Visual Studio or Visual Studio Code.
    
3.  **Set Up the Database**
    Make sure your connection string in appsettings.json is correct.
    Run the following command to apply migrations:
     ```bash
     dotnet ef database update

4.  **Run the Application**   
     ```bash
      dotnet run
      ```
 ---
 ## 👩‍💻 Author
 *Jumana Saif*
 
**📘  [GitHub](https://github.com/jumanasaif)**

**📩 [Email](jumanasaif2003@gmail.com)**

**💬 Built for learning and improving backend development skills with .NET.**




