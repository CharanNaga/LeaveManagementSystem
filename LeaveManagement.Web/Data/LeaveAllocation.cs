using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagement.Web.Data
{
    public class LeaveAllocation : BaseEntity
    {
        public int NumberOfDays { get; set; } //No.of days to allocate leave

        [ForeignKey("LeaveTypeId")]
        public LeaveType LeaveType { get; set; } //Creating a foreign key field for retrieving Leave Type with Foreign Key as LeaveType's Id
        public int LeaveTypeId { get; set; }

        // Creating an another foreign key for Allocating Leave to particular Employee
        public string EmployeeId { get; set; }

        public int Period { get; set; } //Determines no. of allocated leave days for this year
    }
}
