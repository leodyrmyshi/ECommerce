using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using dyrmyshi.leo._5h.ECommerce.Models;

namespace dyrmyshi.leo._5h.ECommerce.Controllers
{
    public class PiadeController : Controller
    {
        private readonly dbContext _context;

        public PiadeController(dbContext context)
        {
            _context = context;
        }

        // GET: Piade
        public async Task<IActionResult> Index()
        {
            return View(await _context.Piade.ToListAsync());
        }

        // GET: Piade/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var piade = await _context.Piade
                .FirstOrDefaultAsync(m => m.Id == id);
            if (piade == null)
            {
                return NotFound();
            }

            return View(piade);
        }

        // GET: Piade/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Piade/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Genre,Price")] Piade piade)
        {
            if (ModelState.IsValid)
            {
                _context.Add(piade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(piade);
        }

        // GET: Piade/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var piade = await _context.Piade.FindAsync(id);
            if (piade == null)
            {
                return NotFound();
            }
            return View(piade);
        }

        // POST: Piade/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Genre,Price")] Piade piade)
        {
            if (id != piade.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(piade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PiadeExists(piade.Id))
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
            return View(piade);
        }

        // GET: Piade/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var piade = await _context.Piade
                .FirstOrDefaultAsync(m => m.Id == id);
            if (piade == null)
            {
                return NotFound();
            }

            return View(piade);
        }

        // POST: Piade/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var piade = await _context.Piade.FindAsync(id);
            if (piade != null)
            {
                _context.Piade.Remove(piade);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PiadeExists(int id)
        {
            return _context.Piade.Any(e => e.Id == id);
        }
    }
}
