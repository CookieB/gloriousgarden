using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GloriousGarden.Models;

namespace GloriousGarden.Controllers
{
    public class CalendarItemsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //GET: CalendarItems
        public ActionResult Index()
        {
            return View();
        }
        private static DateTime ConvertFromUnixTimestamp(double timestamp)
        {
            var origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return origin.AddSeconds(timestamp);
        }
        public JsonResult GetDiaryEvents(DateTime start, DateTime end)
        {

            var ApptListForDate = db.CalendarItems.ToList(); 
            var eventList = from e in ApptListForDate
                            where e.EventDate >= start && e.EventDate <=end
                            select new
                            {
                                id = e.ID,
                                title = e.EventAction,
                                start = e.EventDate,
                            };
            var rows = eventList.ToArray();
            return Json(rows, JsonRequestBehavior.AllowGet);
        }
        // GET: CalendarItems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CalendarItem calendarItem = db.CalendarItems.Find(id);
            if (calendarItem == null)
            {
                return HttpNotFound();
            }
            return View(calendarItem);
        }

        // GET: CalendarItems/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CalendarItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,EventDate,EventAction")] CalendarItem calendarItem)
        {
            if (ModelState.IsValid)
            {
                db.CalendarItems.Add(calendarItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(calendarItem);
        }

        // GET: CalendarItems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CalendarItem calendarItem = db.CalendarItems.Find(id);
            if (calendarItem == null)
            {
                return HttpNotFound();
            }
            return View(calendarItem);
        }

        // POST: CalendarItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,EventDate,EventAction")] CalendarItem calendarItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(calendarItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(calendarItem);
        }

        // GET: CalendarItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CalendarItem calendarItem = db.CalendarItems.Find(id);
            if (calendarItem == null)
            {
                return HttpNotFound();
            }
            return View(calendarItem);
        }

        // POST: CalendarItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed()
        {
            //CalendarItem calendarItem = db.CalendarItems.Find(id);
            //db.CalendarItems.Remove(calendarItem);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }
        public Boolean DeleteEvent(int EventID)
        {
            return CalendarItem.DeleteEvent(EventID);
        }
        public Boolean SaveEvent(int EventID,string Title, string EventDate)
        {
            return CalendarItem.EditEvent(EventID, EventDate,Title);
        }
        public Boolean AddEvent(string Title, string NewEventDate)
        {
            return CalendarItem.AddEvent(NewEventDate, Title);
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
