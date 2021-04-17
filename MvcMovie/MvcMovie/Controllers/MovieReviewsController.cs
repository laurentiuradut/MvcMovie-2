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
    public class MovieReviewsController : Controller
    {
        private readonly MvcMovieContext _context;

        public MovieReviewsController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: MovieReviews
        public async Task<IActionResult> Index()
        {
            return View(await _context.Review.ToListAsync());
        }

        // GET: MovieReviews/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieReview = await _context.Review
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movieReview == null)
            {
                return NotFound();
            }

            return View(movieReview);
        }

        // GET: MovieReviews/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MovieReviews/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Review,ReviewDate")] MovieReview movieReview)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movieReview);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movieReview);
        }

        // GET: MovieReviews/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieReview = await _context.Review.FindAsync(id);
            if (movieReview == null)
            {
                return NotFound();
            }
            return View(movieReview);
        }

        // POST: MovieReviews/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Review,ReviewDate")] MovieReview movieReview)
        {
            if (id != movieReview.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movieReview);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieReviewExists(movieReview.Id))
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
            return View(movieReview);
        }

        // GET: MovieReviews/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieReview = await _context.Review
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movieReview == null)
            {
                return NotFound();
            }

            return View(movieReview);
        }

        // POST: MovieReviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movieReview = await _context.Review.FindAsync(id);
            _context.Review.Remove(movieReview);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieReviewExists(int id)
        {
            return _context.Review.Any(e => e.Id == id);
        }
    }
}
