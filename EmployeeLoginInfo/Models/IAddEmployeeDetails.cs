namespace EmployeeLoginInfo.Models
{
    public interface IAddEmployeeDetails
    {
        AddEmployeeDetail GetAddEmployeeDetailById(int id);
        IEnumerable<AddEmployeeDetail> GetAllAddEmployeeDetail();
        void Post(AddEmployeeDetail addEmployeeDetail, AddEmployeeDetail existingAddEmployeeDetail);
    }
}
