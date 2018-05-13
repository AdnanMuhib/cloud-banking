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
    public class AccountCustomersController : Controller
    {
        private CloudBankingEntities db = new CloudBankingEntities();

        // GET: AccountCustomers
        public async Task<ActionResult> Index()
        {
            var accountCustomers = db.AccountCustomers.Include(a => a.BankAccount).Include(a => a.Customer);
            return View(await accountCustomers.ToListAsync());
        }

        // GET: AccountCustomers/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountCustomer accountCustomer = await db.AccountCustomers.FindAsync(id);
            if (accountCustomer == null)
            {
                return HttpNotFound();
            }
            return View(accountCustomer);
        }

        // GET: AccountCustomers/Create
        public ActionResult Create()
        {
            ViewBag.AccountID = new SelectList(db.BankAccounts, "AccountID", "AccountCurrency");
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CustomerName");
            return View();
        }

        // POST: AccountCustomers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "AccountID,CustomerID,ID")] AccountCustomer accountCustomer)
        {
            if (ModelState.IsValid)
            {
                db.AccountCustomers.Add(accountCustomer);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.AccountID = new SelectList(db.BankAccounts, "AccountID", "AccountCurrency", accountCustomer.AccountID);
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CustomerName", accountCustomer.CustomerID);
            return View(accountCustomer);
        }

        // GET: AccountCustomers/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountCustomer accountCustomer = await db.AccountCustomers.FindAsync(id);
            if (accountCustomer == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccountID = new SelectList(db.BankAccounts, "AccountID", "AccountCurrency", accountCustomer.AccountID);
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CustomerName", accountCustomer.CustomerID);
            return View(accountCustomer);
        }

        // POST: AccountCustomers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "AccountID,CustomerID,ID")] AccountCustomer accountCustomer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accountCustomer).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.AccountID = new SelectList(db.BankAccounts, "AccountID", "AccountCurrency", accountCustomer.AccountID);
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CustomerName", accountCustomer.CustomerID);
            return View(accountCustomer);
        }

        // GET: AccountCustomers/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountCustomer accountCustomer = await db.AccountCustomers.FindAsync(id);
            if (accountCustomer == null)
            {
                return HttpNotFound();
            }
            return View(accountCustomer);
        }

        // POST: AccountCustomers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            AccountCustomer accountCustomer = await db.AccountCustomers.FindAsync(id);
            db.AccountCustomers.Remove(accountCustomer);
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
