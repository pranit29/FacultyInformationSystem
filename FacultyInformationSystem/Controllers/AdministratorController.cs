using FacultyInformationSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.Data.SqlClient;

namespace FacultyInformationSystem.Controllers
{
    public class AdministratorController : Controller
    {
        private readonly FDBContext _dbContext;
        public AdministratorController(FDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult AdminLogin()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CreateFaculty()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateFaculty(Faculty model)
        {
            
          
     
            User Umodel = new User() { Email = model.Email,
                                       Password = model.FirstName + "@Pass" + model.FacultyId.ToString(),
                                       UserType = 2 };
       
           ;
            _dbContext.Faculties.Add(model);
            _dbContext.Users.Add(Umodel);
            _dbContext.SaveChanges();
           

            ViewBag.Message = "Data Insert Successfully";
            return RedirectToAction("AdminLogin");
        }


        
          

        // *********************Add Department***********************
        [HttpGet]
        public ActionResult CreateDepartment()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateDepartment(Department model)
        {
            _dbContext.Departments.Add(model);
            _dbContext.SaveChanges();
            ViewBag.Message = "Data Insert Successfully";
            return RedirectToAction("AdminLogin");
        }

        // *********************Add Designation***********************
        [HttpGet]
        public ActionResult CreateDesignation()
        {
            return View();
        }
    
        [HttpPost]
        public ActionResult CreateDesignation(Designation model)
        {
            _dbContext.Designations.Add(model);
            _dbContext.SaveChanges();
            ViewBag.Message = "Data Insert Successfully";
            return RedirectToAction("AdminLogin");
        }
        // *********************Add Grants***********************
        [HttpGet]
        public ActionResult CreateGrants()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateGrants(Grant model)
        {
            _dbContext.Grants.Add(model);
            _dbContext.SaveChanges();
            ViewBag.Message = "Data Insert Successfully";
            return RedirectToAction("AdminLogin");
        }
        // *********************Create Subjects***********************
        [HttpGet]
        public ActionResult CreateSubject()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateSubject(Subject model)
        {
            _dbContext.Subjects.Add(model);
            _dbContext.SaveChanges();
            ViewBag.Message = "Data Insert Successfully";
            return RedirectToAction("AdminLogin");
        }

        // *********************Add Grants***********************
        [HttpGet]
        public ActionResult CreateCourse()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCourse(Course model)
        {
            _dbContext.Courses.Add(model);
            _dbContext.SaveChanges();
            ViewBag.Message = "Data Insert Successfully";
            return RedirectToAction("AdminLogin");
        }

        // *********************Update Course***********************
        [HttpGet]
        public ActionResult UpdateCourse(int id)
        {
            var data = _dbContext.Courses.Where(x => x.CourseId == id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult UpdateCourse(Course Model)
        {
            var data = _dbContext.Courses.Where(x => x.CourseId == Model.CourseId).FirstOrDefault();
            if (data != null)
            {
                data.CourseName = Model.CourseName;
                data.CourseCredits = Model.CourseCredits;
                _dbContext.SaveChanges();
            }

            return RedirectToAction("AdminLogin"); ;
        }

        // *********************Update Subject***********************
        [HttpGet]
        public ActionResult UpdateSubject(int id)
        {
            var data = _dbContext.Subjects.Where(x => x.SubjectId == id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult UpdateSubject(Subject Model)
        {
            var data = _dbContext.Subjects.Where(x => x.SubjectId == Model.SubjectId).FirstOrDefault();
            if (data != null)
            {
                data.SubjectName = Model.SubjectName;
                _dbContext.SaveChanges();

            }
            return RedirectToAction("AdminLogin");
        }


        // ********************Delete Subject***********************
        [HttpGet]
        public ActionResult DeleteSubject(int id)
        {
            var data = _dbContext.Subjects.Where(x => x.SubjectId == id).FirstOrDefault();
            return View(data);
        }

        [HttpPost]
        public ActionResult DeleteSubject(int id, Subject Model)
        {
            var data = _dbContext.Subjects.Where(x => x.SubjectId == Model.SubjectId).FirstOrDefault();
            _dbContext.Subjects.Remove(data);
            _dbContext.SaveChanges();
            ViewBag.Messsage = "Record Delete Successfully";
            return RedirectToAction("AdminLogin");
        }




        // ********************Delete Course***********************
        [HttpGet]
        public ActionResult DeleteCourse(int id)
        {
            var data = _dbContext.Courses.Where(x => x.CourseId == id).FirstOrDefault();
            return View(data);
        }
        public ActionResult DeleteCourse(int id, Course Model)
        {
            var data = _dbContext.Courses.Where(x => x.CourseId == Model.CourseId).FirstOrDefault();
            _dbContext.Courses.Remove(data);
            _dbContext.SaveChanges();
            ViewBag.Messsage = "Record Delete Successfully";
            return RedirectToAction("AdminLogin");
        }


    }
}
