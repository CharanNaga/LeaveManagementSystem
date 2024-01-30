using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LeaveManagement.Web.Data;
using AutoMapper;
using LeaveManagement.Web.Models;

namespace LeaveManagement.Web.Controllers
{
    public class LeaveTypesController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public LeaveTypesController(ApplicationDbContext db,IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        // GET: LeaveTypes
        public async Task<IActionResult> Index()
        {
              return _db.LeaveTypes != null ? 
                          View(
                              _mapper.Map<List<LeaveTypeViewModel>>(        //To achieve SRP LeaveTypes is responsible for working with LeaveType data model. so we segregate data model & view model
                                  await _db.LeaveTypes.ToListAsync()        /* select * from LeaveTypes; */
                                  )
                              ) 
                          : Problem("Entity set 'ApplicationDbContext.LeaveTypes' is null.");
        }

        // GET: LeaveTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _db.LeaveTypes == null)
            {
                return NotFound();
            }

            var leaveType = await _db.LeaveTypes
                .FirstOrDefaultAsync(m => m.Id == id);  /* select * from LeaveTypes where Id = 5; */

            if (leaveType == null)
            {
                return NotFound();
            }

            return View(leaveType);
        }

        // GET: LeaveTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LeaveTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LeaveTypeViewModel leaveTypeViewModel)
        {
            if (ModelState.IsValid)
            {
                var leaveType = _mapper.Map<LeaveType>(leaveTypeViewModel);
                _db.Add(leaveType);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(leaveTypeViewModel);
        }

        // GET: LeaveTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _db.LeaveTypes == null)
            {
                return NotFound();
            }

            var leaveType = await _db.LeaveTypes.FindAsync(id);

            if (leaveType == null)
            {
                return NotFound();
            }
            return View(leaveType);
        }

        // POST: LeaveTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,DefaultDays,Id,DateCreated,DateModified")] LeaveType leaveType)
        {
            if (id != leaveType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(leaveType);
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException) //Raises if two persons trying to update at the same time
                {
                    if (!LeaveTypeExists(leaveType.Id))
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
            return View(leaveType);
        }

        // GET: LeaveTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _db.LeaveTypes == null)
            {
                return NotFound();
            }

            var leaveType = await _db.LeaveTypes
                .FirstOrDefaultAsync(m => m.Id == id);

            if (leaveType == null)
            {
                return NotFound();
            }

            return View(leaveType);
        }

        // POST: LeaveTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_db.LeaveTypes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.LeaveTypes' is null.");
            }

            var leaveType = await _db.LeaveTypes.FindAsync(id);

            if (leaveType != null)
            {
                _db.LeaveTypes.Remove(leaveType);
            }
            
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LeaveTypeExists(int id)
        {
          return (_db.LeaveTypes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
