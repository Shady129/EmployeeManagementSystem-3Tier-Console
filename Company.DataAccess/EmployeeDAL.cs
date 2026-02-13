using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace Company.DataAccess
{
    public class EmployeeDAL
    {

        public bool AddEmployee(string name, string email, decimal salary, DateTime hireDate, bool isActive, int departmentId)
        {


            using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
            {

                string query = @"INSERT INTO Employees 
                         (Name, Email, Salary, HireDate, IsActive, DepartmentId)
                         VALUES
                         (@Name, @Email, @Salary, @HireDate, @IsActive, @DepartmentId)";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Salary", salary);
                command.Parameters.AddWithValue("@HireDate", hireDate);
                command.Parameters.AddWithValue("@IsActive", isActive);
                command.Parameters.AddWithValue("@DepartmentId", departmentId);


                connection.Open();

                int rowAffected = command.ExecuteNonQuery();


                return rowAffected > 0;

            }

        }


        public List<Employee> GetEmployees()
        {

            List<Employee> employees = new List<Employee>();



            using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
            {

                string query = @"SELECT E.Id, E.Name, E.Email, E.Salary,
                               D.Name AS DepartmentName
                               FROM Employees E
                               INNER JOIN Departments D
                               ON E.DepartmentId = D.Id";




                SqlCommand command = new SqlCommand(query, connection);


                connection.Open();


                SqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    Employee employee = new Employee();

                    employee.Id = (int)reader["Id"];
                    employee.Name = (string)reader["Name"];
                    employee.Email = reader["Email"].ToString();
                    employee.Salary = (decimal)reader["Salary"];
                    employee.DepartmentName = reader["DepartmentName"].ToString();



                    employees.Add(employee);
                }

            }

            return employees;
        }



        public Employee GetEmployee(int id)
        {

            Employee employee = null;

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
            {

                string query = "SELECT * FROM Employees WHERE Id = @Id";


                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();


                command.Parameters.AddWithValue("@Id", id);


                SqlDataReader reader = command.ExecuteReader();

                if(reader.Read())
                {

                    employee = new Employee();

                    employee.Id = (int)reader["Id"];
                    employee.Name = reader["Name"].ToString();
                    employee.Email = reader["Email"].ToString();
                    employee.Salary = (decimal)reader["Salary"];
                    employee.HireDate = (DateTime)reader["HireDate"];
                    employee.IsActive = (bool)reader["IsActive"];
                    employee.DepartmentId = (int)reader["DepartmentId"];
                }
            }


            return employee;
        }




        public bool UpdateEmployee(int id, string name, string email, decimal salary, int departmentId)
        {


            using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
            {
                string query = @"UPDATE Employees 
                         SET Name = @Name,
                             Email = @Email,
                             Salary = @Salary,
                             DepartmentId = @DepartmentId
                         WHERE Id = @Id";

                SqlCommand command = new SqlCommand(query,connection);


                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Salary", salary);
                command.Parameters.AddWithValue("@DepartmentId", departmentId);


                connection.Open();

                int rowsAffected = command.ExecuteNonQuery();

                return rowsAffected > 0;

            }


        }



        public bool Delete(int id)
        {

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
            {

                string query = "DELETE FROM Employees WHERE Id = @Id";

                SqlCommand command = new SqlCommand(query, connection);


                command.Parameters.AddWithValue("@Id", id);

                connection.Open();



                int rowsAffected = command.ExecuteNonQuery();

                return rowsAffected > 0;


            }


        }

    }

}





    

