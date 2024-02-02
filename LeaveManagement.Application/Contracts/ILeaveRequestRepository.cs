using LeaveManagement.Data;
using LeaveManagement.Common.Models;

namespace LeaveManagement.Application.Contracts
{
    public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
    {
        Task<bool> CreateLeaveRequest(LeaveRequestCreateViewModel leaveRequestCreateViewModel);
        Task<EmployeeLeaveRequestViewModel> GetMyLeaveDetails();
        Task<List<LeaveRequestViewModel>> GetAllAsync(string employeeId);
        Task<AdminLeaveRequestViewModel> GetAdminLeaveRequestList();
        Task ChangeApprovalStatus(int leaveRequestId, bool isApproved);
        Task<LeaveRequestViewModel?> GetLeaveRequestAsync(int? id);
        Task CancelLeaveRequest(int leaveRequestId);
    }
}