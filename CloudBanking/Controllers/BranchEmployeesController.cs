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
    public class BranchEmployeesController : Controller
    {
        private CloudBankingEntities db = new CloudBankingEntities();

        // GET: BranchEmployees
        public ActionResult Index()
        {
            var branchEmployees = db.BranchEmployees.Include(b => b.Branch).Include(b => b.Employee);
            return View(branchEmployees.ToList());
        }

        // GET: BranchEmployees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BranchEmployee branchEmployee = db.BranchEmployees.Find(id);
            if (branchEmployee == null)
            {
                return HttpNotFound();
            }
            return View(branchEmployee);
        }

        // GET: BranchEmployees/Create
        public ActionResult Create()
        {
            ViewBag.BranchID = new SelectList(db.Branches, "BranchID", "BranchName");
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "EmpName");
            return View();
        }

        // POST: BranchEmployees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeID,BranchID,StartDate,EndDate")] BranchEmployee branchEmployee)
        {
            if (ModelState.IsValid)
            {
                db.BranchEmployees.Add(branchEmployee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BranchID = new SelectList(db.Branches, "BranchID", "BranchName", branchEmployee.BranchID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "EmpName", branchEmployee.EmployeeID);
            return View(branchEmployee);
        }

        // GET: BranchEmployees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BranchEmployee branchEmployee = db.BranchEmployees.Find(id);
            if (branchEmployee == null)
            {
                return HttpNotFound();
            }
            ViewBag.BranchID = new SelectList(db.Branches, "BranchID", "BranchName", branchEmployee.BranchID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "EmpName", branchEmployee.EmployeeID);
            return View(branchEmployee);
        }

        // POST: BranchEmployees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeID,BranchID,StartDate,EndDate")] BranchEmployee branchEmployee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(branchEmployee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BranchID = new SelectList(db.Branches, "BranchID", "BranchName", branchEmployee.BranchID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "EmpName", branchEmployee.EmployeeID);
            return View(branchEmployee);
        }

        // GET: BranchEmployees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BranchEmployee branchEmployee = db.BranchEmployees.Find(id);
            if (branchEmployee == null)
            {
                return HttpNotFound();
            }
            return View(branchEmployee);
        }

        // POST: BranchEmployees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BranchEmployee branchEmployee = db.BranchEmployees.Find(id);
            db.BranchEmployees.Remove(branchEmployee);
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
