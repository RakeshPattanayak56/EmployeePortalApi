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
        public int PostalCode { get; set; }
        public int PhoneNo { get; set; }
        public string EmailAddress { get; set; }
    }
}
