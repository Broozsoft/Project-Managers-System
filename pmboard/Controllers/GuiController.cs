using Microsoft.AspNet.SignalR;
using Newtonsoft.Json;
using pmboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace pmboard.Controllers
{
    public class GuiController : Controller
    {
        // GET: Gui
        public ActionResult Index()
        {
          
            return View();
        }

        //public ActionResult notificationLayout()
        //{
        //    return PartialView();
        //}

        public ActionResult ChangeUserModal()
        {
            List<Projectmanagers> projectManagers = new List<Projectmanagers>();
            using (DbEntities Db=new DbEntities())
            {
                projectManagers = Db.Projectmanagers.ToList();
            }
                return PartialView(projectManagers);
        }

        public ActionResult ChangeUser(int?id)
        {
            Projectmanagers currentUser=new Projectmanagers();
            using(DbEntities Db=new DbEntities())
            {
                currentUser = Db.Projectmanagers.Find(id);
            }

            //Session["CurrentUserId"] = currentUser.ID;
            //Session["CurrentUserName"] = currentUser.Name;
            Session["ProjectManager"] = new Projectmanagers { ID = currentUser.ID, Name = currentUser.Name };

            return RedirectToAction("Index");
        }
    }
}