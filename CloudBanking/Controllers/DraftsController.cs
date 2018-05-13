using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
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
        public ActionResult Index()
        {
            var drafts = db.Drafts.Include(d => d.Account).Include(d => d.Branch).Include(d => d.Customer);
            return View(drafts.ToList());
        }

        // GET: Drafts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Draft draft = db.Drafts.Find(id);
            if (draft == null)
            {
                return HttpNotFound();
            }
            return View(draft);
        }

        // GET: Drafts/Create
        public ActionResult Create()
        {
            ViewBag.ReceiverAccountID = new SelectList(db.Accounts, "AccountID", "AccountCurrency");
            ViewBag.SenderBranchID = new SelectList(db.Branches, "BranchID", "BranchName");
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CustomerName");
            return View();
        }

        // POST: Drafts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DraftID,CustomerID,SenderName,SenderCNIC,ReceiverAccountID,DraftAmount,DraftDate,ExpiryDate,SenderBranchID")] Draft draft)
        {
            if (ModelState.IsValid)
            {
                db.Drafts.Add(draft);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ReceiverAccountID = new SelectList(db.Accounts, "AccountID", "AccountCurrency", draft.ReceiverAccountID);
            ViewBag.SenderBranchID = new SelectList(db.Branches, "BranchID", "BranchName", draft.SenderBranchID);
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CustomerName", draft.CustomerID);
            return View(draft);
        }

        // GET: Drafts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Draft draft = db.Drafts.Find(id);
            if (draft == null)
            {
                return HttpNotFound();
            }
            ViewBag.ReceiverAccountID = new SelectList(db.Accounts, "AccountID", "AccountCurrency", draft.ReceiverAccountID);
            ViewBag.SenderBranchID = new SelectList(db.Branches, "BranchID", "BranchName", draft.SenderBranchID);
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CustomerName", draft.CustomerID);
            return View(draft);
        }

        // POST: Drafts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DraftID,CustomerID,SenderName,SenderCNIC,ReceiverAccountID,DraftAmount,DraftDate,ExpiryDate,SenderBranchID")] Draft draft)
        {
            if (ModelState.IsValid)
            {
                db.Entry(draft).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ReceiverAccountID = new SelectList(db.Accounts, "AccountID", "AccountCurrency", draft.ReceiverAccountID);
            ViewBag.SenderBranchID = new SelectList(db.Branches, "BranchID", "BranchName", draft.SenderBranchID);
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CustomerName", draft.CustomerID);
            return View(draft);
        }

        // GET: Drafts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Draft draft = db.Drafts.Find(id);
            if (draft == null)
            {
                return HttpNotFound();
            }
            return View(draft);
        }

        // POST: Drafts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Draft draft = db.Drafts.Find(id);
            db.Drafts.Remove(draft);
            db.SaveChanges();
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
