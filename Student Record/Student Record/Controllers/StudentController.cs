using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Student_Record.Models;

namespace Student_Record.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        StudentModel stu = new StudentModel();
        public ActionResult Index()
        {
            return View(stu.Get());
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(FormCollection form)
        {
            stu.ID = long.Parse(form["ID"]);
            stu.Delete();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(long StudentID)
        {
            stu.ID = StudentID;
            return View(stu.GetStudent());
        }

        [HttpPost]
        public ActionResult Save(FormCollection form)
        {
            stu.ID = long.Parse(form["ID"]);
            stu.Lastname = form["Lastname"];
            stu.Firstname = form["Firstname"];
            stu.Year = int.Parse(form["Year"]);
            stu.Course = form["Course"];
            stu.Add();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Update(FormCollection form)
        {
            stu.ID = long.Parse(form["ID"]);
            stu.Lastname = form["Lastname"];
            stu.Firstname = form["Firstname"];
            stu.Year = int.Parse(form["Year"]);
            stu.Course = form["Course"];
            stu.Update();

            return RedirectToAction("Index");

        }
    }
}