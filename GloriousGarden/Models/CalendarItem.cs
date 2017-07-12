using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace GloriousGarden.Models
{
    public class CalendarItem
    {
        public int ID { get; set; }
        public DateTime EventDate { get; set; }
        public String EventAction { get; set; }

        public static Boolean AddEvent(String evDate, String evAction)
        {
            CalendarItem ev = new CalendarItem();
            try
            {
                ev.EventDate = DateTime.ParseExact(evDate, "dd-MMM-yyyy", CultureInfo.InvariantCulture);
                ev.EventAction = evAction;
                ApplicationDbContext ent = new ApplicationDbContext();
                ent.CalendarItems.Add(ev);
                ent.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static Boolean DeleteEvent(int eventID)
        {
            try
            {
                ApplicationDbContext ent = new ApplicationDbContext();
                CalendarItem ev = ent.CalendarItems.Find(eventID);
                ent.CalendarItems.Remove(ev);
                ent.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static Boolean EditEvent(int eventID, String evDate, String evAction)
        {
            try
            {
                ApplicationDbContext ent = new ApplicationDbContext();
                CalendarItem ev = ent.CalendarItems.Find(eventID);
                ev.EventDate = DateTime.ParseExact(evDate, "dd-MMM-yyyy", CultureInfo.InvariantCulture);
                ev.EventAction = evAction;
                ent.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}