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
    public class WalletsController : Controller
    {
        private CloudBankingEntities db = new CloudBankingEntities();

        // GET: Wallets
        public ActionResult Index()
        {
            var wallets = db.Wallets.Include(w => w.BankTransaction);
            return View(wallets.ToList());
        }

        // GET: Wallets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wallet wallet = db.Wallets.Find(id);
            if (wallet == null)
            {
                return HttpNotFound();
            }
            return View(wallet);
        }

        // GET: Wallets/Create
        public ActionResult Create()
        {
            ViewBag.TransactionID = new SelectList(db.BankTransactions, "TransactionID", "TransactionType");
            return View();
        }

        // POST: Wallets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WalletID,AuthKey,WalletType,TransactionID")] Wallet wallet)
        {
            if (ModelState.IsValid)
            {
                db.Wallets.Add(wallet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TransactionID = new SelectList(db.BankTransactions, "TransactionID", "TransactionType", wallet.TransactionID);
            return View(wallet);
        }

        // GET: Wallets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wallet wallet = db.Wallets.Find(id);
            if (wallet == null)
            {
                return HttpNotFound();
            }
            ViewBag.TransactionID = new SelectList(db.BankTransactions, "TransactionID", "TransactionType", wallet.TransactionID);
            return View(wallet);
        }

        // POST: Wallets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WalletID,AuthKey,WalletType,TransactionID")] Wallet wallet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wallet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TransactionID = new SelectList(db.BankTransactions, "TransactionID", "TransactionType", wallet.TransactionID);
            return View(wallet);
        }

        // GET: Wallets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wallet wallet = db.Wallets.Find(id);
            if (wallet == null)
            {
                return HttpNotFound();
            }
            return View(wallet);
        }

        // POST: Wallets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Wallet wallet = db.Wallets.Find(id);
            db.Wallets.Remove(wallet);
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
