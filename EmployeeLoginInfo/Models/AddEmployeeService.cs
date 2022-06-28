namespace EmployeeLoginInfo.Models
{
    public class AddEmployeeService : IAddEmployeeDetails
    {
        private EmployeeDb2022Context _context;
        public AddEmployeeService(EmployeeDb2022Context context)
        {
            _context = context;
        }

        public AddEmployeeDetail GetAddEmployeeDetailById(int id)
        {
            try
            {
#pragma warning disable CS8603 // Possible null reference return.
                return _context.AddEmployeeDetails.Where(x => x.id == id).FirstOrDefault();
#pragma warning restore CS8603 // Possible null reference return.
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<AddEmployeeDetail> GetAllAddEmployeeDetail()
        {
            try
            {
                var addEmployeeDetail = _context.AddEmployeeDetails;
                return addEmployeeDetail;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Post(AddEmployeeDetail addEmployeeDetail, AddEmployeeDetail existingAddEmployeeDetail)
        {
            try
            {
                if (addEmployeeDetail.id == 0)
                {
                    _context.AddEmployeeDetails.Add(addEmployeeDetail);
                }
                else
                {
                    existingAddEmployeeDetail.id = addEmployeeDetail.id;
                }
                int i = this._context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
