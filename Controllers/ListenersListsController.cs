using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SD_330_F22SD_Assignment_1.Data;
using SD_330_F22SD_Assignment_1.Models;

namespace SD_330_F22SD_Assignment_1.Controllers
{
    public class ListenersListsController : Controller
    {
        private readonly SpotifyContext _context;

        public ListenersListsController(SpotifyContext context)
        {
            _context = context;
        }

        // GET: ListenersLists
        public async Task<IActionResult> Index()
        {
              return _context.ListenersList != null ? 
                          View(await _context.ListenersList.ToListAsync()) :
                          Problem("Entity set 'SpotifyContext.ListenersList'  is null.");
        }

        // GET: ListenersLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ListenersList == null)
            {
                return NotFound();
            }

            var listenersList = await _context.ListenersList
                .FirstOrDefaultAsync(m => m.ListenersListId == id);
            if (listenersList == null)
            {
                return NotFound();
            }

            return View(listenersList);
        }

        // GET: ListenersLists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ListenersLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ListenersListId,Name")] ListenersList listenersList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(listenersList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(listenersList);
        }

        // GET: ListenersLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ListenersList == null)
            {
                return NotFound();
            }

            var listenersList = await _context.ListenersList.FindAsync(id);
            if (listenersList == null)
            {
                return NotFound();
            }
            return View(listenersList);
        }

        // POST: ListenersLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ListenersListId,Name")] ListenersList listenersList)
        {
            if (id != listenersList.ListenersListId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(listenersList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ListenersListExists(listenersList.ListenersListId))
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
            return View(listenersList);
        }

        // GET: ListenersLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ListenersList == null)
            {
                return NotFound();
            }

            var listenersList = await _context.ListenersList
                .FirstOrDefaultAsync(m => m.ListenersListId == id);
            if (listenersList == null)
            {
                return NotFound();
            }

            return View(listenersList);
        }

        // POST: ListenersLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ListenersList == null)
            {
                return Problem("Entity set 'SpotifyContext.ListenersList'  is null.");
            }
            var listenersList = await _context.ListenersList.FindAsync(id);
            if (listenersList != null)
            {
                _context.ListenersList.Remove(listenersList);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ListenersListExists(int id)
        {
          return (_context.ListenersList?.Any(e => e.ListenersListId == id)).GetValueOrDefault();
        }
    }
}
