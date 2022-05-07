#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MIS421FinalProjectGit.Data;
using MIS421FinalProjectGit.Models;

namespace MIS421FinalProjectGit.Views
{
    public class BudgetViewModelController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BudgetViewModelController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BudgetViewModels
        public ActionResult Index()
        {
            var data = _context.BudgetViewModel.AsQueryable();
            data = data.Where(x => x.ApplicationUserID == Guid.Parse(User.Identity.GetUserId()));
            foreach(BudgetViewModel budget in data)
            {
                getCurrentBalance(budget);
            }
            return View(data);
        }

        // GET: BudgetViewModels/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var budgetViewModel = await _context.BudgetViewModel
                .FirstOrDefaultAsync(m => m.BudgetID == id);
            if (budgetViewModel == null)
            {
                return NotFound();
            }

            return View(budgetViewModel);
        }

        // GET: BudgetViewModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BudgetViewModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BudgetID,Balance,LeftoverEarnings,initialBalance,ApplicationUserID")] BudgetViewModel budgetViewModel)
        {
            if (ModelState.IsValid)
            {
                budgetViewModel.ApplicationUserID = Guid.Parse(User.Identity.GetUserId());
                budgetViewModel.BudgetID = Guid.NewGuid();
                budgetViewModel.Balance = 0;
                _context.Add(budgetViewModel);
                await _context.SaveChangesAsync();
                getCurrentBalance(budgetViewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(budgetViewModel);
        }

        // GET: BudgetViewModels/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var budgetViewModel = await _context.BudgetViewModel.FindAsync(id);
            if (budgetViewModel == null)
            {
                return NotFound();
            }
            return View(budgetViewModel);
        }

        // POST: BudgetViewModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("BudgetID,Balance,LeftoverEarnings,initialBalance,ApplicationUserID")] BudgetViewModel budgetViewModel)
        {
            if (id != budgetViewModel.BudgetID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    budgetViewModel.ApplicationUserID = Guid.Parse(User.Identity.GetUserId());
                    _context.Update(budgetViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BudgetViewModelExists(budgetViewModel.BudgetID))
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
            return View(budgetViewModel);
        }

        // GET: BudgetViewModels/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var budgetViewModel = await _context.BudgetViewModel
                .FirstOrDefaultAsync(m => m.BudgetID == id);
            if (budgetViewModel == null)
            {
                return NotFound();
            }

            return View(budgetViewModel);
        }

        // POST: BudgetViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var budgetViewModel = await _context.BudgetViewModel.FindAsync(id);
            _context.BudgetViewModel.Remove(budgetViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public ActionResult getCurrentBalance([Bind("BudgetID,Balance,LeftoverEarnings,initialBalance,ApplicationUserID")] BudgetViewModel budgetViewModel)
        {
            var data = _context.MyTransaction.AsQueryable();
            data = data.Where(x => x.ApplicationUserID == Guid.Parse(User.Identity.GetUserId()));
            budgetViewModel.Balance = 0;
            foreach(MyTransaction item in data)
            {
                if(item.TransType == "Credit")
                {
                    budgetViewModel.Balance -= item.Amount;
                }
                else if(item.TransType == "Debit")
                {
                    budgetViewModel.Balance += item.Amount;
                }
            }
            var billdata = _context.MyBill.AsQueryable();
            billdata = billdata.Where(x => x.ApplicationUserID == Guid.Parse(User.Identity.GetUserId()));
            foreach (MyBill bill in billdata)
            {
                budgetViewModel.Balance -= bill.Amount;
            }
            budgetViewModel.Balance += budgetViewModel.initialBalance;
            _context.Update(budgetViewModel);
             _context.SaveChangesAsync();
            return View(budgetViewModel);
        }
        private bool BudgetViewModelExists(Guid id)
        {
            return _context.BudgetViewModel.Any(e => e.BudgetID == id);
        }
    }
}
