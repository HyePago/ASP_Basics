using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ASP_MVC_기초.Models;

namespace ASP_MVC_기초.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.theUsers = CInstance.theUserManager.GetUsers();

            return View();
        }

        public ActionResult Join()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Join(CUser aUser)
        {
            int tmpBool;
            tmpBool = CInstance.theUserManager.AddUser(ref aUser);

            if(tmpBool == 1)
            {
                return RedirectToAction("JoinOK", aUser);
            }

            return View(aUser);
        }
        public ActionResult JoinOK(CUser aUser)
        {
            ViewBag.theName = aUser.theName;
            ViewBag.theDate = aUser.theDate.ToString("yyyy.MM.dd");

            return View(aUser);
        }
    }
}