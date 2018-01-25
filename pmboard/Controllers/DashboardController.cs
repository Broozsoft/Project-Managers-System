using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using pmboard.Models;
using System.Data.Entity;
using System.Reflection;

namespace pmboard.Controllers
{
    public class DashboardController : Controller
    {
      
        private DbEntities db = new DbEntities();

        public ActionResult Index()
        {
            DashboardViewModel DVM = new DashboardViewModel
            {
                ProjectList = db.Projects.GroupBy(x => x.Category).ToList(),
                ScheduleList = db.Schedules.ToList(),
                Archive = new ProjectsController().DisplayFinishedProjectsFromPreviousQuarter()
        };
            //Response.AddHeader("Refresh", "5");
            return View(DVM);
        }

        public string CategoryName(int id)
        {
            string name = db.Categories.First(x => x.Id == id).Name;

            return (name);
        }

        public ActionResult editDate(int projectId,string idName,DateTime newDate)
        {

            
            Projects proj = db.Projects.SingleOrDefault(x => x.Id == projectId);
            switch (idName)
            {
                case "FS":
                    proj.FS = newDate;
                    break;
                case "G0":
                    proj.G0 = newDate;
                    break;
                case "RDB":
                    proj.RDB = newDate;
                    break;
                case "G1":
                    proj.G1 = newDate;
                    break;
                case "R2":
                    proj.R2 = newDate;
                    break;
                case "G2":
                    proj.G2 = newDate;
                    break;
                case "R3":
                    proj.R3 = newDate;
                    break;
                case "R4":
                    proj.R4 = newDate;
                    break;
                case "G3":
                    proj.G3 = newDate;
                    break;
                case "R5":
                    proj.R5 = newDate;
                    break;
                case "R7":
                    proj.R7 = newDate;
                    break;
                case "R8":
                    proj.R8 = newDate;
                    break;
                case "G4":
                    proj.G4 = newDate;
                    break;
                case "END":
                    proj.END = newDate;
                    break;


            }
            db.Entry(proj).State = EntityState.Modified;

             db.SaveChanges();

            string date = newDate.Month +"/"+ newDate.Day;
            ViewBag.date = date;
            return PartialView("");
        }

        public ActionResult SetStatus(int? pmId, string status, string day)
        {
            Schedules schedule = db.Schedules.SingleOrDefault(x => x.ProjectmanagerId == pmId);

            switch (day)
            {
                case "monday":
                    schedule.Monday = status;
                    break;
                case "tuesday":
                    schedule.Tuesday = status;
                    break;
                case "wednesday":
                    schedule.Wednesday = status;
                    break;
                case "thursday":
                    schedule.Thursday = status;
                    break;
                case "friday":
                    schedule.Friday = status;
                    break;
            }

            db.Entry(schedule).State = EntityState.Modified;

            db.SaveChanges();

            return PartialView("");
        }

        public ActionResult RemoveStatus(int? pmId, string day)
        {
            Schedules schedule = db.Schedules.SingleOrDefault(x => x.ProjectmanagerId == pmId);

            switch (day)
            {
                case "monday":
                    schedule.Monday = "available";
                    break;
                case "tuesday":
                    schedule.Tuesday = "available";
                    break;
                case "wednesday":
                    schedule.Wednesday = "available";
                    break;
                case "thursday":
                    schedule.Thursday = "available";
                    break;
                case "friday":
                    schedule.Friday = "available";
                    break;
            }

            db.Entry(schedule).State = EntityState.Modified;

            db.SaveChanges();

            return PartialView("");
        }

        public ActionResult SetProgress(int? pId, string progress)
        {
            Projects project = db.Projects.SingleOrDefault(x => x.Id == pId);

            project.ProgressString = progress;

            db.Entry(project).State = EntityState.Modified;

            db.SaveChanges();

            return PartialView("");
        }

        public ActionResult ClearSchedule()
        {
            var schedules = db.Schedules.ToList();

            foreach(var item in schedules)
            {
                item.Monday = "";
                item.Tuesday = "";
                item.Wednesday = "";
                item.Thursday = "";
                item.Friday = "";
            }

            db.SaveChanges();

            return PartialView("");
        }

        public ActionResult GoldStar(int? pId, string status)
        {
            var GS = db.GoldStar.ToList();

            foreach (var item in GS)
            {
                item.StarActive = false;
            }

            GoldStar newGS = db.GoldStar.FirstOrDefault(x => x.ProjectId == pId);

            if (status == "true")
            {
                newGS.StarActive = false;
            }
            else
            {
                newGS.StarActive = true;
            }

            db.Entry(newGS).State = EntityState.Modified;

            db.SaveChanges();

            return PartialView("");
            
        }
    }
}