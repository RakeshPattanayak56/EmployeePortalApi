using StudentLoginInfo.Models;

namespace EmployeeLoginInfo.Models
{
    public class EmployeeService : IEmployeeeDetails
    {
        private EmployeeDb2022Context _context;
        public EmployeeService(EmployeeDb2022Context context)
        {
            _context = context;
        }


        public EmployeeDetail GetEmployeeDetailById(int id)
        {
            try
            {
#pragma warning disable CS8603 // Possible null reference return.
                return _context.EmployeeDetails.Where(x => x.Id == id).FirstOrDefault();
#pragma warning restore CS8603 // Possible null reference return.
            }
            catch (Exception)
            {
                throw;
            }
        }
        public IEnumerable<EmployeeDetail> GetAllEmployeeDetail()
        {
            try
            {
                var employeeDetail = _context.EmployeeDetails;
                return employeeDetail;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Post(EmployeeDetail employeeDetail, EmployeeDetail existingEmployeeDetail)
        {
            try
            {
                if (employeeDetail.Id == 0)
                {
                    _context.EmployeeDetails.Add(employeeDetail);
                }
                else
                {
                    existingEmployeeDetail.Id = employeeDetail.Id;
                    existingEmployeeDetail.UserId = employeeDetail.UserId;
                    existingEmployeeDetail.UserName = employeeDetail.UserName;
                    existingEmployeeDetail.LoginTime = employeeDetail.LoginTime;
                    existingEmployeeDetail.LogoutTime = employeeDetail.LogoutTime;
                    existingEmployeeDetail.InDeskTimeIn = employeeDetail.InDeskTimeIn;
                    existingEmployeeDetail.InDeskTimeOut = employeeDetail.InDeskTimeOut;
                    existingEmployeeDetail.LastUpdateTime = employeeDetail.LastUpdateTime;
                    existingEmployeeDetail.LastUpdatedBy = employeeDetail.LastUpdatedBy;
                }
                int i = this._context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void DeleteStudentDetail(int id)
        {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            EmployeeDetail employeeDetail = _context.EmployeeDetails.Find(id);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            if (employeeDetail != null)
            {
                employeeDetail.IsActive = false;
            }
            _context.SaveChanges();
        }
    }
}
