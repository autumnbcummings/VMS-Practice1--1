using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Volunteers_Practice1_.Data;
using Volunteers_Practice1_.Models;

namespace Volunteers_Practice1_.Controllers
{
    public class VolunteersController : Controller
    {
        string y = "Y";
        string p = "P";
        private readonly ApplicationDbContext _context;

        public VolunteersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Volunteers
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Volunteer.ToListAsync());
        }

        // GET: Volunteers/ShowSearchForm
        [Authorize]
        public async Task<IActionResult> ShowSearchForm()
        {
            return View();
        }

        // PoST: Volunteers/ShowSearchResults
        [Authorize]
        public async Task<IActionResult> ShowSearchResults(String SearchPhrase)
        {
            return View("Index", await _context.Volunteer.Where( j => j.firstName.Contains(SearchPhrase)).ToListAsync());
            
        }

        // /ShowApproved
        public async Task<IActionResult> ShowApproved()
        {
            return View("Index", await _context.Volunteer.Where(j => j.approvalStatus.Contains("Y")).ToListAsync());
        }

        // /ShowDisapproved
        public async Task<IActionResult> ShowDisapproved()
        {
            return View("Index", await _context.Volunteer.Where(j => j.approvalStatus.Contains("N")).ToListAsync());
        }

        // /ShowApprovedPending
        public async Task<IActionResult> ShowApprovedPending()
        {
            _ = ShowApproved();
            return View("Index", await _context.Volunteer.Where(j => j.approvalStatus.Contains(p)).ToListAsync());
        }

        // /ShowPending
        public async Task<IActionResult> ShowPending()
        {
            return View("Index", await _context.Volunteer.Where(j => j.approvalStatus.Contains("P")).ToListAsync());
        }

        // GET: Volunteers/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var volunteer = await _context.Volunteer
                .FirstOrDefaultAsync(m => m.Id == id);
            if (volunteer == null)
            {
                return NotFound();
            }

            return View(volunteer);
        }

        // GET: Volunteers/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Volunteers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,firstName,lastName,userName,password,preferences,skills,availability,address,phoneNumber,email,education,licenses,emergName,emergPhone,emergEmail,emergAdd,approvalStatus")] Volunteer volunteer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(volunteer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(volunteer);
        }

        // GET: Volunteers/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var volunteer = await _context.Volunteer.FindAsync(id);
            if (volunteer == null)
            {
                return NotFound();
            }
            return View(volunteer);
        }

        // POST: Volunteers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,firstName,lastName,userName,password,preferences,skills,availability,address,phoneNumber,email,education,licenses,emergName,emergPhone,emergEmail,emergAdd,approvalStatus")] Volunteer volunteer)
        {
            if (id != volunteer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(volunteer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VolunteerExists(volunteer.Id))
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
            return View(volunteer);
        }

        // GET: Volunteers/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var volunteer = await _context.Volunteer
                .FirstOrDefaultAsync(m => m.Id == id);
            if (volunteer == null)
            {
                return NotFound();
            }

            return View(volunteer);
        }

        // POST: Volunteers/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var volunteer = await _context.Volunteer.FindAsync(id);
            _context.Volunteer.Remove(volunteer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VolunteerExists(int id)
        {
            return _context.Volunteer.Any(e => e.Id == id);
        }
    }
}
