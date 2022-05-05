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
using Microsoft.AspNet.Identity; // NuGet: Microsoft ASP.NET Identity Core.
using System.Security.Principal;

namespace MIS421FinalProjectGit.Views
{
    public class BillsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BillsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Bills
        public async Task<IActionResult> Index()
        {
            var data = _context.MyBill.AsQueryable();
            data = data.Where(x => x.ApplicationUserID == Guid.Parse(User.Identity.GetUserId()));
            return View(data);
        }

        // GET: Bills/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bill = await _context.MyBill
                .FirstOrDefaultAsync(m => m.BillID == id);
            if (bill == null)
            {
                return NotFound();
            }

            return View(bill);
        }

        // GET: Bills/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bills/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BillID,BillType,DueDate,Amount,DayPaid,Description,UserAccountID")] MyBill bill)
        {
            if (ModelState.IsValid)
            {
                bill.ApplicationUserID= Guid.Parse(User.Identity.GetUserId());
                bill.BillID = Guid.NewGuid();
                _context.Add(bill);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bill);
        }

        // GET: Bills/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bill = await _context.MyBill.FindAsync(id);
            if (bill == null)
            {
                return NotFound();
            }
            return View(bill);
        }

        // POST: Bills/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("BillID,BillType,DueDate,Amount,DayPaid,Description,UserAccountID")] MyBill bill)
        {
            if (id != bill.BillID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    bill.ApplicationUserID = Guid.Parse(User.Identity.GetUserId());
                    _context.Update(bill);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BillExists(bill.BillID))
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
            return View(bill);
        }

        // GET: Bills/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bill = await _context.MyBill
                .FirstOrDefaultAsync(m => m.BillID == id);
            if (bill == null)
            {
                return NotFound();
            }

            return View(bill);
        }

        // POST: Bills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var bill = await _context.MyBill.FindAsync(id);
            _context.MyBill.Remove(bill);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BillExists(Guid id)
        {
            return _context.MyBill.Any(e => e.BillID == id);
        }
    }
}
