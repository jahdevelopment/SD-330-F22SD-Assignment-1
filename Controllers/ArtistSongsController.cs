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
    public class ArtistSongsController : Controller
    {
        private readonly SpotifyContext _context;

        public ArtistSongsController(SpotifyContext context)
        {
            _context = context;
        }

        // GET: ArtistSongs
        public async Task<IActionResult> Index()
        {
            var spotifyContext = _context.ArtistSong.Include(a => a.Artist).Include(a => a.Song);
            return View(await spotifyContext.ToListAsync());
        }

        // GET: ArtistSongs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ArtistSong == null)
            {
                return NotFound();
            }

            var artistSong = await _context.ArtistSong
                .Include(a => a.Artist)
                .Include(a => a.Song)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (artistSong == null)
            {
                return NotFound();
            }

            return View(artistSong);
        }

        // GET: ArtistSongs/Create
        public IActionResult Create()
        {
            ViewData["ArtistId"] = new SelectList(_context.Artist, "Id", "Id");
            ViewData["SongId"] = new SelectList(_context.Song, "Id", "Id");
            return View();
        }

        // POST: ArtistSongs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ArtistId,SongId")] ArtistSong artistSong)
        {
            if (ModelState.IsValid)
            {
                _context.Add(artistSong);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArtistId"] = new SelectList(_context.Artist, "Id", "Id", artistSong.ArtistId);
            ViewData["SongId"] = new SelectList(_context.Song, "Id", "Id", artistSong.SongId);
            return View(artistSong);
        }

        // GET: ArtistSongs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ArtistSong == null)
            {
                return NotFound();
            }

            var artistSong = await _context.ArtistSong.FindAsync(id);
            if (artistSong == null)
            {
                return NotFound();
            }
            ViewData["ArtistId"] = new SelectList(_context.Artist, "Id", "Id", artistSong.ArtistId);
            ViewData["SongId"] = new SelectList(_context.Song, "Id", "Id", artistSong.SongId);
            return View(artistSong);
        }

        // POST: ArtistSongs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ArtistId,SongId")] ArtistSong artistSong)
        {
            if (id != artistSong.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(artistSong);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArtistSongExists(artistSong.Id))
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
            ViewData["ArtistId"] = new SelectList(_context.Artist, "Id", "Id", artistSong.ArtistId);
            ViewData["SongId"] = new SelectList(_context.Song, "Id", "Id", artistSong.SongId);
            return View(artistSong);
        }

        // GET: ArtistSongs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ArtistSong == null)
            {
                return NotFound();
            }

            var artistSong = await _context.ArtistSong
                .Include(a => a.Artist)
                .Include(a => a.Song)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (artistSong == null)
            {
                return NotFound();
            }

            return View(artistSong);
        }

        // POST: ArtistSongs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ArtistSong == null)
            {
                return Problem("Entity set 'SpotifyContext.ArtistSong'  is null.");
            }
            var artistSong = await _context.ArtistSong.FindAsync(id);
            if (artistSong != null)
            {
                _context.ArtistSong.Remove(artistSong);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArtistSongExists(int id)
        {
          return _context.ArtistSong.Any(e => e.Id == id);
        }
    }
}
