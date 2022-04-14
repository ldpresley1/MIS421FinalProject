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
    public class AdminAccountsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminAccountsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AdminAccounts
        public async Task<IActionResult> Index()
        {
            return View(await _context.AdminAccount.ToListAsync());
        }

        // GET: AdminAccounts/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adminAccount = await _context.AdminAccount
                .FirstOrDefaultAsync(m => m.ID == id);
            if (adminAccount == null)
            {
                return NotFound();
            }

            return View(adminAccount);
        }

        // GET: AdminAccounts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminAccounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FName,LName,Address,Email,UserAccountType,LastLogin")] AdminAccount adminAccount)
        {
            if (ModelState.IsValid)
            {
                adminAccount.ID = Guid.NewGuid();
                _context.Add(adminAccount);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(adminAccount);
        }

        // GET: AdminAccounts/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adminAccount = await _context.AdminAccount.FindAsync(id);
            if (adminAccount == null)
            {
                return NotFound();
            }
            return View(adminAccount);
        }

        // POST: AdminAccounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID,FName,LName,Address,Email,UserAccountType,LastLogin")] AdminAccount adminAccount)
        {
            if (id != adminAccount.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(adminAccount);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdminAccountExists(adminAccount.ID))
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
            return View(adminAccount);
        }

        // GET: AdminAccounts/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adminAccount = await _context.AdminAccount
                .FirstOrDefaultAsync(m => m.ID == id);
            if (adminAccount == null)
            {
                return NotFound();
            }

            return View(adminAccount);
        }

        // POST: AdminAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var adminAccount = await _context.AdminAccount.FindAsync(id);
            _context.AdminAccount.Remove(adminAccount);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdminAccountExists(Guid id)
        {
            return _context.AdminAccount.Any(e => e.ID == id);
        }
    }
}
