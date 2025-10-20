# 🎮 Game Store API

A simple **.NET 8 Web API** project built to learn and demonstrate the **core backend concepts** in a clean and structured way.  
This API simulates a small **Game Store system** where users can register, log in, and manage games by category.

---

## 🧠 Project Purpose

This project is **not a large-scale API**, but rather a **learning-oriented project** built to understand and practice:

- ✅ **Entity Framework Core** (Database management)
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

---





