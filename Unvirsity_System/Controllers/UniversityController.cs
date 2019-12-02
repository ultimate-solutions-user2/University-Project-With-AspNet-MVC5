using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unvirsity_System.Models;

namespace Unvirsity_System.Controllers
{
    public class UnversityController : Controller
    {
        // GET: Unversity
        ApplicationDbContext context = new ApplicationDbContext();

        //public ActionResult Index(string search)
        //{
        //    if(search == null)
        //    {
        //        return View(context.Universities.ToList());
        //    }
        //   else
        //    {

        //        var q =
        //         context.Universities.Where(u => u.Name.Contains(search)).ToList();
        //        return View(q);
        //    }
        //}
        ///////////////////////////
        public ActionResult getLocation(int id)
        {
            var l = context.Locations.FirstOrDefault(f => f.university_ID == id);
            return View(l);
        }





        public ActionResult Index(string option, string search)
        {
           
            if (option== "Location")
            {
             if(search=="")
                {
                    return View(context.Universities.ToList());
                }
             else
                { 
               List<University> universities = new List<University>();
        var q = context.Branches.Where(x => x.Name.StartsWith(search)).Select(x => x.university_ID).ToList();
                foreach (var item in q)
                {
                   var w= context.Universities.Where(x => x.ID == item).FirstOrDefault();
                    universities.Add(w);
                }
                // var b = context.Universities.Select(x => x.Branches).ToList();
                //return View(context.Universities.Where(x=>x.Branches.Select(y=>y.university_ID).ToList()==q|| search == null && Locsearch == null).ToList());
                return View(universities);
                }
            }
           
            else
            {
                return View(context.Universities.Where(x => x.Name.StartsWith(search) || search == null).ToList());
            }

        }
    }
}