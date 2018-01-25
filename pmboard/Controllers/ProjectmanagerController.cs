using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using pmboard.Models;
namespace pmboard.Controllers
{
    public class ProjectmanagerController : Controller
    {
        DbEntities db = new DbEntities();
        
        // GET: Projectmanager
        public ActionResult Index()
        {
            return View();
        }

        // GET: Projectmanager/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        public ActionResult ListProjectmanagers()
        {


            return View(db.Projectmanagers);
        }

        // GET: Projectmanager/Create
        [HttpGet]
        public ActionResult AddProjectmanager()
        {
            return View();
        }

        // POST: Projectmanager/Create
        [HttpPost]
        public ActionResult AddProjectmanager([Bind(Include = "Name")]Projectmanagers PM)
        {
            try
            {
                Schedules schedule = new Schedules();
                db.Schedules.Add(schedule);
                PM.Schedule = schedule;
                // TODO: Add insert logic here
                db.Projectmanagers.Add(PM);
                db.SaveChanges();
                return RedirectToAction("AddProjectmanager");
            }
            catch
            {
                return View();
            }
}

        // GET: Projectmanager/Edit/5
        [HttpGet]
        public ActionResult EditProjectmanager(int id)
        {

            return View(db.Projectmanagers.First(c=>c.ID==id));
        }

        // POST: Projectmanager/Edit/5
        [HttpPost]
        public ActionResult EditProjectmanager(Projectmanagers PM)
        {
            try
            {
                db.Projectmanagers.First(c => c.ID == PM.ID).Name = PM.Name;
                // TODO: Add update logic here
                db.SaveChanges();
                return RedirectToAction("ListProjectmanagers");
            }
            catch
            {
                return View();
            }
        }

        // GET: Projectmanager/Delete/5
        
        public ActionResult DeleteProjectmanager(int id)
        {
            var PM = db.Projectmanagers.First(c => c.ID == id);
            //PM.Projects = null;
            //db.Schedules.Remove(PM.Schedule);
            //db.Schedules.Remove(db.Schedules.First(c=>c.ScheduleId==PM.Schedule.ScheduleId));
            db.Projectmanagers.Remove(PM);
            db.SaveChanges();
            return RedirectToAction("ListProjectmanagers");
        }

        // POST: Projectmanager/Delete/5
        [HttpPost]
        public ActionResult DeleteProjectmanager(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
