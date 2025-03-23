using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineQuizSystem.EF;
using OnlineQuizSystem.DTOs;

namespace TRPManagement.Controllers
{
    public class LoginController : Controller
    {
        OnlineQuizSystemEntities1 db = new OnlineQuizSystemEntities1();

        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View(new LoginDTO());
        }
        [HttpPost]
        public ActionResult Index(LoginDTO log)
        {
            if (ModelState.IsValid)
            {
                var user = (from u in db.Users
                            where u.Name == log.Name
                            && u.Password == log.Password
                            select u).SingleOrDefault();
                if (user != null)
                {
                    Session["user"] = user;
                    return RedirectToAction("List", "Quiz");
                }

            }
            return View(log);
        }
    }
}