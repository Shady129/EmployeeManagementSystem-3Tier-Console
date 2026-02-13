# 🏢 Employee Management System

## 📖 Overview
Console-based Employee Management System built using C# with a clean 3-Tier Architecture.

The system allows managing Departments and Employees with proper validation and database constraints.

---

## 🏗 Architecture

The project follows a 3-Layer Structure:

- 📦 DataAccess Layer
- 🧠 Business Layer
- 🖥 Presentation Layer (Console UI)

This ensures separation of concerns and maintainable code structure.

---

## 🛠 Technologies Used

- C#
- .NET
- SQL Server
- ADO.NET
- 3-Tier Architecture

---

## ✨ Features

### 📁 Department Management
- Add Department
- Update Department
- Delete Department
- View All Departments
- Prevent Duplicate Names
- Prevent Deleting Department with Employees (Foreign Key Protection)

### 👨‍💼 Employee Management
- Add Employee
- Update Employee
- Delete Employee
- View All Employees
- Salary Validation
- Email Validation
- Department Existence Validation

---

## 🔒 Validation & Safety

- Prevent empty or whitespace names
- Prevent duplicate departments
- Prevent negative or zero salaries
- Safe numeric input handling
- Foreign key protection on delete

---

## 🧪 Testing

Manual test cases were performed including:
- Edge cases
- Invalid inputs
- Foreign key violations
- Duplicate handling
- Case sensitivity checks

The system is stable and validated.

---

## 🚀 How to Run

1. Clone the repository
2. Update connection string in `DataAccessSettings`
3. Run the solution
4. Use the console menu to manage departments and employees

---

## 👨‍💻 Author

Built as part of backend learning journey focusing on clean architecture and solid fundamentals.
