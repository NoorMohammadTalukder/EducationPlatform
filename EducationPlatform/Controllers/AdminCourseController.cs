using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EducationPlatform.Auth;
using EducationPlatform.Models;

namespace EducationPlatform.Controllers
{
    [AdminLogged]
    public class AdminCourseController : Controller
    {
        // GET: AdminCourse
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]

        [AdminLogged]
        public ActionResult AddCourse()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCourse(Cours obj)
        {
            var db=new EducationPlatformEntities();
            if (ModelState.IsValid)
            {
                var course = new Cours()
                {
                    Name = obj.Name,
                    Details = obj.Details,
                    Price = obj.Price,
                    Duration = obj.Duration,
                    Photo = obj.Photo,
                    InstitutionId = obj.InstitutionId,
                    MentorId = obj.MentorId,


                };
                // var course = db.Courses;

                db.Courses.Add(obj);
                db.SaveChanges();
                return RedirectToAction("Index", "Admin");
            }

            return View(obj);
                
        }

        public ActionResult CourseList()
        {
            var db = new EducationPlatformEntities();
            var courseList = db.Courses.ToList();
            return View(courseList);
        }

        public ActionResult SingleCourseList(int id)
        {
            var db = new EducationPlatformEntities();
            var course = (from i in db.Courses where i.Id == id select i).FirstOrDefault();
            return View(course);
        }

        [HttpGet]
        public ActionResult CourseUpdate(int id)
        {
            var db = new EducationPlatformEntities();
            var course = (from i in db.Courses where i.Id == id select i).FirstOrDefault();
            return View(course);
        }

        [HttpPost]
        public ActionResult CourseUpdate(Cours obj)
        {
            var db = new EducationPlatformEntities();
            if (ModelState.IsValid)
            {
                var course = (from i in db.Courses
                              where i.Id == obj.Id
                              select i).FirstOrDefault();
                //db.Entry(institution).CurrentValues.SetValues(obj);
                course.Name = obj.Name;
                course.Details = obj.Details;
                course.Price = obj.Price;
                course.Duration = obj.Duration;
                course.Photo = obj.Photo;
                course.InstitutionId = obj.InstitutionId;
                course.MentorId = obj.MentorId;


                db.SaveChanges();
                return RedirectToAction("CourseList");
            }
            return View(obj);
               
        }


    }
}