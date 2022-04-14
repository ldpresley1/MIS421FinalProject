#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MIS421FinalProjectGit.Data;
using MIS421FinalProjectGit.Models;

namespace MIS421FinalProjectGit.Views
{
    public class InvestmentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InvestmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Investments
        public async Task<IActionResult> Index()
        {
            return View(await _context.Investments.ToListAsync());
        }

        // GET: Investments/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var investments = await _context.Investments
                .FirstOrDefaultAsync(m => m.BillID == id);
            if (investments == null)
            {
                return NotFound();
            }

            return View(investments);
        }

        // GET: Investments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Investments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BillID,InvestmentType,Description,RiskLevel,UserAccountID,InvestmentImage")] Investments investments, IFormFile InvestmentImage)
        {
            if (ModelState.IsValid)
            {

                if (InvestmentImage != null && InvestmentImage.Length > 0)
                {
                    var memoryStream = new MemoryStream();
                    await InvestmentImage.CopyToAsync(memoryStream);
                    investments.InvestmentImage = memoryStream.ToArray();
                }
                _context.Add(investments);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(investments);

        }

        // GET: Investments/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var investments = await _context.Investments.FindAsync(id);
            if (investments == null)
            {
                return NotFound();
            }
            return View(investments);
        }

        // POST: Investments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("BillID,InvestmentType,Description,RiskLevel,UserAccountID,InvestmentImage")] Investments investments)
        {
            if (id != investments.BillID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(investments);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvestmentsExists(investments.BillID))
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
            return View(investments);
        }

        // GET: Investments/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var investments = await _context.Investments
                .FirstOrDefaultAsync(m => m.BillID == id);
            if (investments == null)
            {
                return NotFound();
            }

            return View(investments);
        }

        // POST: Investments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var investments = await _context.Investments.FindAsync(id);
            _context.Investments.Remove(investments);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvestmentsExists(Guid id)
        {
            return _context.Investments.Any(e => e.BillID == id);
        }
    }
}
