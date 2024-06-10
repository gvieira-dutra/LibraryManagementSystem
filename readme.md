# Library Management System

## Introduction

This project a Library Management System developed in .NET.

## Functionalities Description

Users of this system (Library Staff) can:

* Register Clients
* Add a book to the database
* Retrieve all books
* Query all books
* Query books by name or part of the name
* Query books by ID
* Create a loan (only if the book is available)
* Edit a loan
* Finish a loan

## Technologies Description

This project was developed using the following technologies:

- Clean Architecture Principles
- CQRS (Command Query Responsibility Segregation)
- Fluent Configurations
- ORM (Object-Relational Mapping)
- SQL Database 
- Dapper

## Running on your machine

This project was developed using:
- [.NET SDK](https://dotnet.microsoft.com/download) (version 8.0)
- [Visual Studio](https://visualstudio.microsoft.com/) (version 2019) with the following workloads:
  - ASP.NET and web development
- Microsoft SQL Server Management Studio (SSMS) - 20.1

## Getting Started

### 1. Clone the Repository

```sh
git clone https://github.com/gvieira-dutra/LibraryManagementSystem
```

### 2. Navigate to the Project Directory

```sh 
cd your-repository-name
```

### 3. Open the Project in Visual Studio

Click on File > Open > Project/Solution.
Navigate to the cloned directory and select the .sln file (Solution file).

### 4. Restore Dependencies
Open the Package Manager Console in Visual Studio (Tools > NuGet Package Manager > Package Manager Console) and run:

```sh 
dotnet restore
``` 

Alternatively, you can run the same command in a terminal. 

### 5. Build the Solution
In Visual Studio, go to Build > Build Solution or use the shortcut Ctrl+Shift+B.

### 6. Apply Migrations

```sh
dotnet ef database update
```

Ensure the dotnet-ef tool is installed globally if you encounter issues:

```sh 
dotnet tool install --global dotnet-ef
```

### 7. Run the Application
To run the application, press F5 or click the Start button in Visual Studio.
