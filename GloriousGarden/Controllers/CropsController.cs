using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace GloriousGarden.Models
{
    public class CropsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Crops
        public ActionResult Index()
        {
            var crops = db.Crops.Include(c => c.Location);
            return View(crops.ToList());
        }

        // GET: Crops/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Crops crops = db.Crops.Find(id);
            if (crops == null)
            {
                return HttpNotFound();
            }
            return View(crops);
        }

        // GET: Crops/Create
        public ActionResult Create()
        {
            ViewBag.LocationIdRef = new SelectList(db.locations, "LocationId", "LocationName");
            return View();
        }

        // POST: Crops/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CropName,Variety,SownDate,PlantedDate,GerminationDate,HarvestDate,LocationIdRef,yield,satisfaction,notes")] Crops crops)
        {
            if (ModelState.IsValid)
            {
                db.Crops.Add(crops);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LocationIdRef = new SelectList(db.locations, "LocationId", "LocationName", crops.LocationIdRef);
            return View(crops);
        }

        // GET: Crops/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Crops crops = db.Crops.Find(id);
            if (crops == null)
            {
                return HttpNotFound();
            }
            ViewBag.LocationIdRef = new SelectList(db.locations, "LocationId", "LocationName", crops.LocationIdRef);
            return View(crops);
        }

        // POST: Crops/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CropName,Variety,SownDate,PlantedDate,GerminationDate,HarvestDate,LocationIdRef,yield,satisfaction,notes")] Crops crops)
        {
            if (ModelState.IsValid)
            {
                db.Entry(crops).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LocationIdRef = new SelectList(db.locations, "LocationId", "LocationName", crops.LocationIdRef);
            return View(crops);
        }

        // GET: Crops/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Crops crops = db.Crops.Find(id);
            if (crops == null)
            {
                return HttpNotFound();
            }
            return View(crops);
        }

        // POST: Crops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Crops crops = db.Crops.Find(id);
            db.Crops.Remove(crops);
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
