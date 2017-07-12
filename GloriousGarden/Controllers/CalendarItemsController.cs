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
