using FacultyInformationSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FacultyInformationSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly FDBContext _dbContext;
        public HomeController(FDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            return View();
        }

       [HttpGet]
        public ActionResult ViewDepartments()
        {

            return View(_dbContext.Departments.ToList());
        }
        [HttpGet]
        public ActionResult ViewCourses()
        {

            return View(_dbContext.Courses.ToList());
        }
        [HttpGet]
        public ActionResult ViewSubjects()
        {

            return View(_dbContext.Subjects.ToList());
        }
        [HttpGet]
        public ActionResult ViewPublications()
        {

            return View(_dbContext.Publications.ToList());
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
