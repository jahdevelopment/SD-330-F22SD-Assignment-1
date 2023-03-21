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
    public class PodcastsController : Controller
    {
        private readonly SpotifyContext _context;

        public PodcastsController(SpotifyContext context)
        {
            _context = context;
        }

        // GET: Podcasts
        public async Task<IActionResult> Index()
        {
            var spotifyContext = _context.Podcast.Include(p => p.ListenerslistPodcast);
            return View(await spotifyContext.ToListAsync());
        }

        // GET: Podcasts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Podcast == null)
            {
                return NotFound();
            }

            var podcast = await _context.Podcast
                .Include(p => p.ListenerslistPodcast)
                .FirstOrDefaultAsync(m => m.PodcastId == id);
            if (podcast == null)
            {
                return NotFound();
            }

            return View(podcast);
        }

        // GET: Podcasts/Create
        public IActionResult Create()
        {
            ViewData["ListenersListPodcastId"] = new SelectList(_context.ListenersListPodcast, "ListenersListPodcastId", "ListenersListPodcastId");
            return View();
        }

        // POST: Podcasts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PodcastId,Name,ListenersListPodcastId")] Podcast podcast)
        {
            if (ModelState.IsValid)
            {
                _context.Add(podcast);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ListenersListPodcastId"] = new SelectList(_context.ListenersListPodcast, "ListenersListPodcastId", "ListenersListPodcastId", podcast.ListenersListPodcastId);
            return View(podcast);
        }

        // GET: Podcasts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Podcast == null)
            {
                return NotFound();
            }

            var podcast = await _context.Podcast.FindAsync(id);
            if (podcast == null)
            {
                return NotFound();
            }
            ViewData["ListenersListPodcastId"] = new SelectList(_context.ListenersListPodcast, "ListenersListPodcastId", "ListenersListPodcastId", podcast.ListenersListPodcastId);
            return View(podcast);
        }

        // POST: Podcasts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PodcastId,Name,ListenersListPodcastId")] Podcast podcast)
        {
            if (id != podcast.PodcastId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(podcast);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PodcastExists(podcast.PodcastId))
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
            ViewData["ListenersListPodcastId"] = new SelectList(_context.ListenersListPodcast, "ListenersListPodcastId", "ListenersListPodcastId", podcast.ListenersListPodcastId);
            return View(podcast);
        }

        // GET: Podcasts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Podcast == null)
            {
                return NotFound();
            }

            var podcast = await _context.Podcast
                .Include(p => p.ListenerslistPodcast)
                .FirstOrDefaultAsync(m => m.PodcastId == id);
            if (podcast == null)
            {
                return NotFound();
            }

            return View(podcast);
        }

        // POST: Podcasts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Podcast == null)
            {
                return Problem("Entity set 'SpotifyContext.Podcast'  is null.");
            }
            var podcast = await _context.Podcast.FindAsync(id);
            if (podcast != null)
            {
                _context.Podcast.Remove(podcast);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PodcastExists(int id)
        {
          return (_context.Podcast?.Any(e => e.PodcastId == id)).GetValueOrDefault();
        }
    }
}
