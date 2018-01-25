using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using pmboard.Models;
using System.Globalization;

namespace pmboard.Controllers
{
    public class ProjectsController : Controller
    {
        private DbEntities db = new DbEntities();

        // GET: Projectsjhjk  jhkj
        public ActionResult Index()
        {
            List<Projects> projects;
            if (Session["projectManager"] != null)
            {
                Projectmanagers projectManagerSession = (Projectmanagers)Session["projectManager"];



                projects = db.Projects.Where(x => x.Projectmanager.ID == projectManagerSession.ID).ToList();
            }
            else
            {
                projects = db.Projects.Include(p => p.Category).Include(p => p.GateKeeper).Include(p => p.Projectmanager).ToList();
                //projects = db.Projects.Where(z => z.IsDeleted == false).Include(p => p.Category).Include(p => p.GateKeeper).Include(p => p.Projectmanager).ToList();
            }
            return View(projects);
        }

        // GET: Projects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projects projects = db.Projects.Find(id);
            if (projects == null)
            {
                return HttpNotFound();
            }
            return View(projects);
        }

        public ActionResult UpdatePointer()
        {
            var projects = db.Projects.ToList();
            var projectList = projects.GroupBy(x => x.Category).ToList();
            return View(projectList);
        }


        public ActionResult UpdatePointerAjax()
        {
            var projects = db.Projects.ToList();
            var projectList = projects.GroupBy(x => x.Category).ToList();
            return PartialView(projectList);
        }

        public ActionResult MovePointer(int? id, string goal)
        {
            Projects project = db.Projects.Find(id);
            project.ProgressString = goal;
            db.Entry(project).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("UpdatePointerAjax");
        }

        public ActionResult UpdateStatuses(int?id, string status)
        {
            Projects project = db.Projects.Find(id);
            project.Status = status;
            db.Entry(project).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("UpdatePointerAjax");
        }
        // GET: Projects/Create
        public ActionResult Create()
        {
            if (Session["ProjectManager"] == null)
            {
                return Redirect("~/Gui/Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");
            ViewBag.GateKeeperId = new SelectList(db.GateKeepers, "Id", "Name");
            ViewBag.ProjectmanagerId = new SelectList(db.Projectmanagers, "ID", "Name");
            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ProjectName,FS,G0,RDB,G1,R2,G2,R3,R4,G3,R5,R7,R8,G4,END,Status,KPI,Comment,CategoryId,GateKeeperId,ProjectmanagerId")] Projects projects)
        {
            if (ModelState.IsValid)
            {
                GoldStar gs = new GoldStar();
                gs.StarActive = false;
                db.GoldStar.Add(gs);
                projects.GoldStar = gs;
                Projectmanagers projectManagerSession = (Projectmanagers)Session["projectManager"];
                projects.ProjectmanagerId = projectManagerSession.ID;
                projects.Status = "#81c784";
                db.Projects.Add(projects);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", projects.CategoryId);
            ViewBag.GateKeeperId = new SelectList(db.GateKeepers, "Id", "Name", projects.GateKeeperId);
            ViewBag.ProjectmanagerId = new SelectList(db.Projectmanagers, "ID", "Name", projects.ProjectmanagerId);
            return View(projects);
        }

        // GET: Projects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projects projects = db.Projects.Find(id);
            if (projects == null)
            {
                return HttpNotFound();
            }
            
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", projects.CategoryId);
            ViewBag.GateKeeperId = new SelectList(db.GateKeepers, "Id", "Name", projects.GateKeeperId);
            ViewBag.ProjectmanagerId = new SelectList(db.Projectmanagers, "ID", "Name", projects.ProjectmanagerId);
            return View(projects);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //Use List<string> StringToList(string) and string ListToString(List<string>) to switch between lists and strings.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ProjectName,FS,G0,RDB,G1,R2,G2,R3,R4,G3,R5,R7,R8,G4,END,Status,KPI,Comment,CategoryId,GateKeeperId,ProjectmanagerId")] Projects projects)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projects).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", projects.CategoryId);
            ViewBag.GateKeeperId = new SelectList(db.GateKeepers, "Id", "Name", projects.GateKeeperId);
            ViewBag.ProjectmanagerId = new SelectList(db.Projectmanagers, "ID", "Name", projects.ProjectmanagerId);
            return View(projects);
        }

       
       
        
        public JsonResult DeleteProject(int projectId)
        {


            bool result = false;
            Projects proj = db.Projects.SingleOrDefault(x => x.Id == projectId);
            if (proj != null)
            {
                db.Projects.Remove(proj);
                db.SaveChanges();
                result = false;
            }
         
           
            return Json(result, JsonRequestBehavior.AllowGet);
        }
      

        public JsonResult DisableProject(int projectId)
        {
            

            bool result = false;
            Projects proj = db.Projects.SingleOrDefault(x=>x.Id == projectId);
            if (proj != null&&proj.IsDeleted==false)
            {
                proj.IsDeleted = true;
                db.SaveChanges();
                result = true;
            }
                 else if (proj != null && proj.IsDeleted == true)
            {
                proj.IsDeleted = false;
                db.SaveChanges();
                result = false;
            }
            //return RedirectToAction("DisableProject");
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        private bool CheckIfSameWeek(DateTime date1, DateTime date2)
        {
            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            Calendar cal = dfi.Calendar;
            int i1 = cal.GetWeekOfYear(date1, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
            int i2 = cal.GetWeekOfYear(date2, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
            bool boo = (i1 == i2);//cal.GetWeekOfYear(date1, dfi.CalendarWeekRule,dfi.FirstDayOfWeek)== cal.GetWeekOfYear(date2, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
            DateTime smallerDate;
            DateTime largerDate;

            if (date1.Year != date2.Year)
            {



                if (date1 < date2)
                {
                    smallerDate = date1;
                    largerDate = date2;
                }else
                {
                    smallerDate = date2;
                    largerDate = date1;
                }
                smallerDate.AddDays(7);
                if (boo && (smallerDate >= largerDate))
                {
                    return boo;
                }
                else return false;

            }
            return boo;

        }
        public List<int> CalculateWeeklyKPIForProject(int Id)
        {

            Projects Project = db.Projects.First(c => c.Id == Id);
            bool sameWeekG2 = CheckIfSameWeek(Project.G2.Date, DateTime.Now.Date);
            bool sameWeekG4 = CheckIfSameWeek(Project.G4.Date, DateTime.Now.Date);
            return CalculateKPIForProject(Id, sameWeekG2, sameWeekG4);

        }
        public List<int> CalculateMonthlyKPIForProject(int Id)
        {
            Projects Project = db.Projects.First(c => c.Id == Id);
            DateTime Today = DateTime.Now.Date;
            bool sameMonthG2 = (Project.G2.Month == Today.Month && Project.G2.Year == Today.Year);
            bool sameMonthG4 = (Project.G4.Month == Today.Month && Project.G4.Year == Today.Year); 
            return CalculateKPIForProject(Id, sameMonthG2, sameMonthG4);
        }
        public List<int> CalculateQuarterlyKPIForProject(int Id)
        {
            Projects Project = db.Projects.First(c => c.Id == Id);
            DateTime Today = DateTime.Now.Date;
            List<int> q1 = new List<int> { 10, 11, 12 };
            List<int> q2 = new List<int> { 1, 2, 3 };
            List<int> q3 = new List<int> { 4, 5, 6 };
            List<int> q4 = new List<int> { 7, 8, 9 };
            List<List<int>> FourQs = new List<List<int>> { q1, q2, q3, q4 };
            bool sameQuarterG2 = false;
            bool sameQuarterG4 = false;
            foreach (var item in FourQs)
            {
                if (item.Contains(Today.Month) && Project.G2.Year == Today.Year) sameQuarterG2 = (item.Contains(Project.G2.Month));
                if (item.Contains(Today.Month) && Project.G4.Year == Today.Year) sameQuarterG4 = (item.Contains(Project.G4.Month));
            }
            return CalculateKPIForProject(Id, sameQuarterG2, sameQuarterG4);
        }
        public List<int> CalculateKPIForProject(int Id,bool samePeriodG2, bool samePeriodG4)
        {
            Projects Project = db.Projects.First(c=>c.Id==Id);
            int KPI = 0;
            int counter = 0;
            List<int> KPIList = new List<int>();
            string ProgressString = Project.ProgressString;
            if (ProgressString == null) ProgressString="";
            if (samePeriodG2)
            {
                if (ProgressString.Contains("G2") ) KPI++;
                counter++;
            }
            if (samePeriodG4)
            {
                if (ProgressString.Contains("G4"))
                {
                    KPI++;
                    if (samePeriodG2) KPI++;
                }
                counter++;
            }
            KPIList.Add(KPI);
            KPIList.Add(counter);
            Console.WriteLine(counter);
            return KPIList;
        }

        public string DisplayQuarterlyKPI()
        {
            var Projects = db.Projects.ToList();
            int KPISum=0;
            int Counter = 0;
            foreach (var item in Projects)
            {
                if (!item.IsDeleted)
                {
                    var temp = CalculateQuarterlyKPIForProject(item.Id).ToList();
                    if (temp.Count() > 0)
                    {
                        KPISum += temp[0];
                        Counter += temp[1];
                    }
                }
            }
            if (Counter>0)
            {
            double KPI = Math.Round((KPISum / (double)Counter), 2);
            return KPI.ToString("#0.##%");
            }
            else return "No Active Goals for that period";
        }
        public string DisplayMonthlyKPI()
        {
            var Projects = db.Projects.ToList();
            int KPISum = 0;
            int Counter = 0;
            foreach (var item in Projects)
            {
                if (!item.IsDeleted)
                {


                    var temp = CalculateMonthlyKPIForProject(item.Id).ToList();
                    if (temp.Count() > 0)
                    {
                        KPISum += temp[0];
                        Counter += temp[1];
                    }
                }
            }
            if (Counter > 0)
            {
                double KPI = Math.Round((KPISum / (double)Counter), 2);
                return KPI.ToString("#0.##%");
            }
            else return "No Active Data";
        }
        public List<Projects> DisplayFinishedProjectsFromPreviousQuarter()
        {
            List<Projects> finishedProjectList = new List<Projects>();
            List<Projects> projectList = db.Projects.ToList();
            List<int> q1 = new List<int> { 10, 11, 12 };
            List<int> q2 = new List<int> { 1, 2, 3 };
            List<int> q3 = new List<int> { 4, 5, 6 };
            List<int> q4 = new List<int> { 7, 8, 9 };

            int currentMonth = DateTime.Now.Month;
            List<int> prevoiusQuarter;
            List<int> prevoiusPrivoiusQuarter;
            if (q1.Contains(currentMonth))
            {
                prevoiusQuarter = q4;
                prevoiusPrivoiusQuarter = q3;
            }
            else if (q2.Contains(currentMonth))
            {
                prevoiusQuarter = q1;
                prevoiusPrivoiusQuarter = q4;
            }
            else if (q3.Contains(currentMonth))
            {
                prevoiusQuarter = q2;
                prevoiusPrivoiusQuarter = q1;
            }
            else
            {
                prevoiusQuarter = q3;
                prevoiusPrivoiusQuarter = q2;
            }

            DateTime date = new DateTime();

            foreach (var item in projectList)
            {
                if (item.G4 != null)
                {
                    date = (DateTime)item.G4;

                    string progressString = item.ProgressString;

                    if (progressString == null) progressString = "";

                    if (progressString.Contains("G4") && prevoiusQuarter.Contains(date.Month))
                    {
                        finishedProjectList.Add(item);
                    }
                    else if (progressString.Contains("G4") && prevoiusPrivoiusQuarter.Contains(date.Month))
                    {
                        db.Projects.Remove(db.Projects.First(c => c.Id == item.Id));
                        db.SaveChanges();
                    }
                }
            }

            return finishedProjectList;
        }
        private List<string> StringToList(string listString)
        {

            return listString.Split(',').ToList();
        }
        private string ListToString(List<string> stringList)
        {
            string listString="";
            foreach (var item in stringList)
            {
                listString += item + ",";
            }
            return listString;
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
