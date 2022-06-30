using StudentLoginInfo.Models;

namespace EmployeeLoginInfo.Models
{
    public class AddEmployeeDetail 
    {
        public int id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string PresentAddress { get; set; }
        public string PermanentAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string PhoneNo { get; set; }
        public string EmailAddress { get; set; }
    }
}
