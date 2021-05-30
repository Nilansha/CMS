using System;
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

        // Loading the View
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
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Course_Id,Course_Name,Course_Status")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Courses.Add(course);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(course);
        }

        // Load edit course details view
        // GET: Courses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // Update Course details
        // POST: Courses/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Course_Id,Course_Name,Course_Status")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Entry(course).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(course);
        }

        // Load course delete view
        // GET: Courses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // Delete particular course
        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Course course = db.Courses.Find(id);
            db.Courses.Remove(course);
            db.SaveChanges();
            return RedirectToAction("Index");
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
