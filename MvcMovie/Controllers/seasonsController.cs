using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    public class seasonsController : Controller
    {
        private readonly MvcMovieContext _context;

        public seasonsController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: seasons
        public async Task<IActionResult> Index()
        {
            return _context.season != null ?
                        View(await _context.season.ToListAsync()) :
                        Problem("Entity set 'MvcMovieContext.season'  is null.");
        }

        // GET: seasons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.season == null)
            {
                return NotFound();
            }

            var season = await _context.season
                .FirstOrDefaultAsync(m => m.Id == id);
            if (season == null)
            {
                return NotFound();
            }

            return View(season);
        }

        // GET: seasons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: seasons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description")] season season)
        {
            if (ModelState.IsValid)
            {
                _context.Add(season);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(season);
        }

        // GET: seasons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.season == null)
            {
                return NotFound();
            }

            var season = await _context.season.FindAsync(id);
            if (season == null)
            {
                return NotFound();
            }
            return View(season);
        }

        // POST: seasons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description")] season season)
        {
            if (id != season.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(season);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!seasonExists(season.Id))
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
            return View(season);
        }

        // GET: seasons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.season == null)
            {
                return NotFound();
            }

            var season = await _context.season
                .FirstOrDefaultAsync(m => m.Id == id);
            if (season == null)
            {
                return NotFound();
            }

            return View(season);
        }

        // POST: seasons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.season == null)
            {
                return Problem("Entity set 'MvcMovieContext.season'  is null.");
            }
            var season = await _context.season.FindAsync(id);
            if (season != null)
            {
                _context.season.Remove(season);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool seasonExists(int id)
        {
            return (_context.season?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
