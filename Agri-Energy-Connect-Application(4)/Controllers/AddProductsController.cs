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
/// Product Controller
/// </summary>
    [Authorize]
    public class AddProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AddProductsController(ApplicationDbContext context)
        {
            _context = context;
        }
        [Authorize(Roles = "Employee")]
        // GET: Products/Filter
        public async Task<IActionResult> Filter(string farmerName, string productType, DateTime? productionDate)
        {
            var query = _context.AddProduct.AsQueryable();

            if (!string.IsNullOrEmpty(farmerName))
            {
                query = query.Where(p => (p.Farmer.FirstName + " " + p.Farmer.LastName).Contains(farmerName));
            }

            if (!string.IsNullOrEmpty(productType))
            {
                query = query.Where(p => p.Category.Contains(productType));
            }

            if (productionDate.HasValue)
            {
                query = query.Where(p => p.ProductionDate.Date == productionDate.Value.Date);
            }

            var results = await query.Include(p => p.Farmer).ToListAsync();
            return View("Index", results);
        }

        // GET: AddProducts
        public async Task<IActionResult> Index()
        {
            return View(await _context.AddProduct.ToListAsync());
        }

        // GET: AddProducts/ShowProductSearch
        public async Task<IActionResult> ShowProductSearch()
        {
            return View();
        }

        // GET: AddProducts/ShowtSearchResults
        public async Task<IActionResult> ShowSearchResults(string SearchCode)
        {
            return _context.AddProduct != null ?
                View("Index", await _context.AddProduct.Where(j => j.ProductName.Contains(SearchCode)).ToListAsync()) :
                          Problem("Entity set 'ApplicationDbConext.AddProduct'  is null.");
        }

        // GET: AddProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addProduct = await _context.AddProduct
                .FirstOrDefaultAsync(m => m.Id == id);
            if (addProduct == null)
            {
                return NotFound();
            }

            return View(addProduct);
        }

        // GET: AddProducts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AddProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FarmerId,ProductName,Category,ProductionDate")] AddProduct addProduct)
        {
            if (ModelState.IsValid)
            {
                _context.Add(addProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(addProduct);
        }

        // GET: AddProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addProduct = await _context.AddProduct.FindAsync(id);
            if (addProduct == null)
            {
                return NotFound();
            }
            return View(addProduct);
        }

        // POST: AddProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FarmerId,ProductName,Category,ProductionDate")] AddProduct addProduct)
        {
            if (id != addProduct.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(addProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AddProductExists(addProduct.Id))
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
            return View(addProduct);
        }

        // GET: AddProducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addProduct = await _context.AddProduct
                .FirstOrDefaultAsync(m => m.Id == id);
            if (addProduct == null)
            {
                return NotFound();
            }

            return View(addProduct);
        }

        // POST: AddProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var addProduct = await _context.AddProduct.FindAsync(id);
            if (addProduct != null)
            {
                _context.AddProduct.Remove(addProduct);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AddProductExists(int id)
        {
            return _context.AddProduct.Any(e => e.Id == id);
        }
    }
}
