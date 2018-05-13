using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CloudBanking.Models;

namespace CloudBanking.Controllers
{
    public class BankAccountsController : Controller
    {
        private CloudBankingEntities db = new CloudBankingEntities();

        // GET: BankAccounts
        public async Task<ActionResult> Index()
        {
            var bankAccounts = db.BankAccounts.Include(b => b.BankAccount1).Include(b => b.BankAccount2).Include(b => b.Branch);
            return View(await bankAccounts.ToListAsync());
        }

        // GET: BankAccounts/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BankAccount bankAccount = await db.BankAccounts.FindAsync(id);
            if (bankAccount == null)
            {
                return HttpNotFound();
            }
            return View(bankAccount);
        }

        // GET: BankAccounts/Create
        public ActionResult Create()
        {
            ViewBag.AccountID = new SelectList(db.BankAccounts, "AccountID", "AccountCurrency");
            ViewBag.AccountID = new SelectList(db.BankAccounts, "AccountID", "AccountCurrency");
            ViewBag.BranchID = new SelectList(db.Branches, "BranchID", "BranchName");
            return View();
        }

        // POST: BankAccounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "AccountID,AccountCurrency,AccountType,MinimumBalance,AccounBalance,BranchID,OpenDate")] BankAccount bankAccount)
        {
            if (ModelState.IsValid)
            {
                db.BankAccounts.Add(bankAccount);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.AccountID = new SelectList(db.BankAccounts, "AccountID", "AccountCurrency", bankAccount.AccountID);
            ViewBag.AccountID = new SelectList(db.BankAccounts, "AccountID", "AccountCurrency", bankAccount.AccountID);
            ViewBag.BranchID = new SelectList(db.Branches, "BranchID", "BranchName", bankAccount.BranchID);
            return View(bankAccount);
        }

        // GET: BankAccounts/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BankAccount bankAccount = await db.BankAccounts.FindAsync(id);
            if (bankAccount == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccountID = new SelectList(db.BankAccounts, "AccountID", "AccountCurrency", bankAccount.AccountID);
            ViewBag.AccountID = new SelectList(db.BankAccounts, "AccountID", "AccountCurrency", bankAccount.AccountID);
            ViewBag.BranchID = new SelectList(db.Branches, "BranchID", "BranchName", bankAccount.BranchID);
            return View(bankAccount);
        }

        // POST: BankAccounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "AccountID,AccountCurrency,AccountType,MinimumBalance,AccounBalance,BranchID,OpenDate")] BankAccount bankAccount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bankAccount).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.AccountID = new SelectList(db.BankAccounts, "AccountID", "AccountCurrency", bankAccount.AccountID);
            ViewBag.AccountID = new SelectList(db.BankAccounts, "AccountID", "AccountCurrency", bankAccount.AccountID);
            ViewBag.BranchID = new SelectList(db.Branches, "BranchID", "BranchName", bankAccount.BranchID);
            return View(bankAccount);
        }

        // GET: BankAccounts/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BankAccount bankAccount = await db.BankAccounts.FindAsync(id);
            if (bankAccount == null)
            {
                return HttpNotFound();
            }
            return View(bankAccount);
        }

        // POST: BankAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            BankAccount bankAccount = await db.BankAccounts.FindAsync(id);
            db.BankAccounts.Remove(bankAccount);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
