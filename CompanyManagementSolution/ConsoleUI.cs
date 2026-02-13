using System;
using Company.Business;
using System.Collections.Generic;


namespace CompanyManagementSolution
{
    public class ConsoleUI
    {
        private DepartmentService _departmentService;
        private EmployeeService _employeeService;

        public ConsoleUI()
        {
            _departmentService = new DepartmentService();
            _employeeService = new EmployeeService();
        }


        private int ReadNumber()
        {
            int number;

            while (!int.TryParse(Console.ReadLine(), out number))
            {

                Console.Write("Invalid number, try again: ");
            }

            return number;

        }

        private decimal ReadDecimal()
        {
            decimal number;
            while (!decimal.TryParse(Console.ReadLine(),out number))
            {
                Console.Write("Invalid number, try again: ");
            }

            return number;
        }




        private void AddDepartment()
        {
            Console.Write("Enter Department Name: ");
            string name = Console.ReadLine();

            bool result = _departmentService.AddDepartment(name);

            if (result)
                Console.WriteLine("Department Added Successfully.");
            else
                Console.WriteLine("Failed to Add Department.");
        }


        private void ShowDepartments()
        {

            Console.WriteLine("\nAll Departments:");


            var departments = _departmentService.GetAllDepartments();

            foreach (var dept in departments)
            {
                Console.WriteLine($"{dept.Id} - {dept.Name}");
            }
        }



        private void UpdateDepartment()
        {

            Console.Write("Enter Department Id: ");
            int id = ReadNumber();

            Console.Write("Enter New Department Name: ");
            string newName = Console.ReadLine();


            bool result = _departmentService.UpdateDepartment(id, newName);


            if (result)
                Console.WriteLine("Department Updated Successfully.");
            else
                Console.WriteLine("Failed to Update Department.");
        }


        private void DeleteDepartment()
        {
            Console.Write("Enter Department Id to Delete: ");
            int id = ReadNumber();

            try
            {
                bool result = _departmentService.DeleteDepartment(id);

                if (result)
                    Console.WriteLine("Department Deleted Successfully.");
                else
                    Console.WriteLine("Department not found.");
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        


        public void Run()
        {
            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("\n=== Main Menu ===");
                Console.WriteLine("1 - Manage Departments");
                Console.WriteLine("2 - Manage Employees");
                Console.WriteLine("3 - Exit");
                Console.Write("Choose: ");

                int choice = ReadNumber();

                switch (choice)
                {
                    case 1:
                        DepartmentMenu();
                        break;

                    case 2:
                        EmployeeMenu();
                        break;

                    case 3:
                        isRunning = false;
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }


        private void DepartmentMenu()
        {
            bool isRunning = true;

            while (isRunning)
            {

                try
                {
                    Console.WriteLine("\n=== Department Menu ===");
                    Console.WriteLine("1 - Add Department");
                    Console.WriteLine("2 - Show Departments");
                    Console.WriteLine("3 - Update Department");
                    Console.WriteLine("4 - Delete Department");
                    Console.WriteLine("5 - Back");
                    Console.Write("Choose: ");

                    int choice = ReadNumber();

                    switch (choice)
                    {
                        case 1:
                            AddDepartment();
                            break;

                        case 2:
                            ShowDepartments();
                            break;

                        case 3:
                            UpdateDepartment();
                            break;

                        case 4:
                            DeleteDepartment();
                            break;
                        case 5:
                            isRunning = false;
                            break;

                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }

                }
                catch(Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }
        }


        private void EmployeeMenu()
        {
            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("1 - Add Employee");
                Console.WriteLine("2 - Show Employees");
                Console.WriteLine("3 - Update Employee");
                Console.WriteLine("4 - Delete Employee");
                Console.WriteLine("5 - Back");

                int choice = ReadNumber();

                switch (choice)
                {
                    case 1:
                        AddEmployee();
                        break;

                    case 2:
                        ShowEmployees();
                        break;


                    case 3:
                        UpdateEmployee();
                        break;

                    case 4:
                        DeleteEmployee();
                            break;

                    case 5:
                        isRunning = false;
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }



        private void AddEmployee()
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            Console.Write("Salary: ");
            decimal salary = ReadDecimal();

            Console.Write("Department Id: ");
            int deptId = ReadNumber();


            bool result = _employeeService.AddEmployee(
                name,
                email,
                salary,
                DateTime.Now,
                true,
                deptId
            );

            

            if(result)
            {
                Console.WriteLine("Employee Added Successfully.");
            }
            else
            {
                Console.WriteLine("Failed to Add Employee.");
            }
        }


        private void UpdateEmployee()
        {
            Console.Write("Enter Employee Id: ");
            int id = ReadNumber();

            var employee = _employeeService.GetEmployee(id);    

            if(employee == null)
            {
                Console.WriteLine("Employee not found.");
                return;
            }

            Console.Write("New Name: ");
            string name = Console.ReadLine();


            Console.Write("New Email: ");
            string email = Console.ReadLine();


            Console.Write("New Salary: ");
            decimal salary = ReadDecimal();


            Console.Write("New Department Id: ");
            int deptId = ReadNumber();


            bool result = _employeeService.UpdateEmployee(
                id,
                name,
                email,
                salary,
                deptId
            );

            if (result)
                Console.WriteLine("Employee Updated Successfully.");
            else
                Console.WriteLine("Failed to Update Employee.");

        }



        private void DeleteEmployee()
        {

            Console.Write("Enter Employee Id to Delete: ");
            int id = ReadNumber();
            try
            {
                bool result = _employeeService.DeleteEmployee(id);

                if (result)
                    Console.WriteLine("Employee Deleted Successfully.");
                else
                    Console.WriteLine("Employee not found.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }



        private void ShowEmployees()
        {
            var employees = _employeeService.GetAllEmployees();


            if(employees.Count == 0)
            {
                Console.WriteLine("No employees found.");
                return;
            }
                
            foreach (var emp in employees)
            {
               
                Console.WriteLine($"{emp.Id} - {emp.Name} - {emp.Email} - {emp.Salary} - {emp.DepartmentName}");
            }
        }

    }

}




