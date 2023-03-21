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
    public class GuestArtistsController : Controller
    {
        private readonly SpotifyContext _context;

        public GuestArtistsController(SpotifyContext context)
        {
            _context = context;
        }

        // GET: GuestArtists
        public async Task<IActionResult> Index()
        {
            var spotifyContext = _context.GuestArtist.Include(g => g.Artist).Include(g => g.Episode);
            return View(await spotifyContext.ToListAsync());
        }

        // GET: GuestArtists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.GuestArtist == null)
            {
                return NotFound();
            }

            var guestArtist = await _context.GuestArtist
                .Include(g => g.Artist)
                .Include(g => g.Episode)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (guestArtist == null)
            {
                return NotFound();
            }

            return View(guestArtist);
        }

        // GET: GuestArtists/Create
        public IActionResult Create()
        {
            ViewData["Id"] = new SelectList(_context.Artist, "Id", "Name");
            ViewData["EpisodeId"] = new SelectList(_context.Episode, "EpisodeId", "Title");
            return View();
        }

        // POST: GuestArtists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ArtistId,EpisodeId")] GuestArtist guestArtist)
        {
            if (ModelState.IsValid)
            {
                _context.Add(guestArtist);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id"] = new SelectList(_context.Artist, "Id", "Name", guestArtist.Id);
            ViewData["EpisodeId"] = new SelectList(_context.Episode, "EpisodeId", "Title", guestArtist.EpisodeId);
            return View(guestArtist);
        }

        // GET: GuestArtists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.GuestArtist == null)
            {
                return NotFound();
            }

            var guestArtist = await _context.GuestArtist.FindAsync(id);
            if (guestArtist == null)
            {
                return NotFound();
            }
            ViewData["Id"] = new SelectList(_context.Artist, "Id", "Name", guestArtist.Id);
            ViewData["EpisodeId"] = new SelectList(_context.Episode, "EpisodeId", "Title", guestArtist.EpisodeId);
            return View(guestArtist);
        }

        // POST: GuestArtists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ArtistId,EpisodeId")] GuestArtist guestArtist)
        {
            if (id != guestArtist.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(guestArtist);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GuestArtistExists(guestArtist.Id))
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
            ViewData["Id"] = new SelectList(_context.Artist, "Id", "Name", guestArtist.Id);
            ViewData["EpisodeId"] = new SelectList(_context.Episode, "EpisodeId", "Title", guestArtist.EpisodeId);
            return View(guestArtist);
        }

        // GET: GuestArtists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.GuestArtist == null)
            {
                return NotFound();
            }

            var guestArtist = await _context.GuestArtist
                .Include(g => g.Artist)
                .Include(g => g.Episode)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (guestArtist == null)
            {
                return NotFound();
            }

            return View(guestArtist);
        }

        // POST: GuestArtists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.GuestArtist == null)
            {
                return Problem("Entity set 'SpotifyContext.GuestArtist'  is null.");
            }
            var guestArtist = await _context.GuestArtist.FindAsync(id);
            if (guestArtist != null)
            {
                _context.GuestArtist.Remove(guestArtist);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GuestArtistExists(int id)
        {
          return (_context.GuestArtist?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
