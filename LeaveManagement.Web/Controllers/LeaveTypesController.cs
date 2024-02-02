using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LeaveManagement.Data;
using AutoMapper;
using LeaveManagement.Common.Models;
using LeaveManagement.Application.Contracts;
using Microsoft.AspNetCore.Authorization;
using LeaveManagement.Common.Constants;

namespace LeaveManagement.Web.Controllers
{
    [Authorize(Roles = Roles.Administrator)]
    public class LeaveTypesController : Controller
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;

        public LeaveTypesController(ILeaveTypeRepository leaveTypeRepository,IMapper mapper, ILeaveAllocationRepository leaveAllocationRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
            _leaveAllocationRepository = leaveAllocationRepository;
        }

        // GET: LeaveTypes
        public async Task<IActionResult> Index()
        {
              return _leaveTypeRepository != null ? 
                          View(
                              _mapper.Map<List<LeaveTypeViewModel>>(        //To achieve SRP LeaveTypes is responsible for working with LeaveType data model. so we segregate data model & view model
                                  await _leaveTypeRepository.GetAllAsync()       /* select * from LeaveTypes; */
                                  )
                              ) 
                          : Problem("Repository 'LeaveTypeRepository' is null.");
        }

        // GET: LeaveTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var leaveType = await _leaveTypeRepository.GetAsync(id);
                  /* select * from LeaveTypes where Id = 5; */

            if (leaveType == null)
            {
                return NotFound();
            }

            var leaveTypeViewModel = _mapper.Map<LeaveTypeViewModel>(leaveType);

            return View(leaveTypeViewModel);
        }

        // GET: LeaveTypes/Create
        //[Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: LeaveTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Create(LeaveTypeViewModel leaveTypeViewModel)
        {
            if (ModelState.IsValid)
            {
                var leaveType = _mapper.Map<LeaveType>(leaveTypeViewModel);
                await _leaveTypeRepository.AddAsync(leaveType);
                return RedirectToAction(nameof(Index));
            }
            return View(leaveTypeViewModel);
        }

        // GET: LeaveTypes/Edit/5
        //[Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int? id)
        {
            var leaveType = await _leaveTypeRepository.GetAsync(id);

            if (leaveType == null)
            {
                return NotFound();
            }
            var leaveTypeViewModel = _mapper.Map<LeaveTypeViewModel>(leaveType);
            return View(leaveTypeViewModel);
        }

        // POST: LeaveTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int id, LeaveTypeViewModel leaveTypeViewModel)
        {
            if (id != leaveTypeViewModel.Id)
            {
                return NotFound();
            }

            var leaveType = await _leaveTypeRepository.GetAsync(id);

            if(leaveType == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _mapper.Map(leaveTypeViewModel, leaveType);
                    await _leaveTypeRepository.UpdateAsync(leaveType);
                }
                catch (DbUpdateConcurrencyException) //Raises if two persons trying to update at the same time
                {
                    if (!await LeaveTypeExists(leaveTypeViewModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(leaveTypeViewModel);
        }

        // POST: LeaveTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_leaveTypeRepository == null)
            {
                return Problem("Repository 'LeaveTypeRepository' is null.");
            }
            await _leaveTypeRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> LeaveTypeExists(int id)
        {
          return await _leaveTypeRepository.IfExists(id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AllocateLeave(int id)
        {
            await _leaveAllocationRepository.LeaveAllocation(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
