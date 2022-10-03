using FacultyInformationSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FacultyInformationSystem.Controllers
{
    public class FacultyController : Controller
    {
        private readonly FDBContext _dbContext;
        public FacultyController(FDBContext dbContext)
        {
        
            _dbContext = dbContext;
        }

        public IActionResult FacultyLogin()
        {
            return View();
        }

        [HttpGet]
        public ActionResult UpdateFacultyInfo()
        {
            return View();
        }
        [HttpPatch]
        public ActionResult UpdateFacultyInfo(Faculty model, int id)
        {
            var data = _dbContext.Faculties.Where(x => x.FacultyId == id).FirstOrDefault();
            _dbContext.Faculties.Update(model);
            _dbContext.SaveChanges();
            ViewBag.Message = "Data Updated Successfully";
            return RedirectToAction("FacultyLogin");
        }
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
            return RedirectToAction("FacultyLogin");
        }

        [HttpGet]
        public ActionResult CreatePublications()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreatePublications(Publication model)
        {
            _dbContext.Publications.Add(model);
            _dbContext.SaveChanges();
            ViewBag.Message = "Data Insert Successfully";
            return RedirectToAction("FacultyLogin");
        }

        [HttpGet]
        public ActionResult UpdatePublications(int id)
        {
            var data = _dbContext.Publications.Where(x => x.PublicationId == id).FirstOrDefault();
            return View(data);
        }

        [HttpPost]
        public ActionResult UpdatePublications(Publication Model)
        {
            var data = _dbContext.Publications.Where(x => x.PublicationId == Model.PublicationId).FirstOrDefault();
            if (data != null)
            {
                data.PublicationTiltle = Model.PublicationTiltle;
                data.ArticleName = Model.ArticleName;
                data.PublisherName = Model.PublisherName;
                data.PublicationLocation = Model.PublicationLocation;
                data.CitationDate = Model.CitationDate;
                _dbContext.SaveChanges();
            }

            return RedirectToAction("FacultyLogin");
        }


        [HttpGet]
        public ActionResult FacultyCredentials(int id)
        {
            var data = _dbContext.Users.Where(x => x.UserId == id).FirstOrDefault();
            return View(data);
        }

        [HttpPatch]
        public ActionResult FacultyCredentials(User Model)
        {
            var data = _dbContext.Users.Where(x => x.UserId == Model.UserId).FirstOrDefault();
            if (data != null)
            {
                _dbContext.Users.Update(Model);
                _dbContext.SaveChanges();
            }

            return RedirectToAction("FacultyLogin");
        }
    }
}
