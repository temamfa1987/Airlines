using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Airlines.Data;
using Airlines.Models;

namespace Web_airlines_db.Controllers
{
    public class ДолжностиController : Controller
    {
        private readonly airlinesDBContext _context;

        public ДолжностиController(airlinesDBContext context)
        {
            _context = context;
        }

        // GET: Должности
        public async Task<IActionResult> Index()
        {
            var airlinesDBContext = _context.Должности.Include(д => д.КодЭкипажаNavigation);
            return View(await airlinesDBContext.ToListAsync());
        }

        // GET: Должности/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var должности = await _context.Должности
                .Include(д => д.КодЭкипажаNavigation)
                .FirstOrDefaultAsync(m => m.КодДолжности == id);
            if (должности == null)
            {
                return NotFound();
            }

            return View(должности);
        }

        // GET: Должности/Create
        public IActionResult Create()
        {
            ViewData["КодЭкипажа"] = new SelectList(_context.Экипажи, "КодЭкипажа", "КодЭкипажа");
            return View();
        }

        // POST: Должности/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("КодДолжности,НаименованиеДолжности,Оклад,Обязанности,Требования,КодЭкипажа")] Должности должности)
        {
            if (ModelState.IsValid)
            {
                _context.Add(должности);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["КодЭкипажа"] = new SelectList(_context.Экипажи, "КодЭкипажа", "КодЭкипажа", должности.КодЭкипажа);
            return View(должности);
        }

        // GET: Должности/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var должности = await _context.Должности.FindAsync(id);
            if (должности == null)
            {
                return NotFound();
            }
            ViewData["КодЭкипажа"] = new SelectList(_context.Экипажи, "КодЭкипажа", "КодЭкипажа", должности.КодЭкипажа);
            return View(должности);
        }

        // POST: Должности/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("КодДолжности,НаименованиеДолжности,Оклад,Обязанности,Требования,КодЭкипажа")] Должности должности)
        {
            if (id != должности.КодДолжности)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(должности);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ДолжностиExists(должности.КодДолжности))
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
            ViewData["КодЭкипажа"] = new SelectList(_context.Экипажи, "КодЭкипажа", "КодЭкипажа", должности.КодЭкипажа);
            return View(должности);
        }

        // GET: Должности/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var должности = await _context.Должности
                .Include(д => д.КодЭкипажаNavigation)
                .FirstOrDefaultAsync(m => m.КодДолжности == id);
            if (должности == null)
            {
                return NotFound();
            }

            return View(должности);
        }

        // POST: Должности/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var должности = await _context.Должности.FindAsync(id);
            _context.Должности.Remove(должности);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ДолжностиExists(long id)
        {
            return _context.Должности.Any(e => e.КодДолжности == id);
        }
    }
}
