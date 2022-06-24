using System;
using System.Collections.Generic;

namespace StudentLoginInfo.Models
{
    public partial class EmployeeDetail
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public DateTime? Login { get; set; }
        public DateTime? Logout { get; set; }
        public DateTime? InDeskTimeIn { get; set; }
        public DateTime? InDeskTimeOut { get; set; }
        public DateTime? LastUpdateTime { get; set; }
        public string? LastUpdatedBy { get; set; }
        public bool IsActive { get; set; }
    }
}
    