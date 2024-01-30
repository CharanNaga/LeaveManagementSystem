using System.ComponentModel.DataAnnotations;

namespace LeaveManagement.Web.Models
{
    public class LeaveTypeViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Leave Type")]
        public string Name { get; set; }

        [Display(Name = "Default Number of Days")]
        public int DefaultDays { get; set; }
    }
}
