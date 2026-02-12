# 🏢 EmployeeManagementSystem-3Tier-Console

## 📌 Overview
A Console-based Employee Management System built using C#, ADO.NET, and SQL Server, following the 3-Tier Architecture pattern.
The system manages Departments and Employees with full CRUD operations, validation, and clean separation of concerns.

------------------------------------------------------------

## 🏗 Architecture

Presentation Layer  →  Business Layer  →  Data Access Layer  →  SQL Server

- Presentation Layer  : ConsoleUI
- Business Layer      : Validation & Business Rules
- Data Access Layer   : SQL Execution (ADO.NET)
- Database            : SQL Server

------------------------------------------------------------

## ⚙ Features

[Department Management]
- Add Department
- Update Department
- Delete Department
- View All Departments

[Employee Management]
- Add Employee
- Update Employee
- Delete Employee
- View All Employees
- Display Department Name using SQL JOIN

[Improvements]
- Business Layer Validation
- Exception Handling in ConsoleUI
- Clean 3-Tier Separation
- SQL JOIN for professional data display

------------------------------------------------------------

## 🛠 Technologies Used

- C#
- .NET
- SQL Server
- ADO.NET
- 3-Tier Architecture

------------------------------------------------------------

## 🗄 Database Structure

Departments Table
- Id (Primary Key)
- Name

Employees Table
- Id (Primary Key)
- Name
- Email
- Salary
- HireDate
- IsActive
- DepartmentId (Foreign Key)

------------------------------------------------------------

## ▶ How To Run

1. Create a database named:
   EmployeeManagementDB

2. Create required tables (Departments & Employees).

3. Update the connection string in:
   DataAccessSettings.connectionString

4. Run the project.

------------------------------------------------------------

## 💡 Key Learning Outcomes

- Applying 3-Tier Architecture in a real project
- Separation of Concerns
- SQL Integration using ADO.NET
- Business Layer Validation
- Clean Console Application Design

------------------------------------------------------------

## 📂 Project Structure

CompanyManagementSolution
│
├── Company.Business
├── Company.DataAccess
└── CompanyManagementSolution (ConsoleUI)

------------------------------------------------------------

## 🚀 Author
Shady Mahmoud
