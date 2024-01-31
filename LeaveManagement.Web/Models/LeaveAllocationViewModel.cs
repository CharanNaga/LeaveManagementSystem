namespace LeaveManagement.Web.Models
{
    public class LeaveAllocationViewModel
    {
        public int Id { get; set; }
        public int NumberOfDays { get; set; }
        public int Period { get; set; }
        public LeaveTypeViewModel LeaveType { get; set; }
    }
}