using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Covid_Cases_Tracking_System.Models;

namespace Covid_Cases_Tracking_System.Controllers
{
    public class CovidCasesController : Controller
    {
        private DbCovidEntities1 db = new DbCovidEntities1();

        // GET: CovidCases
        public ActionResult Index()
        {
            var covidCases = db.CovidCases.Include(c => c.CovidStatus).Include(c => c.Person);
            return View(covidCases.ToList());
        }

        // GET: CovidCases/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CovidCases covidCases = db.CovidCases.Find(id);
            if (covidCases == null)
            {
                return HttpNotFound();
            }
            return View(covidCases);
        }

        // GET: CovidCases/Create
        public ActionResult Create()
        {
            ViewBag.CovidStatusID = new SelectList(db.CovidStatus, "CovidStatusID", "Status");
            var persons = db.Person.Select(m => new { Fullname = m.Firstname + " " + m.Lastname, PersonId = m.PersonID }).OrderBy(m => m.Fullname).ToList();
            ViewBag.PersonID = new SelectList(persons, "PersonId", "Fullname" );
            return View();
        }

        // POST: CovidCases/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CovidCasesID,PersonID,CovidStatusID,Date")] CovidCases covidCases)
        {
            if (ModelState.IsValid)
            {
                db.CovidCases.Add(covidCases);
                db.SaveChanges();
                return RedirectToAction("Index","People");
            }

            ViewBag.CovidStatusID = new SelectList(db.CovidStatus, "CovidStatusID", "Status", covidCases.CovidStatusID);
            ViewBag.PersonID = new SelectList(db.Person, "PersonID","Lastname", covidCases.PersonID);
            return View("People");
        }

        // GET: CovidCases/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CovidCases covidCases = db.CovidCases.Find(id);
            if (covidCases == null)
            {
                return HttpNotFound();
            }
            ViewBag.CovidStatusID = new SelectList(db.CovidStatus, "CovidStatusID", "Status", covidCases.CovidStatusID);
            ViewBag.PersonID = new SelectList(db.Person, "PersonID", "Lastname", covidCases.PersonID);
            return View(covidCases);
        }

        // POST: CovidCases/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CovidCasesID,PersonID,CovidStatusID,Date")] CovidCases covidCases)
        {
            if (ModelState.IsValid)
            {
                db.Entry(covidCases).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CovidStatusID = new SelectList(db.CovidStatus, "CovidStatusID", "Status", covidCases.CovidStatusID);
            ViewBag.PersonID = new SelectList(db.Person, "PersonID", "Lastname", covidCases.PersonID);
            return View(covidCases);
        }

        // GET: CovidCases/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CovidCases covidCases = db.CovidCases.Find(id);
            if (covidCases == null)
            {
                return HttpNotFound();
            }
            return View(covidCases);
        }

        // POST: CovidCases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CovidCases covidCases = db.CovidCases.Find(id);
            db.CovidCases.Remove(covidCases);
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
