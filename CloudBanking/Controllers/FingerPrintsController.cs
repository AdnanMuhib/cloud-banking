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
    public class FingerPrintsController : Controller
    {
        private CloudBankingEntities db = new CloudBankingEntities();

        // GET: FingerPrints
        public ActionResult Index()
        {
            var fingerPrints = db.FingerPrints.Include(f => f.Customer);
            return View(fingerPrints.ToList());
        }

        // GET: FingerPrints/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FingerPrint fingerPrint = db.FingerPrints.Find(id);
            if (fingerPrint == null)
            {
                return HttpNotFound();
            }
            return View(fingerPrint);
        }

        // GET: FingerPrints/Create
        public ActionResult Create()
        {
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CustomerName");
            return View();
        }

        // POST: FingerPrints/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FingerPrintID,CustomerID,Arcs,Whorls,Loops")] FingerPrint fingerPrint)
        {
            if (ModelState.IsValid)
            {
                db.FingerPrints.Add(fingerPrint);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CustomerName", fingerPrint.CustomerID);
            return View(fingerPrint);
        }

        // GET: FingerPrints/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FingerPrint fingerPrint = db.FingerPrints.Find(id);
            if (fingerPrint == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CustomerName", fingerPrint.CustomerID);
            return View(fingerPrint);
        }

        // POST: FingerPrints/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FingerPrintID,CustomerID,Arcs,Whorls,Loops")] FingerPrint fingerPrint)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fingerPrint).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CustomerName", fingerPrint.CustomerID);
            return View(fingerPrint);
        }

        // GET: FingerPrints/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FingerPrint fingerPrint = db.FingerPrints.Find(id);
            if (fingerPrint == null)
            {
                return HttpNotFound();
            }
            return View(fingerPrint);
        }

        // POST: FingerPrints/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FingerPrint fingerPrint = db.FingerPrints.Find(id);
            db.FingerPrints.Remove(fingerPrint);
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
