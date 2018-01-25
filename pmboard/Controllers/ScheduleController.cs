using pmboard.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace pmboard.Controllers
{
    public class ScheduleController : Controller
    {
        DbEntities db = new DbEntities();
        
        public ActionResult Index()
        {
            var scheduleList = db.Schedules.ToList();

            return View(scheduleList);
        }

        // GET: Schedule/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Schedules schedule = db.Schedules.Find(id);

            if (schedule == null)
            {
                return HttpNotFound();
            }
            
            return View(schedule);
        }

        // POST: Schedule/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,Monday,Tuesday,Wednesday,Thursday,Friday,ProjectmanagerId")] Schedules schedules)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(schedules).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //        return View();
            
        //}

        public ActionResult UpdateStatus(int? pmId, string mon, string tues, string wed, string thurs, string fri )
        {
            Schedules schedule = db.Schedules.SingleOrDefault(x => x.ProjectmanagerId == pmId);

            schedule.Monday = mon;
            schedule.Tuesday = tues;
            schedule.Wednesday = wed;
            schedule.Thursday = thurs;
            schedule.Friday = fri;

            db.Entry(schedule).State = EntityState.Modified;

            db.SaveChanges();
            return PartialView("");
        }
    }
}
