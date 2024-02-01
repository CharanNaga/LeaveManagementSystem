using AutoMapper;
using LeaveManagement.Web.Contracts;
using LeaveManagement.Web.Data;
using LeaveManagement.Web.Models;
using Microsoft.AspNetCore.Identity;

namespace LeaveManagement.Web.Repositories
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly UserManager<Employee> _userManager;

        public LeaveRequestRepository(
            ApplicationDbContext db, IMapper mapper,
            IHttpContextAccessor contextAccessor,
            UserManager<Employee> userManager
            ) : base(db)
        {
            _mapper = mapper;
            _contextAccessor = contextAccessor;
            _userManager = userManager;
        }

        public async Task CreateLeaveRequest(LeaveRequestCreateViewModel leaveRequestCreateViewModel)
        {
            var user = await _userManager.GetUserAsync(_contextAccessor?.HttpContext?.User);
            var leaveRequest = _mapper.Map<LeaveRequest>(leaveRequestCreateViewModel);
            leaveRequest.RequestedDate = DateTime.Now;
            leaveRequest.RequestingEmployeeId = user.Id;

            await AddAsync(leaveRequest);
        }
    }
}