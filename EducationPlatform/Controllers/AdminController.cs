﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EducationPlatform.Auth;
using EducationPlatform.Models;

namespace EducationPlatform.Controllers
{
    [AdminLogged]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            var db = new EducationPlatformEntities();

            ViewBag.totalStudents=(from i in db.Students
                         where i.Id>0 select i).Count();

            ViewBag.totalCourses = (from i in db.Courses
                               where i.Id > 0
                               select i).Count();
            ViewBag.totalMentors = (from i in db.Mentors
                                    where i.Id > 0
                                    select i).Count();

            ViewBag.totalInstitutes = (from i in db.Institutions
                                    where i.Id > 0
                                    select i).Count();

            ViewBag.totalPassedStudents = (from i in db.Certificates
                                       where i.Status=="Approved"
                                       select i).Count();


            return View();
        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult AdminLogin(Admin obj)
        {
            //TempData["1"] = obj.Email;
            //TempData["2"] = obj.Password;
            var db = new EducationPlatformEntities();
            var admin = (from i in db.Admins
                         where (i.Email==obj.Email && i.Password==obj.Password)
                         select i).FirstOrDefault();
            if (admin != null)
            {
                Session["Id"] = admin.Id;
                return RedirectToAction("Index");
               
                
            }
            else
            {
                TempData["msg"] = "Wrong Email or Password";
                return View();
            }
        }

        public ActionResult AdminProfile()
        {
            var adminId =Int32.Parse(Session["Id"].ToString());

            var db = new EducationPlatformEntities();
            var admin = (from i in db.Admins where i.Id == adminId select i).FirstOrDefault();
            
            return View(admin);
        }


        [HttpGet]
        public ActionResult AdminUpdate()
        {
            var adminId = Int32.Parse(Session["Id"].ToString());

            var db = new EducationPlatformEntities();
            var admin = (from i in db.Admins where i.Id == adminId select i).FirstOrDefault();

            return View(admin);
        }

        [HttpPost]
        public ActionResult AdminUpdate(Admin obj)
        {
            var adminId = Int32.Parse(Session["Id"].ToString());
            var db = new EducationPlatformEntities();
            var admin = (from i in db.Admins
                               where i.Id == adminId
                         select i).FirstOrDefault();
            //db.Entry(institution).CurrentValues.SetValues(obj);
            admin.Name = obj.Name;
            admin.Address = obj.Address;
            admin.Email = obj.Email;
            admin.Phone = obj.Phone;
            admin.Password = obj.Password;
           


            db.SaveChanges();


            return RedirectToAction("Index");
        }

        public ActionResult AdminLogout()
        {
            Session.RemoveAll();
            return Redirect("AdminLogin");
        }
    }
}