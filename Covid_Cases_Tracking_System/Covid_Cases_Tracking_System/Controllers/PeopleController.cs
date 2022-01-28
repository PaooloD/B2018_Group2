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
    public class PeopleController : Controller
    {
        private DbCovidEntities1 db = new DbCovidEntities1();

        // GET: People
        public ActionResult Index()
        {
            return View(db.Person.ToList());
        }
        public ActionResult ActiveCases()
        {
            // var active = db.Person.FirstOrDefault().CovidCases.Where(m => m.CovidStatusID.Equals(1));

            var activestatus = db.Person.Where(m => m.CovidCases.FirstOrDefault().CovidStatusID.Equals(1));

            return View(activestatus);
        }
        public ActionResult RecoveredCases()
        {
            var activestatus = db.Person.Where(m => m.CovidCases.FirstOrDefault().CovidStatusID.Equals(3));

            return View(activestatus);
        }
        public ActionResult DeathCases()
        {
            // var active = db.Person.FirstOrDefault().CovidCases.Where(m => m.CovidStatusID.Equals(1));

           var activestatus = db.Person.Where(m => m.CovidCases.FirstOrDefault().CovidStatusID.Equals(4));

            return View(activestatus);
        }
        public ActionResult UnderInvestigation()
        {
            // var active = db.Person.FirstOrDefault().CovidCases.Where(m => m.CovidStatusID.Equals(1));

            var activestatus = db.Person.Where(m => m.CovidCases.FirstOrDefault().CovidStatusID.Equals(2));

            return View(activestatus);
        }

        // GET: People/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.Person.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // GET: People/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: People/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PersonID,Lastname,Firstname,Middlename,Suffix,Gender,Birthday,Age,Address,Contactnumber")] Person person)
        {
            if (ModelState.IsValid)
            {
                db.Person.Add(person);
                             
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CovidStatusID = new SelectList(db.CovidStatus, "CovidStatusID", "Status", person.PersonID);
            return View(person);
        }

        // GET: People/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.Person.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: People/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersonID,Lastname,Firstname,Middlename,Suffix,Gender,Birthday,Age,Address,Contactnumber")] Person person)
        {
            if (ModelState.IsValid)
            {
                db.Entry(person).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(person);
        }

        // GET: People/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.Person.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Person person = db.Person.Find(id);
            db.Person.Remove(person);
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
