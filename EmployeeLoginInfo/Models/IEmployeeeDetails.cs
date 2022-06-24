using StudentLoginInfo.Models;

namespace EmployeeLoginInfo.Models
{
    public interface IEmployeeeDetails
    {
        EmployeeDetail GetEmployeeDetailById(int id);
        IEnumerable<EmployeeDetail> GetAllEmployeeDetail();
        void Post(EmployeeDetail employeeDetail, EmployeeDetail existingEmployeeDetail);
        void DeleteStudentDetail(int id);
    }
}