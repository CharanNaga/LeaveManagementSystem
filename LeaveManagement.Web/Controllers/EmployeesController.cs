using AutoMapper;
using LeaveManagement.Common.Constants;
using LeaveManagement.Application.Contracts;
using LeaveManagement.Data;
using LeaveManagement.Common.Models;
using LeaveManagement.Application.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LeaveManagement.Web.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly UserManager<Employee> _userManager;
        private readonly IMapper _mapper;
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        public EmployeesController(UserManager<Employee> userManager,IMapper mapper, ILeaveAllocationRepository leaveAllocationRepository, ILeaveTypeRepository leaveTypeRepository)
        {
            _userManager = userManager;
            _mapper = mapper;
            _leaveAllocationRepository = leaveAllocationRepository;
            _leaveTypeRepository = leaveTypeRepository;

        }

        // GET: EmployeesController
        public async Task<ActionResult> Index()
        {
            var employees = await _userManager.GetUsersInRoleAsync(Roles.User);
            var employeesListModel = _mapper.Map<List<EmployeeListViewModel>>(employees);
            return View(employeesListModel);
        }

        // GET: EmployeesController/ViewAllocations/5
        public async Task<ActionResult> ViewAllocations(string id)
        {
            var model = await _leaveAllocationRepository.GetEmployeeAllocations(id);
            return View(model);
        }


        // GET: EmployeesController/EditAllocation/5
        public async Task<ActionResult> EditAllocation(int id)
        {
            var model = await _leaveAllocationRepository.GetEmployeeAllocation(id);
            if(model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        // POST: EmployeesController/EditAllocation/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAllocation(int id, LeaveAllocationEditViewModel leaveAllocationEditViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if(await _leaveAllocationRepository.UpdateEmployeeAllocation(leaveAllocationEditViewModel))
                        return RedirectToAction(nameof(ViewAllocations),new {id = leaveAllocationEditViewModel.EmployeeId});
                }
            }
            catch(Exception)
            {
                ModelState.AddModelError("Error Message", "Something went wrong. Check again");
            }
            leaveAllocationEditViewModel.Employee = _mapper.Map<EmployeeListViewModel>(await _userManager.FindByIdAsync(leaveAllocationEditViewModel.EmployeeId));
            leaveAllocationEditViewModel.LeaveType = _mapper.Map<LeaveTypeViewModel>(await _leaveTypeRepository.GetAsync(leaveAllocationEditViewModel.LeaveTypeId));
            return View(leaveAllocationEditViewModel);
        }
    }
}