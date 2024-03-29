﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CMS.Models;

namespace CMS.Controllers
{
    public class CoursesController : Controller
    {
        private CMSContext db = new CMSContext();

        // Loading the View
        public ActionResult Index()
        {
            return View();
        }

        //Get all courses
        //GET : Courses/GetAllCourses
        public JsonResult GetAllCourses()
        {
            var courseList = db.Courses.ToList();
            return Json(courseList, JsonRequestBehavior.AllowGet);
        }

        // Loading the View for details
        public ActionResult Details()
        {
            return View();
        }

        // Get details of the course
        // GET: Courses/Details/5
        public JsonResult GetDetailsById(int? id)
        {
            if (id == null)
            {
                return Json(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return Json(HttpNotFound());
            }
            return Json(course, JsonRequestBehavior.AllowGet);
        }

        // Load view for create new course
        // GET: Courses/Create
        public ActionResult Create()
        {
            return View();
        }

        // Create new course
        // POST: Courses/Create
        [HttpPost]
        public JsonResult CreateCourse([Bind(Include = "Course_Id,Course_Name,Course_Status")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Courses.Add(course);
                db.SaveChanges();
            }

            return Json(course, JsonRequestBehavior.AllowGet);
        }

        // Load view for Edit
        public ActionResult Edit()
        {
            return View();
        }

        

        // Update Course details
        // POST: Courses/Edit/5
        [HttpPost]
        public JsonResult UpdateCourse([Bind(Include = "Course_Id,Course_Name,Course_Status")] Course course)
        {

            var updatedCourse = new Course
            {
                Course_Id = Convert.ToInt32(course.Course_Id),
                Course_Name = course.Course_Name,
                Course_Status = Convert.ToInt32(course.Course_Status)
            };

            if (ModelState.IsValid)
            {
                db.Entry(updatedCourse).State = EntityState.Modified;
                db.SaveChanges();
            }
            return Json(course, JsonRequestBehavior.AllowGet);
        }

        // Load course delete view
        // GET: Courses/Delete/5
        public ActionResult Delete()
        {
            return View();
        }

        // Delete course
        public JsonResult DeleteById(int? id)
        {
            var idInt = Convert.ToInt32(id);
            if (id == null)
            {
                return Json(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(idInt);
            db.Courses.Remove(course);
            db.SaveChanges();
            return Json("Done");
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
