using System;
using Company.DataAccess;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Business
{
    public class EmployeeService
    {

        private EmployeeDAL _employeeDAL;

        private DepartmentDAL _departmentDAL;

        public EmployeeService()
        {
            _employeeDAL = new EmployeeDAL();
            _departmentDAL = new DepartmentDAL();
        }



        public bool AddEmployee(string name, string email, decimal salary, DateTime hireDate, bool isActive, int departmentId)
        {

            if(string.IsNullOrWhiteSpace(name))
                return false;

            name = name.Trim();

            if (name.Trim().Length < 3)
                return false;

            if(salary <= 0)
                return false;

            if(_departmentDAL.GetDepartmentById(departmentId) == null)
                return false;

            return _employeeDAL.AddEmployee(name, email, salary, hireDate, isActive, departmentId);
        }





        public List<Employee>GetAllEmployees()
        {

            return _employeeDAL.GetEmployees();
        }


        public Employee GetEmployee(int id)
        {
            return _employeeDAL.GetEmployee(id);
        }


        public bool UpdateEmployee(int id, string name, string email, decimal salary, int departmentId)
        {

            if (string.IsNullOrEmpty(name))
                return false;

            if (name.Trim().Length < 3)
                return false;

            if (string.IsNullOrWhiteSpace(email))
                return false;

            if (salary <= 0)
                return false;

            if (_employeeDAL.GetEmployee(id) == null)
                return false;

            if (_departmentDAL.GetDepartmentById(departmentId) == null)
                return false;

            return _employeeDAL.UpdateEmployee(id, name, email, salary, departmentId);
        }



        public bool DeleteEmployee(int id)
        {
            return _employeeDAL.Delete(id);
        }





    }
}
