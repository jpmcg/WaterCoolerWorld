using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WaterCoolerWorld.Models;

namespace WaterCoolerWorld.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            var testimonials = db.Testimonials.ToList();
           /* var testimonials = new List<Testimonial>();
            testimonials.Add(new Testimonial
            {
                Quote = "Our staff love the water coolers we got from Water Cooler World",
                CustomerName = "Joe Bloggs"
            });
            testimonials.Add(new Testimonial
            {
                Quote = "Water Cooler Worlds quick delivery means we never go thirsty!",
                CustomerName = "Joe Bloggs"
            });*/
            return View("Index", testimonials);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}