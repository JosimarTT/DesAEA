using Lab11.Models;
using Lab11_Domain;
using Lab11_Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab11.Controllers
{
    public class StudentController : Controller
    {
        private StudentService service = new StudentService();
        // GET: Student
        public ActionResult IndexRazor()
        {
            var model = (from c in service.Get()
                         select new StudentModel
                         {
                             ID = c.studentID,
                             Name = c.studentName,
                             Address = c.studentAddress
                         }).ToList();
            return View(model);
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetStudent(string id)
        {
            return Json(service.Get(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult CreateStudent(Student student)
        {
            student.CreatedDate = DateTime.Now;
            service.Insert(student);
            string message = "SUCCESS";
            return Json(new { Message = message, JsonRequestBehavior.AllowGet});
        }
    }
}