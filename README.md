# Student Management System

> A role-based Student Management System built using ASP.NET MVC 5 following Clean Architecture principles. The project demonstrates enterprise application design with Repository Pattern, Dependency Injection, Custom Filters, AJAX-based interactions, and secure session-based authentication.

---

## Badges

![ASP.NET MVC](https://img.shields.io/badge/ASP.NET-MVC%205-blue)
![C#](https://img.shields.io/badge/C%23-.NET%20Framework-purple)
![SQL Server](https://img.shields.io/badge/Database-SQL%20Server-red)
![ADO.NET](https://img.shields.io/badge/Data-ADO.NET-success)
![Unity](https://img.shields.io/badge/DI-Unity-orange)

---

## Table of Contents

- Project Overview
- Features
- Technology Stack
- Architecture
- Folder Structure
- Authentication & Authorization
- Screenshots
- Installation
- Database Setup
- API Documentation
- Future Improvements
- Skills Demonstrated
- Author

---

# Project Overview

Student Management System is a role-based web application developed using ASP.NET MVC 5.

The application demonstrates enterprise development practices by separating business logic, data access, and presentation layers while implementing secure authentication, dependency injection, reusable contracts, AJAX-powered user experience, and SQL injection prevention.

The application contains separate Areas for Admin, Teacher, and Student modules.

---

# Features

## Authentication

- Session-based Login
- Session-based Logout
- Role-based Authorization
- Dashboard Redirection
- Unauthorized Access Protection

## Student Management

- Create Student
- View Student
- Edit Student
- Delete Student

## Dynamic UI

- AJAX CRUD
- Partial Views
- Search
- Toggle Sort
- jQuery Animations
- Responsive Table Updates

## Validation

- Client-side Validation
- Server-side Validation
- Business Validation
- Duplicate Record Prevention

## Security

- Parameterized Queries
- SQL Injection Prevention
- Custom Authorization Filter
- Session Validation of Users

---

# Technology Stack

## Backend

- ASP.NET MVC 5
- C#
- .NET Framework
- ADO.NET
- Unity Dependency Injection
- SQL Client provider

## Frontend

- HTML5
- CSS3
- Bootstrap
- JavaScript
- jQuery
- AJAX

## Database

- SQL Server

---

# Architecture

```
                 +---------------------+
                 |     Presentation    |
                 |---------------------|
                 | MVC Controllers     |
                 | Razor Views         |
                 | Areas               |
                 | Custom Filters      |
                 +----------+----------+
                            |
                            v
                 +---------------------+
                 |     Application     |
                 |---------------------|
                 | Business Logic      |
                 | Validation          |
                 | Security Checks     |
                 +----------+----------+
                            |
                            v
                 +---------------------+
                 |   Insfrastructure   |
                 |---------------------|
                 | Data Access         |
                 | Helpers             |
                 | SQL Execution       |
                 +----------+----------+
                            |
                            v
                 +---------------------+
                 |        Domain       |
                 |---------------------|
                 | Entity Models       |
                 +----------+----------+


                 +---------------------+
                 |    SQL Server DB    |
                 +---------------------+
```

---

# Folder Structure

```
StudentMangementSystem
│
├── Areas
│   ├── Admin
│   ├── Teacher
│   └── Student
├── Controllers
├── Models
├── Views
├── ViewModels
├── Filters
├── DAL
│   ├── Repository
│   └── Helpers
├── Services
├── Contracts
├── Scripts
├── Content
└── App_Start
```

---

# Authentication & Authorization

The application uses Session-based Authentication.

### Workflow

```
Login

↓

Validate User

↓

Stored Session

↓

Redirect According to the Role

↓

Permit to access Authorized Areas

↓

Logout

↓

Session Destroyed
```

Custom Filters are used to:

- Validate sessions
- Restrict unauthorized access
- Monitor requests

---

# Dependency Injection

Unity Container is used to inject dependencies throughout the application.

Benefits:

- Loose Coupling
- Better Separations
- Scalable Architecture

---

# Search & Sorting

Search Features

- Pattern Matching
- Partial Result render
- AJAX Requests

Sorting

- Toggle Ascending
- Toggle Descending
- Dynamic Updates

---

# CRUD Workflow

```
User

↓

Controller

↓

Service   ←   Contracts

↓

Repository

↓

SQL Server   →   Repository

                 ↓

              Service

                 ↓

              Controller

                 ↓

              AJAX Action

                 ↓
              Partial view

```

---

# Screenshots

Add screenshots inside:

```
/Screenshots
```

Example

```
Login.png

Dashboard.png

StudentList.png

CreateStudent.png

EditStudent.png
```

Then reference them like

```md
## Login

![Login](Screenshots/Login.png)

## Dashboard

![Dashboard](Screenshots/Dashboard.png)

## Student List

![Student List](Screenshots/StudentList.png)
```

---

## Configure Database

1. Create SQL Server Database
2. Execute SQL Script
3. Update connection string in Web.config


# API Documentation

Although this project is MVC-based, it exposes controller endpoints used by AJAX.

| Method| Endpoint                | Description     |
|-------|-------------------------|-----------------|
| GET   | `/Student/Index`        | Student List    |
| GET   | `/Student/Create`       | Create Form     |
| POST  | `/Student/Create`       | Save Student    |
| GET   | `/Student/Edit/{id}`    | Edit Form       |
| PUT   | `/Student/Edit`         | Update Student  |
| DELETE| `/Student/Delete/{id}`  | Delete Student  |
| GET   | `/Student/Details/{id}` | Student Details |
| GET   | `/Student/Search`       | AJAX Search     |
| GET   | `/Student/Sort`         | AJAX Sort       |

# Addtional Endpoints for API test
| Method| Endpoint                   | Description     |
|-------|----------------------------|-----------------|
| GET   | `api/Student/Details?Name=`|Search by Names  |
| GET   | `api/Student/Details/{id}` | Search by Id    |

*(Modify these routes to match your actual controller actions.)*

---

# Skills Demonstrated

- ASP.NET MVC
- Clean Architecture (Onion/Layered)
- Repository Pattern
- Dependency Injection
- SOLID Principles (Interfaces)
- ADO.NET
- SQL Server
- AJAX
- jQuery
- Session Authentication
- Authorization
- Custom Action Filters
- MVC Areas
- Validation
- CRUD Operations

---

# Future Improvements

- ASP.NET Core Migrating
- ORM implementation (EF Core)
- ASP.NET Identity
- JWT Authentication
- Pagination
- Unit Testing
- Logging
- Performance Optimize
- Docker (CI/CD)

---

# Author

**Soumyadip Parui**

ASP.NET Developer | C# | SQL Server | JavaScript | AJAX | jQuery

---
