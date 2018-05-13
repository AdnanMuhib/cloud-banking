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
    public class ChequesController : Controller
    {
        private CloudBankingEntities db = new CloudBankingEntities();

        // GET: Cheques
        public ActionResult Index()
        {
            var cheques = db.Cheques.Include(c => c.Customer);
            return View(cheques.ToList());
        }

        // GET: Cheques/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cheque cheque = db.Cheques.Find(id);
            if (cheque == null)
            {
                return HttpNotFound();
            }
            return View(cheque);
        }

        // GET: Cheques/Create
        public ActionResult Create()
        {
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CustomerName");
            return View();
        }

        // POST: Cheques/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ChequeID,CustomerID,Amount,AmountInWords,PayeeName,ChequeDate,MACAddress,IPAddress")] Cheque cheque)
        {
            if (ModelState.IsValid)
            {
                db.Cheques.Add(cheque);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CustomerName", cheque.CustomerID);
            return View(cheque);
        }

        // GET: Cheques/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cheque cheque = db.Cheques.Find(id);
            if (cheque == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CustomerName", cheque.CustomerID);
            return View(cheque);
        }

        // POST: Cheques/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ChequeID,CustomerID,Amount,AmountInWords,PayeeName,ChequeDate,MACAddress,IPAddress")] Cheque cheque)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cheque).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CustomerName", cheque.CustomerID);
            return View(cheque);
        }

        // GET: Cheques/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cheque cheque = db.Cheques.Find(id);
            if (cheque == null)
            {
                return HttpNotFound();
            }
            return View(cheque);
        }

        // POST: Cheques/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cheque cheque = db.Cheques.Find(id);
            db.Cheques.Remove(cheque);
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
