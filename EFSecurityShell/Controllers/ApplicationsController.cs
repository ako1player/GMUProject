using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GMUProject.Data;
using GMUProject.Models;

namespace GMUProject.Controllers
{
    public class ApplicationsController : Controller
    {
        private GMUProjectContext db = new GMUProjectContext();

        // GET: Applications
        [Authorize]
        public ActionResult Index(string app, string search)
        {
            var applications = db.Applications.Include(a => a.Decision).Include(a => a.Major).Include(a => a.Term);
            if (!String.IsNullOrEmpty(search))
            {
                applications = applications.Where(a => a.SSN.Contains(search) || a.LastName.Contains(search));
            }
            return View(applications.ToList());
        }

        // GET: Applications/Details/5
        [Authorize(Roles = "Admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Application application = db.Applications.Find(id);
            if (application == null)
            {
                return HttpNotFound();
            }
            return View(application);
        }

        // GET: Applications/Create
        public ActionResult Create()
        {
            ViewBag.DecisionID = new SelectList(db.Decisions, "ID", "EnrollmenDecision");
            ViewBag.MajorID = new SelectList(db.Majors, "ID", "MajorName");
            ViewBag.TermID = new SelectList(db.Terms, "ID", "TermName");
            return View();
        }

        // POST: Applications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FirstName,MiddleName,LastName,SSN,Email,HomePhone,CellPhone,Street,City,State,Zip,DOB,Gender,HighschoolName,HighschoolCity,GraduationDate,GPA,MathSat,VerbalSat,MajorID,EnrollmentDate,TermID,Year,DecisionID")] Application application)
        {
            if (ModelState.IsValid)
            {
                Application matchingApplication = db.Applications.Where(cm => string.Compare(cm.SSN, application.SSN, true) == 0).FirstOrDefault();

                if(application == null)
                {
                    return HttpNotFound();
                }

                if(matchingApplication != null)
                {
                    ModelState.AddModelError("SSN", "Duplicate SSN Found.");
                    ViewBag.MajorID = new SelectList(db.Majors, "ID", "MajorName", application.MajorID);
                    ViewBag.TermID = new SelectList(db.Terms, "ID", "TermName", application.TermID);
                    return View(application);
                }

                db.Applications.Add(application);
                db.SaveChanges();
                return RedirectToAction("Index","Home");
            }

            ViewBag.DecisionID = new SelectList(db.Decisions, "ID", "EnrollmenDecision", application.DecisionID);
            return View(application);
        }

        // GET: Applications/Edit/5
        [Authorize(Roles ="Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Application application = db.Applications.Find(id);
            if (application == null)
            {
                return HttpNotFound();
            }
            ViewBag.DecisionID = new SelectList(db.Decisions, "ID", "EnrollmenDecision", application.DecisionID);
            ViewBag.MajorID = new SelectList(db.Majors, "ID", "MajorName", application.MajorID);
            ViewBag.TermID = new SelectList(db.Terms, "ID", "TermName", application.TermID);
            return View(application);
        }

        // POST: Applications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "ID,FirstName,MiddleName,LastName,SSN,Email,HomePhone,CellPhone,Street,City,State,Zip,DOB,Gender,HighschoolName,HighschoolCity,GraduationDate,GPA,MathSat,VerbalSat,MajorID,EnrollmentDate,TermID,Year,DecisionID")] Application application)
        {
            if (ModelState.IsValid)
            {
                db.Entry(application).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DecisionID = new SelectList(db.Decisions, "ID", "EnrollmenDecision", application.DecisionID);
            ViewBag.MajorID = new SelectList(db.Majors, "ID", "MajorName", application.MajorID);
            ViewBag.TermID = new SelectList(db.Terms, "ID", "TermName", application.TermID);
            return View(application);
        }

        // GET: Applications/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Application application = db.Applications.Find(id);
            if (application == null)
            {
                return HttpNotFound();
            }
            return View(application);
        }

        // POST: Applications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Application application = db.Applications.Find(id);
            db.Applications.Remove(application);
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
