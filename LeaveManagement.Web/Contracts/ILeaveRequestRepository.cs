﻿using LeaveManagement.Web.Data;
using LeaveManagement.Web.Models;

namespace LeaveManagement.Web.Contracts
{
    public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
    {
        Task CreateLeaveRequest(LeaveRequestCreateViewModel leaveRequestCreateViewModel);
        Task<EmployeeLeaveRequestViewModel> GetMyLeaveDetails();
        Task<List<LeaveRequest>> GetAllAsync(string employeeId);
    }
}