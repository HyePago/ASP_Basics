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
            ViewBag.bFail = 0;

            return View();
        }
        [HttpPost]
        public ActionResult Index(string aID, string aPW)
        {
            ViewBag.theUsers = CInstance.theUserManager.GetUsers();

            CUser resUser;

            int tmpBool = CInstance.theUserManager.CheckUser(aID, aPW, out resUser);

            if(tmpBool == 1)
            {
                // 로그인 성공
                Session["id"] = aID;
                Session["user"] = resUser;

                return RedirectToAction("Main");
            }
            else
            {
                ViewBag.bFail = 1;
            }

            return View();
        }

        public ActionResult Main()
        {
            if(Session["id"] == null)
            {
                return RedirectToAction("index");
            }

            CUser tmpUser = (CUser)Session["user"];

            ViewBag.theID = tmpUser.theID;
            ViewBag.theDate = tmpUser.theDate.ToString("yyyy.MM.dd");

            return View();
        }

        public ActionResult Join()
        {
            ViewBag.bFail = 0;

            return View();
        }
        [HttpPost]
        public ActionResult Join(CUser aUser)
        {
            if (!ModelState.IsValid)
            {
                return View(aUser);
            }

            int tmpBool;
            tmpBool = CInstance.theUserManager.AddUser(ref aUser);

            if(tmpBool == 1)
            {
                return RedirectToAction("JoinOK", aUser);
            }

            ViewBag.bFail = 1;

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