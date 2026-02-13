using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using System.Collections.Generic;

namespace Company.DataAccess
{
    public class DepartmentDAL
    {
        
        public bool AddDepartment(string name)
        {
            using(SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
            {
                string query = "INSERT INTO Departments (Name) VALUES (@Name)";


                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", name);

                connection.Open();

                int rowAffected  = command.ExecuteNonQuery();
                return rowAffected > 0;
            }
        }


        public List<Department>GetAllDepartments()
        {
            List<Department> departments = new List<Department>();

            using(SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
            {
                string query = "SELECT Id, Name FROM Departments";


                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();

               

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Department department = new Department();


                    department.Id = (int)reader["Id"];
                    department.Name = reader["Name"].ToString()?? "";


                    departments.Add(department);
                }
                return departments;
            }
        }


        public Department GetDepartmentById(int id)
        {
            Department department = null;

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
            {
                string query = "SELECT Id, Name FROM Departments WHERE Id = @Id";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Id", id);


                connection.Open();
         

                using(SqlDataReader reader = command.ExecuteReader())
                {
                    if(reader.Read())
                    {
                        department = new Department(); 
                        department.Id = (int) reader["Id"];
                        department.Name = reader["Name"].ToString();
                    }
                }

            }
            return department;
        }



        public bool DeleteDepartment(int id)
        {

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
            {


                string query = "DELETE FROM Departments WHERE Id = @Id";


                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Id",id);



                connection.Open();

                try
                {

                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch(SqlException ex)
                {
                    if (ex.Number == 547)

                        throw new Exception("Cannot delete department because it contains employees.");
                    throw;
                }
            }

        }

        public bool UpdateDepartment(int id, string name)
        {


            using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
            {

                string query = "UPDATE Departments SET Name = @Name WHERE Id = @Id";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Name",name);
                command.Parameters.AddWithValue("@Id", id);

                connection.Open();

                int rowsAffected = command.ExecuteNonQuery();

                return rowsAffected > 0;

            }

        }


        public bool IsDepartmentExists(string name)
        {
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
            {
                string query = "SELECT 1 FROM Departments WHERE Name = @Name";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Name", name);


                connection.Open();


                object result = command.ExecuteScalar();

                return result != null;

            }


        }

    }
}
