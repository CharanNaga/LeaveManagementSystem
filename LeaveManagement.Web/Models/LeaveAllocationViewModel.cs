using System.ComponentModel.DataAnnotations;

namespace LeaveManagement.Web.Models
{
    public class LeaveAllocationViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Number Of Days")]
        [Range(1,50,ErrorMessage = "Number Lies between 1 & 50")]
        public int NumberOfDays { get; set; }

        [Required]
        [Display(Name = "Allocation Period")]
        public int Period { get; set; }

        public LeaveTypeViewModel? LeaveType { get; set; }
    }
}