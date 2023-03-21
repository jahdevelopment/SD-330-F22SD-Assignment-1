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
    public class PodcastArtistsController : Controller
    {
        private readonly SpotifyContext _context;

        public PodcastArtistsController(SpotifyContext context)
        {
            _context = context;
        }

        // GET: PodcastArtists
        public async Task<IActionResult> Index()
        {
            var spotifyContext = _context.PodcastArtist.Include(p => p.Artist).Include(p => p.Podcast);
            return View(await spotifyContext.ToListAsync());
        }

        // GET: PodcastArtists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PodcastArtist == null)
            {
                return NotFound();
            }

            var podcastArtist = await _context.PodcastArtist
                .Include(p => p.Artist)
                .Include(p => p.Podcast)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (podcastArtist == null)
            {
                return NotFound();
            }

            return View(podcastArtist);
        }

        // GET: PodcastArtists/Create
        public IActionResult Create()
        {
            ViewData["Id"] = new SelectList(_context.Artist, "Id", "Name");
            ViewData["PodcastId"] = new SelectList(_context.Podcast, "PodcastId", "Name");
            return View();
        }

        // POST: PodcastArtists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PodcastId,ArtistId")] PodcastArtist podcastArtist)
        {
            if (ModelState.IsValid)
            {
                _context.Add(podcastArtist);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id"] = new SelectList(_context.Artist, "Id", "Name", podcastArtist.Id);
            ViewData["PodcastId"] = new SelectList(_context.Podcast, "PodcastId", "Name", podcastArtist.PodcastId);
            return View(podcastArtist);
        }

        // GET: PodcastArtists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PodcastArtist == null)
            {
                return NotFound();
            }

            var podcastArtist = await _context.PodcastArtist.FindAsync(id);
            if (podcastArtist == null)
            {
                return NotFound();
            }
            ViewData["Id"] = new SelectList(_context.Artist, "Id", "Name", podcastArtist.Id);
            ViewData["PodcastId"] = new SelectList(_context.Podcast, "PodcastId", "Name", podcastArtist.PodcastId);
            return View(podcastArtist);
        }

        // POST: PodcastArtists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PodcastId,ArtistId")] PodcastArtist podcastArtist)
        {
            if (id != podcastArtist.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(podcastArtist);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PodcastArtistExists(podcastArtist.Id))
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
            ViewData["Id"] = new SelectList(_context.Artist, "Id", "Name", podcastArtist.Id);
            ViewData["PodcastId"] = new SelectList(_context.Podcast, "PodcastId", "Name", podcastArtist.PodcastId);
            return View(podcastArtist);
        }

        // GET: PodcastArtists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PodcastArtist == null)
            {
                return NotFound();
            }

            var podcastArtist = await _context.PodcastArtist
                .Include(p => p.Artist)
                .Include(p => p.Podcast)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (podcastArtist == null)
            {
                return NotFound();
            }

            return View(podcastArtist);
        }

        // POST: PodcastArtists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PodcastArtist == null)
            {
                return Problem("Entity set 'SpotifyContext.PodcastArtist'  is null.");
            }
            var podcastArtist = await _context.PodcastArtist.FindAsync(id);
            if (podcastArtist != null)
            {
                _context.PodcastArtist.Remove(podcastArtist);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PodcastArtistExists(int id)
        {
          return (_context.PodcastArtist?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
