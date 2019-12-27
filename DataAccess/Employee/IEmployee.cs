using System.Collections.Generic;
using BE = BusinessEntity;

namespace DataAccess
{
    public interface IEmployee
    {
        int Insert(BE.EmployeeModel employeeModel);
        bool Update(BE.EmployeeModel employeeModel);
        bool Delete(int Id);
        BE.EmployeeModel GetEmployeeById(int employeeId);
        List<BE.EmployeeModel> GetEmployees();
        //Pagination<BE.EmployeeDepartment> GetAllEmployees();
    }
}
