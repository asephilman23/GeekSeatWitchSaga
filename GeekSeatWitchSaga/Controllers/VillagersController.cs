using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GeekSeatWitchSaga.Data;
using GeekSeatWitchSaga.Models;
using GeekSeatWitchSaga.Data.Services;


namespace GeekSeatWitchSaga.Controllers
{
    public class VillagersController : Controller
    {
        private readonly GeekSeatWitchSagaContext _context;

        public VillagersController(GeekSeatWitchSagaContext context)
        {
            _context = context;
        }

        // GET: Villagers
        public async Task<IActionResult> Index()
        { 
            if (_context.Villager != null)
            {
                int iSumData = _context.Villager.Select(a => a.NumberKilled).Sum();
                int iCountData = _context.Villager.Count();

                WitchSagaService witchSagaService = new WitchSagaService();
                ViewBag.Message = witchSagaService.AverageData(iSumData, iCountData).ToString("#.##");
            }

            return _context.Villager != null ?
                          View(await _context.Villager.ToListAsync()) :
                          Problem("Entity set 'GeekSeatWitchSagaContext.Villager'  is null.");
        }

        // GET: Villagers/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Villager == null)
            {
                return NotFound();
            }

            var villager = await _context.Villager
                .FirstOrDefaultAsync(m => m.Id == id);
            if (villager == null)
            {
                return NotFound();
            }

            return View(villager);
        }

        // GET: Villagers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Villagers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,AgeOfDeath,YearOfDeath")] Villager villager)
        {
            if (ModelState.IsValid)
            {
                if (villager.AgeOfDeath >= villager.YearOfDeath)
                {
                    ViewBag.Message = string.Format("Error: YearOfDeath must bigger than AgeOfDeath !");
                    return View(villager);
                }
                else 
                {
                    villager.Id = Guid.NewGuid();
                    villager.YearKilled = villager.YearOfDeath - villager.AgeOfDeath;

                    WitchSagaService witchSagaService = new WitchSagaService();
                    villager.NumberKilled = witchSagaService.GenerateNumberOfKilled(villager.YearKilled);

                    _context.Add(villager);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(villager);
        }

        // GET: Villagers/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Villager == null)
            {
                return NotFound();
            }

            var villager = await _context.Villager.FindAsync(id);
            if (villager == null)
            {
                return NotFound();
            }
            return View(villager);
        }

        // POST: Villagers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,AgeOfDeath,YearOfDeath")] Villager villager)
        {
            if (id != villager.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (villager.AgeOfDeath >= villager.YearOfDeath)
                {
                    ViewBag.Message = string.Format("Error: YearOfDeath must bigger than AgeOfDeath !");
                    return View(villager);
                }
                else 
                {
                    try
                    {
                        
                        villager.YearKilled = villager.YearOfDeath - villager.AgeOfDeath;
                        
                        WitchSagaService witchSagaService = new WitchSagaService();
                        villager.NumberKilled = witchSagaService.GenerateNumberOfKilled(villager.YearKilled);

                        _context.Update(villager);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!VillagerExists(villager.Id))
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
            }
            return View(villager);
        }

        // GET: Villagers/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Villager == null)
            {
                return NotFound();
            }

            var villager = await _context.Villager
                .FirstOrDefaultAsync(m => m.Id == id);
            if (villager == null)
            {
                return NotFound();
            }

            return View(villager);
        }

        // POST: Villagers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Villager == null)
            {
                return Problem("Entity set 'GeekSeatWitchSagaContext.Villager'  is null.");
            }
            var villager = await _context.Villager.FindAsync(id);
            if (villager != null)
            {
                _context.Villager.Remove(villager);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VillagerExists(Guid id)
        {
          return (_context.Villager?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        
    }
}
