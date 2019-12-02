using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Unvirsity_System.Models;

namespace Unvirsity_System.Controllers
{
   [Authorize (Roles ="user")]
   // [Authorize]
    public class Submit_StudentController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Submit_Student
        public ActionResult Index()
        {
            var submit_Students = db.Submit_Students.Include(s => s.Faculity);
            return View(submit_Students.ToList());
        }

        // GET: Submit_Student/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Submit_Student submit_Student = db.Submit_Students.Find(id);
            if (submit_Student == null)
            {
                return HttpNotFound();
            }
            return View(submit_Student);
        }

        // GET: Submit_Student/Create
        public ActionResult Create()
        {
            ViewBag.Faculty_ID = new SelectList(db.Faculities, "ID", "Name");
            return View();
        }

        // POST: Submit_Student/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Submit_Student submit_Student)
        {
            var image1 = submit_Student.ImageFile;
        
            if (ModelState.IsValid)
            {
                if (image1 != null)
                {
                    submit_Student.image = new byte[image1.ContentLength];
                    image1.InputStream.Read(submit_Student.image, 0, image1.ContentLength);
                }

                ViewBag.Faculty_ID = new SelectList(db.Faculities, "ID", "Name", submit_Student.Faculty_ID);
                db.Submit_Students.Add(submit_Student);
                db.SaveChanges();
                return RedirectToAction("finishApply");
            }

            return View(submit_Student);
        }
        public ActionResult finishApply()
        {
            return View();
        }

        // GET: Submit_Student/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Submit_Student submit_Student = db.Submit_Students.Find(id);
            if (submit_Student == null)
            {
                return HttpNotFound();
            }
            ViewBag.Faculty_ID = new SelectList(db.Faculities, "ID", "Name", submit_Student.Faculty_ID);
            return View(submit_Student);
        }

        // POST: Submit_Student/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,The_name_is_quadrant,Total_General_Secondary_Degrees,Address,Telephon,graduation_certificate,Faculty_ID")] Submit_Student submit_Student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(submit_Student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Faculty_ID = new SelectList(db.Faculities, "ID", "Name", submit_Student.Faculty_ID);
            return View(submit_Student);
        }

        // GET: Submit_Student/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Submit_Student submit_Student = db.Submit_Students.Find(id);
            if (submit_Student == null)
            {
                return HttpNotFound();
            }
            return View(submit_Student);
        }

        // POST: Submit_Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Submit_Student submit_Student = db.Submit_Students.Find(id);
            db.Submit_Students.Remove(submit_Student);
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
