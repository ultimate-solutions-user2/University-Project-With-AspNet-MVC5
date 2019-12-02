using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unvirsity_System.Models;
//using SearchSortPaging.Models;
namespace Unvirsity_System.Controllers
{
    public class FacultyController : Controller
    {
        // GET: Faculty
        ApplicationDbContext context = new ApplicationDbContext();
        public ActionResult Index(int option )
        {
       var q = context.Faculities.Where(f => f.branch_ID == option).ToList();
                return View(q);
    
       
        }
        public ActionResult details(int id)
        {
            var q = context.Faculities.Where(f => f.ID == id).FirstOrDefault();
            return View(q);
        }
        public ActionResult ShowAllFaculty(string optionFac,string optionCost, string search, string costsearch)
        {
        
           if (optionCost == "true" && optionFac == "false")
            {
                return View(context.Faculities.Where(x => x.Costs.ToString() == costsearch || search == null && costsearch == null).ToList());
            }
            else if  (optionCost == "true" && optionFac == "true")
            {
                return View(context.Faculities.Where(x => (x.Costs.ToString() == costsearch && x.Name.StartsWith(search) || search == null)).ToList());
            }
           else
            {
                return View(context.Faculities.Where(x => x.Name.StartsWith(search) || search == null&& costsearch == null).ToList());
            }
            
        }
        /////wafff
        public ActionResult department(int id)
        {
            var faclties = context.Departments.Where(i => i.Faculty_ID == id).ToList();
            return View(faclties);
        }
        public ActionResult back(int id)
        {
            var depts = context.Departments.Where(u => u.ID == id).ToList();
            var q = context.Faculities.Where(f => f.Departments == depts).ToList();
            return View("Index", q);
        }

        //wafaa
        public ActionResult goback(int id)
        {
            var depts = context.Departments.Where(u => u.ID == id).FirstOrDefault();
            var facid = depts.Faculty_ID;
            List<Faculty> faculties = context.Faculities.Where(k => k.ID == facid).ToList();
            return View("Index", faculties);


        }
    }
}