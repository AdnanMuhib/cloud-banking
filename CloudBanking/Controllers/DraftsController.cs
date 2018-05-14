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
    public class DraftsController : Controller
    {
        private CloudBankingEntities db = new CloudBankingEntities();

        // GET: Drafts
        public async Task<ActionResult> Index()
        {
            var drafts = db.Drafts.Include(d => d.BankAccount).Include(d => d.Branch).Include(d => d.Customer);
            return View(await drafts.ToListAsync());
        }

        // GET: Drafts/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Draft draft = await db.Drafts.FindAsync(id);
            if (draft == null)
            {
                return HttpNotFound();
            }
            return View(draft);
        }

        // GET: Drafts/Create
        public ActionResult Create()
        {
            ViewBag.ReceiverAccountID = new SelectList(db.BankAccounts, "AccountID", "AccountCurrency");
            ViewBag.SenderBranchID = new SelectList(db.Branches, "BranchID", "BranchName");
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CustomerName");
            return View();
        }

        // POST: Drafts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "DraftID,CustomerID,SenderName,SenderCNIC,ReceiverAccountID,DraftAmount,DraftDate,ExpiryDate,SenderBranchID")] Draft draft)
        {
            if (ModelState.IsValid)
            {
                db.Drafts.Add(draft);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ReceiverAccountID = new SelectList(db.BankAccounts, "AccountID", "AccountCurrency", draft.ReceiverAccountID);
            ViewBag.SenderBranchID = new SelectList(db.Branches, "BranchID", "BranchName", draft.SenderBranchID);
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CustomerName", draft.CustomerID);
            return View(draft);
        }

        // GET: Drafts/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Draft draft = await db.Drafts.FindAsync(id);
            if (draft == null)
            {
                return HttpNotFound();
            }
            ViewBag.ReceiverAccountID = new SelectList(db.BankAccounts, "AccountID", "AccountCurrency", draft.ReceiverAccountID);
            ViewBag.SenderBranchID = new SelectList(db.Branches, "BranchID", "BranchName", draft.SenderBranchID);
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CustomerName", draft.CustomerID);
            return View(draft);
        }

        // POST: Drafts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "DraftID,CustomerID,SenderName,SenderCNIC,ReceiverAccountID,DraftAmount,DraftDate,ExpiryDate,SenderBranchID")] Draft draft)
        {
            if (ModelState.IsValid)
            {
                db.Entry(draft).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ReceiverAccountID = new SelectList(db.BankAccounts, "AccountID", "AccountCurrency", draft.ReceiverAccountID);
            ViewBag.SenderBranchID = new SelectList(db.Branches, "BranchID", "BranchName", draft.SenderBranchID);
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CustomerName", draft.CustomerID);
            return View(draft);
        }

        // GET: Drafts/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Draft draft = await db.Drafts.FindAsync(id);
            if (draft == null)
            {
                return HttpNotFound();
            }
            return View(draft);
        }

        // POST: Drafts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Draft draft = await db.Drafts.FindAsync(id);
            db.Drafts.Remove(draft);
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
