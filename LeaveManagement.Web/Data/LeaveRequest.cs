﻿using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagement.Web.Data
{
    public class LeaveRequest : BaseEntity
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [ForeignKey("LeaveTypeId")]
        public LeaveType LeaveType { get; set; } //Creating a foreign key field for retrieving Leave Type with Foreign Key as LeaveType's Id
        public int LeaveTypeId { get; set; }

        public DateTime RequestedDate { get; set; }

        public string RequestComments { get; set; }

        public bool? IsAppoved { get; set; }
        public bool IsCancelled { get; set; }

        public string RequestingEmployeeId { get; set; }
    }
}
