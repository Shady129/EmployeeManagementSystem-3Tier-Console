using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.DataAccess
{
    public class Employee
    {
       public int Id { get; set; }
       public string Name { get; set; }
       public string Email { get; set; }
       public decimal Salary { get; set; }
       public DateTime HireDate { get; set; }
       public bool IsActive { get; set; }
       public int DepartmentId { get; set; }
       public string DepartmentName { get; set; }
    }
}
