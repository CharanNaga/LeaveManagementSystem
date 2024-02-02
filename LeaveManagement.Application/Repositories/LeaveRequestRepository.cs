using AutoMapper;
using AutoMapper.QueryableExtensions;
using LeaveManagement.Application.Contracts;
using LeaveManagement.Data;
using LeaveManagement.Common.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace LeaveManagement.Application.Repositories
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly UserManager<Employee> _userManager;
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly AutoMapper.IConfigurationProvider _configurationProvider;
        private readonly IEmailSender _emailSender;

        public LeaveRequestRepository(
            ApplicationDbContext db, IMapper mapper,
            IHttpContextAccessor contextAccessor,
            UserManager<Employee> userManager,
            ILeaveAllocationRepository leaveAllocationRepository,
            AutoMapper.IConfigurationProvider configurationProvider,
            IEmailSender emailSender
            ) : base(db)
        {
            _db = db;
            _mapper = mapper;
            _contextAccessor = contextAccessor;
            _userManager = userManager;
            _leaveAllocationRepository = leaveAllocationRepository;
            _configurationProvider = configurationProvider;
            _emailSender = emailSender;
        }

        public async Task CancelLeaveRequest(int leaveRequestId)
        {
            var leaveRequest = await GetAsync(leaveRequestId);
            leaveRequest.IsCancelled = true;
            await UpdateAsync(leaveRequest);

            var user = await _userManager.FindByIdAsync(leaveRequest.RequestingEmployeeId);
            await _emailSender.SendEmailAsync(user.Email,
               "Leave Request Cancelled.",
               $"Your Leave Request from {leaveRequest.StartDate} to {leaveRequest.EndDate} has been cancelled."
               );
        }

        public async Task ChangeApprovalStatus(int leaveRequestId, bool isApproved)
        {
            var leaveRequest = await GetAsync(leaveRequestId);
            leaveRequest.IsApproved = isApproved;

            if(isApproved)
            {
                var allocation = await _leaveAllocationRepository.GetEmployeeAllocation(
                    leaveRequest.RequestingEmployeeId, leaveRequest.LeaveTypeId
                    );
                int requestedDays = (int)(leaveRequest.EndDate - leaveRequest.StartDate).TotalDays;
                allocation.NumberOfDays -= requestedDays;
                await _leaveAllocationRepository.UpdateAsync(allocation);
            }
            await UpdateAsync(leaveRequest);

            var user = await _userManager.FindByIdAsync(leaveRequest.RequestingEmployeeId);
            var approvalStatus = isApproved ? "Approved" : "Declined";

            await _emailSender.SendEmailAsync(user.Email,
               $"Leave Request {approvalStatus}.",
               $"Your Leave Request from {leaveRequest.StartDate} to {leaveRequest.EndDate} has been {approvalStatus}."
               );
        }

        public async Task<bool> CreateLeaveRequest(LeaveRequestCreateViewModel leaveRequestCreateViewModel)
        {
            var user = await _userManager.GetUserAsync(_contextAccessor?.HttpContext?.User);

            var leaveAllocation = await _leaveAllocationRepository.GetEmployeeAllocation(
                user.Id, leaveRequestCreateViewModel.LeaveTypeId
                );

            if( leaveAllocation == null )
            {
                return false;
            }

            int daysRequested = (int)(
                leaveRequestCreateViewModel.EndDate.Value - leaveRequestCreateViewModel.StartDate.Value
                ).TotalDays;

            if(daysRequested > leaveAllocation.NumberOfDays)
            {
                return false;
            }

            var leaveRequest = _mapper.Map<LeaveRequest>(leaveRequestCreateViewModel);
            leaveRequest.RequestedDate = DateTime.Now;
            leaveRequest.RequestingEmployeeId = user.Id;

            await AddAsync(leaveRequest);

            await _emailSender.SendEmailAsync(user.Email,
                "Leave Request Submitted Successfully.",
                $"Your Leave Request from {leaveRequest.StartDate} to {leaveRequest.EndDate} has been submitted for approval."
                );
      
            return true;
        }

        public async Task<AdminLeaveRequestViewModel> GetAdminLeaveRequestList()
        {
            var leaveRequests = await _db.LeaveRequests.Include(l => l.LeaveType).Where(l=>l.IsCancelled == false).ToListAsync();
            var model = new AdminLeaveRequestViewModel
            {
                TotalRequests = leaveRequests.Count,
                ApprovedRequests = leaveRequests.Count(l => l.IsApproved == true),
                PendingRequests = leaveRequests.Count(l => l.IsApproved == null),
                RejectedRequests = leaveRequests.Count(l => l.IsApproved == false),
                LeaveRequests = _mapper.Map<List<LeaveRequestViewModel>>(leaveRequests)
            };

            foreach (var leaveRequest in model.LeaveRequests)
            {
                leaveRequest.Employee = _mapper.Map<EmployeeListViewModel>
                    (await _userManager.FindByIdAsync(leaveRequest.RequestingEmployeeId));
            }
            return model;
        }

        public async Task<List<LeaveRequestViewModel>> GetAllAsync(string employeeId)
        {
            return await _db.LeaveRequests
                .Where(l => l.RequestingEmployeeId == employeeId)
                .ProjectTo<LeaveRequestViewModel>(_configurationProvider)
                .ToListAsync();
        }

        public async Task<LeaveRequestViewModel?> GetLeaveRequestAsync(int? id)
        {
            var leaveRequest = await _db.LeaveRequests.Include(l => l.LeaveType)
                .FirstOrDefaultAsync(l => l.Id == id);

            if (leaveRequest == null)
                return null;

            var model = _mapper.Map<LeaveRequestViewModel>(leaveRequest);

            model.Employee = _mapper.Map<EmployeeListViewModel>
                (await _userManager.FindByIdAsync(leaveRequest?.RequestingEmployeeId));

            return model;
        }

        public async Task<EmployeeLeaveRequestViewModel> GetMyLeaveDetails()
        {
            var user = await _userManager.GetUserAsync(_contextAccessor?.HttpContext?.User);
            var allocations = (await _leaveAllocationRepository.GetEmployeeAllocations(user.Id)).LeaveAllocations;
            var requests = await GetAllAsync(user.Id);

            var model = new EmployeeLeaveRequestViewModel(allocations, requests);
            return model;
        }
    }
}