using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NetCuisine.DataBase;
using NetCuisine.Models;

namespace NetCuisine.Controllers
{
    public class TestSignUpController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TestSignUpController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TestSignUp
        public async Task<IActionResult> Index()
        {
            return View(await _context.signUp.ToListAsync());
        }

        // GET: TestSignUp/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var signUpModel = await _context.signUp
                .FirstOrDefaultAsync(m => m.Id == id);
            if (signUpModel == null)
            {
                return NotFound();
            }

            return View(signUpModel);
        }

        // GET: TestSignUp/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TestSignUp/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FullName,Email,Phone,Password")] SignUpModel signUpModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(signUpModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(signUpModel);
        }

        // GET: TestSignUp/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var signUpModel = await _context.signUp.FindAsync(id);
            if (signUpModel == null)
            {
                return NotFound();
            }
            return View(signUpModel);
        }

        // POST: TestSignUp/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,Email,Phone,Password")] SignUpModel signUpModel)
        {
            if (id != signUpModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(signUpModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SignUpModelExists(signUpModel.Id))
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
            return View(signUpModel);
        }

        // GET: TestSignUp/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var signUpModel = await _context.signUp
                .FirstOrDefaultAsync(m => m.Id == id);
            if (signUpModel == null)
            {
                return NotFound();
            }

            return View(signUpModel);
        }

        // POST: TestSignUp/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var signUpModel = await _context.signUp.FindAsync(id);
            _context.signUp.Remove(signUpModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SignUpModelExists(int id)
        {
            return _context.signUp.Any(e => e.Id == id);
        }
    }
}
