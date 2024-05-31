using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Agri_Energy_Connect_Application_4_.Data;
using Agri_Energy_Connect_Application_4_.Models;
using Microsoft.AspNetCore.Authorization;

namespace Agri_Energy_Connect_Application_4_.Controllers
{/// <summary>
/// Farmer Controller
/// </summary>
    [Authorize(Roles = "Employee")]
    public class AddFarmersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AddFarmersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AddFarmers
        public async Task<IActionResult> Index()
        {
            return View(await _context.AddFarmer.ToListAsync());
        }

        // GET: AddFarmers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addFarmer = await _context.AddFarmer
                .FirstOrDefaultAsync(m => m.Id == id);
            if (addFarmer == null)
            {
                return NotFound();
            }

            return View(addFarmer);
        }

        // GET: AddFarmers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AddFarmers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Email,PasswordHash")] AddFarmer addFarmer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(addFarmer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(addFarmer);
        }

        // GET: AddFarmers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addFarmer = await _context.AddFarmer.FindAsync(id);
            if (addFarmer == null)
            {
                return NotFound();
            }
            return View(addFarmer);
        }

        // POST: AddFarmers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Email,PasswordHash")] AddFarmer addFarmer)
        {
            if (id != addFarmer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(addFarmer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AddFarmerExists(addFarmer.Id))
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
            return View(addFarmer);
        }

        // GET: AddFarmers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addFarmer = await _context.AddFarmer
                .FirstOrDefaultAsync(m => m.Id == id);
            if (addFarmer == null)
            {
                return NotFound();
            }

            return View(addFarmer);
        }

        // POST: AddFarmers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var addFarmer = await _context.AddFarmer.FindAsync(id);
            if (addFarmer != null)
            {
                _context.AddFarmer.Remove(addFarmer);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AddFarmerExists(int id)
        {
            return _context.AddFarmer.Any(e => e.Id == id);
        }
    }
}
