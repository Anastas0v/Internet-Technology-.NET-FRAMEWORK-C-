using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project.Models;

namespace Project.Controllers
{
    [Authorize(Roles = "Administrator, Editor")]
    public class BusController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Bus
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(db.Destinations.ToList());
        }

        // GET: Bus/Details/5
        [AllowAnonymous]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusStation busStation = db.Destinations.Find(id);
            if (busStation == null)
            {
                return HttpNotFound();
            }
            return View(busStation);
        }

        // GET: Bus/Create
        [Authorize(Roles = "Administrator")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult Create([Bind(Include = "Id,SCity,SCountry,ECity,ECountry,Type,Date,Departure,Arrival,Seat,Price")] BusStation busStation)
        {
            if (ModelState.IsValid)
            {
                db.Destinations.Add(busStation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(busStation);
        }

        // GET: Bus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusStation busStation = db.Destinations.Find(id);
            if (busStation == null)
            {
                return HttpNotFound();
            }
            return View(busStation);
        }

        // POST: Bus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SCity,SCountry,ECity,ECountry,Type,Date,Departure,Arrival,Seat,Price")] BusStation busStation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(busStation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(busStation);
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int id)
        {
            BusStation busStation = db.Destinations.Find(id);
            db.Destinations.Remove(busStation);
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
