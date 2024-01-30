using System.ComponentModel.DataAnnotations;

namespace LeaveManagement.Web.Models
{
    public class LeaveTypeViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Leave Type")]
        [Required(ErrorMessage ="Leave Type can't be blank")]
        public string Name { get; set; }

        [Display(Name = "Default Number of Days")]
        [Required]
        [Range(1,25,ErrorMessage ="Number should lies between 1 & 25")]
        public int DefaultDays { get; set; }
    }
}
