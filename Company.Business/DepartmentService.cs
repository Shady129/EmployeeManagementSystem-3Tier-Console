using Company.DataAccess;

namespace Company.Business
{
    public class DepartmentService
    {


        private DepartmentDAL _departmentDAL;


        public DepartmentService()
        {

            _departmentDAL = new DepartmentDAL();

        }



        public bool AddDepartment(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return false;
            name = name.Trim();

            if (_departmentDAL.IsDepartmentExists(name))
                return false;

            return _departmentDAL.AddDepartment(name);
        }



        public List<Department> GetAllDepartments()
        {
            return _departmentDAL.GetAllDepartments();
        }


        public Department GetDepartmentById(int id)
        {
            return _departmentDAL.GetDepartmentById(id);
        }




        public bool UpdateDepartment(int id, string name)
        {
            if (string.IsNullOrEmpty(name))
                return false;

            if (name.Trim().Length < 3)
                return false;

            if (_departmentDAL.GetDepartmentById(id) == null)
                return false;

            return _departmentDAL.UpdateDepartment(id, name);

        }


 
        public bool DeleteDepartment(int id)
        {
            var dept = _departmentDAL.GetDepartmentById(id);

            if (dept == null)
                return false;

            return _departmentDAL.DeleteDepartment(id);
        }
    }
}
