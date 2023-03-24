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
    public class ListenersListPodcastsController : Controller
    {
        private readonly SpotifyContext _context;

        public ListenersListPodcastsController(SpotifyContext context)
        {
            _context = context;
        }

        // GET: ListenersListPodcasts
        public async Task<IActionResult> Index()
        {
            var spotifyContext = _context.ListenersListPodcast.Include(l => l.ListenersList);
            return View(await spotifyContext.ToListAsync());
        }

        // GET: ListenersListPodcasts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ListenersListPodcast == null)
            {
                return NotFound();
            }

            var listenersListPodcast = await _context.ListenersListPodcast
                .Include(l => l.ListenersList)
                .FirstOrDefaultAsync(m => m.ListenersListPodcastId == id);
            if (listenersListPodcast == null)
            {
                return NotFound();
            }

            return View(listenersListPodcast);
        }

        // GET: ListenersListPodcasts/Create
        public IActionResult Create()
        {
            ViewData["ListenersListId"] = new SelectList(_context.ListenersList, "ListenersListId", "Name");
            return View();
        }

        // POST: ListenersListPodcasts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ListenersListPodcastId,ListenersListId")] ListenersListPodcast listenersListPodcast)
        {
            if (ModelState.IsValid)
            {
                _context.Add(listenersListPodcast);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ListenersListId"] = new SelectList(_context.ListenersList, "ListenersListId", "Name", listenersListPodcast.ListenersListId);
            return View(listenersListPodcast);
        }

        // GET: ListenersListPodcasts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ListenersListPodcast == null)
            {
                return NotFound();
            }

            var listenersListPodcast = await _context.ListenersListPodcast.FindAsync(id);
            if (listenersListPodcast == null)
            {
                return NotFound();
            }
            ViewData["ListenersListId"] = new SelectList(_context.ListenersList, "ListenersListId", "Name", listenersListPodcast.ListenersListId);
            return View(listenersListPodcast);
        }

        // POST: ListenersListPodcasts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ListenersListPodcastId,ListenersListId")] ListenersListPodcast listenersListPodcast)
        {
            if (id != listenersListPodcast.ListenersListPodcastId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(listenersListPodcast);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ListenersListPodcastExists(listenersListPodcast.ListenersListPodcastId))
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
            ViewData["ListenersListId"] = new SelectList(_context.ListenersList, "ListenersListId", "Name", listenersListPodcast.ListenersListId);
            return View(listenersListPodcast);
        }

        // GET: ListenersListPodcasts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ListenersListPodcast == null)
            {
                return NotFound();
            }

            var listenersListPodcast = await _context.ListenersListPodcast
                .Include(l => l.ListenersList)
                .FirstOrDefaultAsync(m => m.ListenersListPodcastId == id);
            if (listenersListPodcast == null)
            {
                return NotFound();
            }

            return View(listenersListPodcast);
        }

        // POST: ListenersListPodcasts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ListenersListPodcast == null)
            {
                return Problem("Entity set 'SpotifyContext.ListenersListPodcast'  is null.");
            }
            var listenersListPodcast = await _context.ListenersListPodcast.FindAsync(id);
            if (listenersListPodcast != null)
            {
                _context.ListenersListPodcast.Remove(listenersListPodcast);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ListenersListPodcastExists(int id)
        {
          return (_context.ListenersListPodcast?.Any(e => e.ListenersListPodcastId == id)).GetValueOrDefault();
        }
    }
}
