using AutoMapper;
using LeaveManagement.Web.Constants;
using LeaveManagement.Web.Contracts;
using LeaveManagement.Web.Data;
using LeaveManagement.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagement.Web.Repositories
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<Employee> _userManager;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public LeaveAllocationRepository(ApplicationDbContext db, UserManager<Employee> userManager,ILeaveTypeRepository leaveTypeRepository,IMapper mapper) : base(db)
        {
            _db = db;
            _userManager = userManager;
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<bool> AllocationExists(string employeeId, int leaveTypeId, int period)
        {
            return await _db.LeaveAllocations.AnyAsync(l =>  l.EmployeeId == employeeId
                                                            && l.LeaveTypeId == leaveTypeId
                                                            && l.Period == period);
        }

        public async Task<EmployeeAllocationViewModel> GetEmployeeAllocations(string employeeId)
        {
            var allocations = await _db.LeaveAllocations
                .Include(l => l.LeaveType) //equivalent to inner join two tables(LeaveTypes, LeaveAllocations) with a foreign key
                .Where(l => l.EmployeeId == employeeId)
                .ToListAsync();
            var employee = await _userManager.FindByIdAsync(employeeId);

            var employeeAllocationModel = _mapper.Map<EmployeeAllocationViewModel>(employee);
            employeeAllocationModel.LeaveAllocations  = _mapper.Map<List<LeaveAllocationViewModel>>(allocations);
            return employeeAllocationModel;
        }

        public async Task<LeaveAllocationEditViewModel> GetEmployeeAllocation(int Id)
        {
            var allocation = await _db.LeaveAllocations
                .Include(l => l.LeaveType) //equivalent to inner join two tables(LeaveTypes, LeaveAllocations) with a foreign key
                .FirstOrDefaultAsync(l => l.Id == Id);

            if(allocation == null)
            {
                return null;
            }

            var employee = await _userManager.FindByIdAsync(allocation.EmployeeId);

            var leaveAllocationEditViewModel = _mapper.Map<LeaveAllocationEditViewModel>(allocation);
            leaveAllocationEditViewModel.Employee = _mapper.Map<EmployeeListViewModel>(employee);
            return leaveAllocationEditViewModel;
        }

        public async Task LeaveAllocation(int leaveTypeId)
        {
            var employees = await _userManager.GetUsersInRoleAsync(Roles.User);
            var period = DateTime.Now.Year;
            var leaveType = await _leaveTypeRepository.GetAsync(leaveTypeId);
            var allocations = new List<LeaveAllocation>();
            
            foreach (var employee in employees)
            {
                if (await AllocationExists(employee.Id, leaveTypeId, period))
                    continue;

                allocations.Add(new LeaveAllocation
                {
                    EmployeeId = employee.Id,
                    LeaveTypeId = leaveTypeId,
                    Period = period,
                    NumberOfDays = leaveType.DefaultDays
                });
            }
            await AddRangeAsync(allocations);
        }

        public async Task<bool> UpdateEmployeeAllocation(LeaveAllocationEditViewModel leaveAllocationEditViewModel)
        {
            var leaveAllocation = await GetAsync(leaveAllocationEditViewModel.Id);
            if (leaveAllocation == null)
            {
                return false;
            }
            leaveAllocation.Period = leaveAllocationEditViewModel.Period;
            leaveAllocation.NumberOfDays = leaveAllocationEditViewModel.NumberOfDays;
            await UpdateAsync(leaveAllocation);
            return true;
        }
    }
}
