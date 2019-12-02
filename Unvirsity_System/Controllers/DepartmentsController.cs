 using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Unvirsity_System.Models;

namespace Unvirsity_System.Controllers
{
    public class DepartmentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Departments
        //public ActionResult Index()
        //{
        //    var d=db.Departments.Include(K=>K.)
                
        //    var departments = db.Departments.Include(d =>d.Faculity);
        //    return View(departments.ToList());
        //}

        // GET: Departments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departments departments = db.Departments.Find(id);
            if (departments == null)
            {
                return HttpNotFound();
            }
            return View(departments);
        }

        public ActionResult courses(int id)
        {
           // var dept = db.Departments.Where(i => i.ID == id).ToList();
            var cors = db.Courses.Where(i => i.Departments_ID == id).ToList();
            // var courese = db.Courses.Where(c=>c.ID==dept.).ToList();
            return View("courss", cors);
        }
        public ActionResult goooback(int id)
        {

            var crs = db.Courses.Where(h => h.ID == id).FirstOrDefault();
            var dptid = crs.Departments_ID;
            var crss = db.Courses.Where(k => k.Departments_ID == dptid).ToList();

            return View("courss", crss);


        }

        public ActionResult gooback(int id)
        {

            var prof = db.Professors.Where(i => i.ID == id).FirstOrDefault();


            return View("courses", prof.Course);

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
