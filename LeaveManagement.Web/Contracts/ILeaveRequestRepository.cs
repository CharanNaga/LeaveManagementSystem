using LeaveManagement.Web.Data;
using LeaveManagement.Web.Models;

namespace LeaveManagement.Web.Contracts
{
    public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
    {
        Task<bool> CreateLeaveRequest(LeaveRequestCreateViewModel leaveRequestCreateViewModel);
        Task<EmployeeLeaveRequestViewModel> GetMyLeaveDetails();
        Task<List<LeaveRequest>> GetAllAsync(string employeeId);
        Task<AdminLeaveRequestViewModel> GetAdminLeaveRequestList();
        Task ChangeApprovalStatus(int leaveRequestId, bool isApproved);
        Task<LeaveRequestViewModel?> GetLeaveRequestAsync(int? id);
        Task CancelLeaveRequest(int leaveRequestId);
    }
}