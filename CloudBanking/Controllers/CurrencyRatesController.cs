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
    public class CurrencyRatesController : Controller
    {
        private CloudBankingEntities db = new CloudBankingEntities();

        // GET: CurrencyRates
        public ActionResult Index()
        {
            return View(db.CurrencyRates.ToList());
        }

        // GET: CurrencyRates/Details/5
        public ActionResult Details(DateTime id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CurrencyRate currencyRate = db.CurrencyRates.Find(id);
            if (currencyRate == null)
            {
                return HttpNotFound();
            }
            return View(currencyRate);
        }

        // GET: CurrencyRates/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CurrencyRates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CurrencyDate,USD,YEN,INR,POUND,EURO,RIAL,DIRHAM")] CurrencyRate currencyRate)
        {
            if (ModelState.IsValid)
            {
                db.CurrencyRates.Add(currencyRate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(currencyRate);
        }

        // GET: CurrencyRates/Edit/5
        public ActionResult Edit(DateTime id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CurrencyRate currencyRate = db.CurrencyRates.Find(id);
            if (currencyRate == null)
            {
                return HttpNotFound();
            }
            return View(currencyRate);
        }

        // POST: CurrencyRates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CurrencyDate,USD,YEN,INR,POUND,EURO,RIAL,DIRHAM")] CurrencyRate currencyRate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(currencyRate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(currencyRate);
        }

        // GET: CurrencyRates/Delete/5
        public ActionResult Delete(DateTime id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CurrencyRate currencyRate = db.CurrencyRates.Find(id);
            if (currencyRate == null)
            {
                return HttpNotFound();
            }
            return View(currencyRate);
        }

        // POST: CurrencyRates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(DateTime id)
        {
            CurrencyRate currencyRate = db.CurrencyRates.Find(id);
            db.CurrencyRates.Remove(currencyRate);
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
