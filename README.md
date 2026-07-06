# 🎓 Student Management System

A role-based **Student Management System** built using **ASP.NET MVC** following **Clean Architecture** principles. The application provides secure authentication, CRUD operations, dynamic UI interactions using AJAX, and separation of responsibilities through Repository and Service layers.

---

# 📌 Overview

This project is designed to demonstrate enterprise-level ASP.NET MVC development practices. It includes:

- Clean layered architecture
- Dependency Injection
- Session-based Authentication & Authorization
- Custom Action Filters
- Repository Pattern
- Service Layer Validation
- SQL Injection Prevention
- AJAX-powered UI
- Search, Sort and CRUD Operations

---

# 🛠️ Tech Stack

## Backend

- ASP.NET MVC 5
- C#
- .NET Framework
- ADO.NET
- SQL Server
- Unity Container (Dependency Injection)

## Frontend

- HTML5
- CSS3
- Bootstrap
- JavaScript
- jQuery
- AJAX

## Database

- Microsoft SQL Server

---

# 🏛️ Architecture

The project follows a layered Clean Architecture.

```

Presentation Layer (MVC)
│
├── Controllers
├── Views
├── ViewModels
├── Areas
├── Custom Filters
│
▼

Services Layer
│
├── Business Logic
├── Validation
├── SQL Injection Protection
│
▼

Contracts Layer
│
├── Interfaces
├── Shared Models
└── Reusable Components
│
▼

DAL (Data Access Layer)
│
├── Repository
├── Helpers
└── Database Access (ADO.NET)
│
▼

SQL Server Database
