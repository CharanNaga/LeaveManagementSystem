namespace LeaveManagement.Web.Data
{
    public class LeaveType : BaseEntity
    {
        public string Name { get; set; } //Type of Leave sick or earned
        public int DefaultDays { get; set; } //Default Number of Leaves present
    }
}