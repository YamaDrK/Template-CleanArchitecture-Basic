# Template_CleanArchitecture_Basic

A basic template implementing Clean Architecture principles using .NET and Entity Framework Core. This project is structured to promote scalability, maintainability, and testability by clearly separating concerns between layers.

## 🧱 Architecture Overview

This solution follows the Clean Architecture pattern and is divided into the following layers:

Solution Root\
│\
├── Application     → Application logic, interfaces, DTOs, and use cases\
├── Domain          → Domain entities and core business logic\
├── Infrastructure  → EF Core implementation, repositories, external services\
├── WebAPI          → Entry point and REST API controllers

## 🚀 Getting Started

### Prerequisites

- [.NET SDK 8.0+](https://dotnet.microsoft.com/download)
- [EF Core CLI tools](https://learn.microsoft.com/en-us/ef/core/cli/powershell)

## 💾 Entity Framework Core

### Add a New Migration

To create a new migration using EF Core:

```bash
Add-Migration InitDB -StartupProject WebAPI -Project Infrastructure
```

### Update the Database

To apply the migration and update the database:

```bash
Update-Database -Project Infrastructure
```

## 📁 Project Goals

* Simplify setup of new projects using Clean Architecture
* Encourage best practices in domain-driven design
* Promote a clean separation of concerns

## 📄 License

This project is licensed under the [MIT License](LICENSE).
