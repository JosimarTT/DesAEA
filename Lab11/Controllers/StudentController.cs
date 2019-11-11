using Lab11.Models;
//using Lab11_Domain;
//using Lab11_Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Lab11.Controllers
{
    public class StudentController : Controller
    {
        //private StudentService service = new StudentService();
        //// GET: Student
        //public ActionResult IndexRazor()
        //{
        //    var model = (from c in service.Get()
        //                 select new StudentModel
        //                 {
        //                     ID = c.studentID,
        //                     Name = c.studentName,
        //                     LastName = c.studentLastName,
        //                     Address = c.studentAddress,
        //                     CreatedDate = c.CreatedDate,
        //                     UpdatedDate = c.UpdatedDate
        //                 }).ToList();
        //    return View(model);
        //}

        //public ActionResult Index()
        //{
        //    return View();
        //}

        //public JsonResult GetStudent(string id)
        //{
        //    return Json(service.Get(), JsonRequestBehavior.AllowGet);
        //}

        //[HttpPost]
        //public ActionResult CreateStudent(Student student)
        //{
        //    service.Insert(student);
        //    string message = "SUCCESS";
        //    return Json(new { Message = message, newStudent = student, JsonRequestBehavior.AllowGet});
        //}

        Proxy.StudentProxy proxy = new Proxy.StudentProxy();

        public ActionResult IndexRazor()
        {
            var response = Task.Run(() => proxy.GetStudentAsync());
            return View(response.Result.listado);
        }

        public JsonResult GetStudent(string id)
        {
            var response = Task.Run(() => proxy.GetStudentAsync());
            return Json(response.Result.listado, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult CreateStudent(StudentModel std)
        {
            var response = Task.Run(() => proxy.InsertAsync(std));
            string message = response.Result.Mensaje;
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}