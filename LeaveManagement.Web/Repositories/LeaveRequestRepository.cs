using AutoMapper;
using LeaveManagement.Web.Contracts;
using LeaveManagement.Web.Data;
using LeaveManagement.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagement.Web.Repositories
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly UserManager<Employee> _userManager;
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;

        public LeaveRequestRepository(
            ApplicationDbContext db, IMapper mapper,
            IHttpContextAccessor contextAccessor,
            UserManager<Employee> userManager,
            ILeaveAllocationRepository leaveAllocationRepository
            ) : base(db)
        {
            _db = db;
            _mapper = mapper;
            _contextAccessor = contextAccessor;
            _userManager = userManager;
            _leaveAllocationRepository = leaveAllocationRepository;
        }

        public async Task CreateLeaveRequest(LeaveRequestCreateViewModel leaveRequestCreateViewModel)
        {
            var user = await _userManager.GetUserAsync(_contextAccessor?.HttpContext?.User);
            var leaveRequest = _mapper.Map<LeaveRequest>(leaveRequestCreateViewModel);
            leaveRequest.RequestedDate = DateTime.Now;
            leaveRequest.RequestingEmployeeId = user.Id;

            await AddAsync(leaveRequest);
        }

        public async Task<List<LeaveRequest>> GetAllAsync(string employeeId)
        {
            return await _db.LeaveRequests.Where(l => l.RequestingEmployeeId == employeeId).ToListAsync();
        }

        public async Task<EmployeeLeaveRequestViewModel> GetMyLeaveDetails()
        {
            var user = await _userManager.GetUserAsync(_contextAccessor?.HttpContext?.User);
            var allocations = (await _leaveAllocationRepository.GetEmployeeAllocations(user.Id)).LeaveAllocations;
            var requests = _mapper.Map<List<LeaveRequestViewModel>>(await GetAllAsync(user.Id));

            var model = new EmployeeLeaveRequestViewModel(allocations, requests);
            return model;
        }
    }
}