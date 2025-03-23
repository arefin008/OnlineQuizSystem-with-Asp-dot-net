using OnlineQuizSystem.EF;
using OnlineQuizSystem.DTOs;
using OnlineQuizSystem.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineQuizSystem.Controllers
{
    [Logged]
    public class QuizController : Controller
    {
        OnlineQuizSystemEntities1 db = new OnlineQuizSystemEntities1();

        public static Quizze Convert(QuizzeDTO d)
        {
            return new Quizze
            {
                Id = d.Id,
                Title = d.Title,
                Description = d.Description,
                Date = d.Date
              

            };
        }
        public static QuizzeDTO Convert(Quizze d)
        {
            return new QuizzeDTO
            {
                Id = d.Id,
                Title = d.Title,
                Description = d.Description,
                Date = d.Date
            };
        }
        public static List<QuizzeDTO> Convert(List<Quizze> data)
        {
            var list = new List<QuizzeDTO>();
            foreach (var d in data)
            {
                list.Add(Convert(d));
            }
            return list;
        }
        [AllowAnonymous]
        [ParticipantAccess]
        public ActionResult List()
        {
            var data = db.Quizzes.ToList();
            return View(Convert(data));
        }
        [AdminAccess]
        [HttpGet]
        public ActionResult Create()
        {
            return View(new Quizze());
        }
        [HttpPost]
        public ActionResult Create(QuizzeDTO d)
        {
            if (ModelState.IsValid)
            {
                db.Quizzes.Add(Convert(d));
                db.SaveChanges();
                return RedirectToAction("List");
            }
            return View(d);
        }
        [AdminAccess]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var exobj = db.Quizzes.Find(id);
            return View(Convert(exobj));
        }

        [HttpPost]
        public ActionResult Edit(QuizzeDTO d)
        {
            var exobj = db.Quizzes.Find(d.Id);
            db.Entry(exobj).CurrentValues.SetValues(d);
            db.SaveChanges();
            return RedirectToAction("List");
        }
        [AdminAccess]
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var exobj = db.Quizzes.Find(id);
            return View(Convert(exobj));
        }
        [HttpPost]
        public ActionResult Delete(int Id, string dcsn)
        {
            if (dcsn.Equals("yes"))
            {
                var exobj = db.Quizzes.Find(Id);
                db.Quizzes.Remove(exobj);
                db.SaveChanges();
            }
            return RedirectToAction("List");
        }
    }
}