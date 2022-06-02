using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TRPO.Data;
using TRPO.Data.Models;

namespace WebApplication1.Controllers
{
    public class OperatingSystemsController : Controller
    {
        private readonly CadSytemsContext _context;

        public OperatingSystemsController(CadSytemsContext context)
        {
            _context = context;
        }

        // GET: OperatingSystems
        public async Task<IActionResult> Index()
        {
              return _context.OperatingSystems != null ? 
                          View(await _context.OperatingSystems.ToListAsync()) :
                          Problem("Entity set 'CadSytemsContext.OperatingSystems'  is null.");
        }

        // GET: OperatingSystems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.OperatingSystems == null)
            {
                return NotFound();
            }

            var operatingSystem = await _context.OperatingSystems
                .FirstOrDefaultAsync(m => m.Id == id);
            if (operatingSystem == null)
            {
                return NotFound();
            }

            return View(operatingSystem);
        }

        // GET: OperatingSystems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OperatingSystems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] TRPO.Data.Models.OperatingSystem operatingSystem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(operatingSystem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(operatingSystem);
        }

        // GET: OperatingSystems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.OperatingSystems == null)
            {
                return NotFound();
            }

            var operatingSystem = await _context.OperatingSystems.FindAsync(id);
            if (operatingSystem == null)
            {
                return NotFound();
            }
            return View(operatingSystem);
        }

        // POST: OperatingSystems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] TRPO.Data.Models.OperatingSystem operatingSystem)
        {
            if (id != operatingSystem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(operatingSystem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OperatingSystemExists(operatingSystem.Id))
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
            return View(operatingSystem);
        }

        // GET: OperatingSystems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.OperatingSystems == null)
            {
                return NotFound();
            }

            var operatingSystem = await _context.OperatingSystems
                .FirstOrDefaultAsync(m => m.Id == id);
            if (operatingSystem == null)
            {
                return NotFound();
            }

            return View(operatingSystem);
        }

        // POST: OperatingSystems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.OperatingSystems == null)
            {
                return Problem("Entity set 'CadSytemsContext.OperatingSystems'  is null.");
            }
            var operatingSystem = await _context.OperatingSystems.FindAsync(id);
            if (operatingSystem != null)
            {
                _context.OperatingSystems.Remove(operatingSystem);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OperatingSystemExists(int id)
        {
          return (_context.OperatingSystems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
