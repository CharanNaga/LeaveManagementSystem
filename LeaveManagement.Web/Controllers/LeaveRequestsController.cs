﻿using LeaveManagement.Web.Constants;
using LeaveManagement.Web.Contracts;
using LeaveManagement.Web.Data;
using LeaveManagement.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagement.Web.Controllers
{
    [Authorize]
    public class LeaveRequestsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly ILogger<LeaveRequestsController> _logger;

        public LeaveRequestsController(ApplicationDbContext context, ILeaveRequestRepository leaveRequestRepository,ILeaveTypeRepository leaveTypeRepository, ILogger<LeaveRequestsController> logger)
        {
            _context = context;
            _leaveRequestRepository = leaveRequestRepository;
            _leaveTypeRepository = leaveTypeRepository;
            _logger = logger;
        }

        // GET: LeaveRequests
        [Authorize(Roles = Roles.Administrator)]
        public async Task<IActionResult> Index()
        {
            var model = await _leaveRequestRepository.GetAdminLeaveRequestList();
            return View(model);
        }

        public async Task<ActionResult> MyLeave()
        {
            var model = await _leaveRequestRepository.GetMyLeaveDetails();
            return View(model);
        }

        // GET: LeaveRequests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var model = await _leaveRequestRepository.GetLeaveRequestAsync(id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ApproveRequest(int id, bool isApproved)
        {
            try
            {
                await _leaveRequestRepository.ChangeApprovalStatus(id, isApproved);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "Error While Performing Approve Leave Request");
                throw;
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cancel(int id)
        {
            try
            {
                await _leaveRequestRepository.CancelLeaveRequest(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "Error While Performing Cancel Leave Request");
                throw;
            }
            return RedirectToAction(nameof(MyLeave));
        }

        // GET: LeaveRequests/Create
        public async Task<IActionResult> Create()
        {
            var model = new LeaveRequestCreateViewModel
            {
                LeaveTypes = new SelectList(await _leaveTypeRepository.GetAllAsync(), "Id", "Name")
            };
            return View(model);
        }

        // POST: LeaveRequests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LeaveRequestCreateViewModel leaveRequestCreateViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var isValidRequest = await _leaveRequestRepository.CreateLeaveRequest(leaveRequestCreateViewModel);
                    if (isValidRequest)
                        return RedirectToAction(nameof(MyLeave));
                    ModelState.AddModelError("Error", "You have exceeded your allocation with this request");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "Error While Creating Leave Request");
                ModelState.AddModelError("Error", "Something error occurred");
            }

            leaveRequestCreateViewModel.LeaveTypes = new SelectList(await _leaveTypeRepository.GetAllAsync(), "Id", "Name", leaveRequestCreateViewModel.LeaveTypeId);
            return View(leaveRequestCreateViewModel);
        }

        // GET: LeaveRequests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.LeaveRequests == null)
            {
                return NotFound();
            }

            var leaveRequest = await _context.LeaveRequests.FindAsync(id);
            if (leaveRequest == null)
            {
                return NotFound();
            }
            ViewData["LeaveTypeId"] = new SelectList(await _leaveTypeRepository.GetAllAsync(), "Id", "Name", leaveRequest.LeaveTypeId);
            return View(leaveRequest);
        }

        // POST: LeaveRequests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StartDate,EndDate,LeaveTypeId,RequestedDate,RequestComments,IsAppoved,IsCancelled,RequestingEmployeeId,Id,DateCreated,DateModified")] LeaveRequest leaveRequest)
        {
            if (id != leaveRequest.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(leaveRequest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeaveRequestExists(leaveRequest.Id))
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
            ViewData["LeaveTypeId"] = new SelectList(await _leaveTypeRepository.GetAllAsync(), "Id", "Name", leaveRequest.LeaveTypeId);
            return View(leaveRequest);
        }

        // GET: LeaveRequests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.LeaveRequests == null)
            {
                return NotFound();
            }

            var leaveRequest = await _context.LeaveRequests
                .Include(l => l.LeaveType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (leaveRequest == null)
            {
                return NotFound();
            }

            return View(leaveRequest);
        }

        // POST: LeaveRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.LeaveRequests == null)
            {
                return Problem("Entity set 'ApplicationDbContext.LeaveRequests'  is null.");
            }
            var leaveRequest = await _context.LeaveRequests.FindAsync(id);
            if (leaveRequest != null)
            {
                _context.LeaveRequests.Remove(leaveRequest);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LeaveRequestExists(int id)
        {
            return (_context.LeaveRequests?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
