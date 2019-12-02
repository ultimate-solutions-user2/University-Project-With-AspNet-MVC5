using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Unvirsity_System.Models;

namespace Unvirsity_System.Controllers
{
    public class ProfessorsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Professors
        public ActionResult Index()
        {
            return View(db.Professors.ToList());
        }
        public ActionResult prof(int id)
        {
            var crs = db.Courses.Where(k => k.ID == id).FirstOrDefault();
            Course cr = crs;
            var prf = db.Professors.Where(po => po.ID == cr.ID).ToList();
            return View(prf);
        }

        // GET: Professors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Professor professor = db.Professors.Find(id);
            if (professor == null)
            {
                return HttpNotFound();
            }
            return View(professor);
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
