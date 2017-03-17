using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WaterCoolerWorld.Models;

namespace WaterCoolerWorld.Controllers
{
    public class CoolersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Coolers
        public ActionResult Index()
        {
            return View(db.Coolers.ToList());
        }

        public ActionResult Bottle()
        {
            var coolers = db.Coolers.Where(c=>c.Categrory==CoolerCatergory.BottleCooler).ToList();
            GetImages(coolers);
            return View("BottleSection", coolers);
        }

        public ActionResult Mains()
        {
            var coolers = db.Coolers.Where(c => c.Categrory == CoolerCatergory.MainsCooler).ToList();
            GetImages(coolers);
            return View("MainsSection", coolers);
        }

        public ActionResult Coffee()
        {
            var coolers = db.Coolers.Where(c => c.Categrory == CoolerCatergory.CoffeeMachine).ToList();
            GetImages(coolers);
            return View("CoffeeSection", coolers);
        }

        public Cooler GetImageForCooler(Cooler cooler)
        {
            var images = db.Images.Where(i => i.CoolerId == cooler.Id).ToList();
            cooler.Image = images.Count > 0 ? images[0] : new WcwImage { Name = "defaultCooler.png" };
            return cooler;
        }

        private void GetImages(List<Cooler> coolers)
        {
            foreach (var cooler in coolers)
            {
                var images = db.Images.Where(i => i.CoolerId == cooler.Id).ToList();
                cooler.Image = images.Count > 0 ? images[0] : new WcwImage { Name = "defaultCooler.png" };
            }
        }

        public ActionResult Cooler(int id)
        {
            var cooler = db.Coolers.First(c => c.Id == id);
            cooler = GetImageForCooler(cooler);
         //  var images = db.Images.Where(i => i.CoolerId == id).ToList();
          //  cooler.Image = images.Count > 0 ? images[0] : new WcwImage {Name = "defaultCooler.png"};
            return View("Item", cooler);
        }

        // GET: Coolers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cooler cooler = db.Coolers.Find(id);
            if (cooler == null)
            {
                return HttpNotFound();
            }
            return View(cooler);
        }

        // GET: Coolers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Coolers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Categrory,ShortDescription,FullDescription,Price")] Cooler cooler)
        {
            if (ModelState.IsValid)
            {
                db.Coolers.Add(cooler);
                db.SaveChanges();
                return RedirectToAction("AddImage", new {id = cooler.Id});
            }

            return View(cooler);
        }

        // GET: Coolers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cooler cooler = db.Coolers.Find(id);
            if (cooler == null)
            {
                return HttpNotFound();
            }
            return View(cooler);
        }

        // POST: Coolers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Categrory,ShortDescription,FullDescription,Price")] Cooler cooler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cooler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cooler);
        }

        // GET: Coolers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cooler cooler = db.Coolers.Find(id);
            if (cooler == null)
            {
                return HttpNotFound();
            }
            return View(cooler);
        }

        // POST: Coolers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cooler cooler = db.Coolers.Find(id);
            db.Coolers.Remove(cooler);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult AddImage(int id)
        {
            ViewBag.CoolerId = id;
            return View("~/Views/Images/Add.cshtml", id);
        }

        [HttpPost]
        public ActionResult AddImage(FormCollection form)
        {
            var file = Request.Files["file"];
            var coolerId = Request.Form["coolerId"];
            if (file != null && !string.IsNullOrEmpty(coolerId) && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Images"), fileName);
                int count = 1;
                while (System.IO.File.Exists(path))
                {
                    fileName = count + fileName;
                    path = Path.Combine(Server.MapPath("~/Images"), fileName);
                    count++;
                }
                
                file.SaveAs(path);
                var image = new WcwImage
                {
                    Name = fileName,
                    CoolerId = Int16.Parse(coolerId)
                };
                db.Images.Add(image);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
           // return RedirectToAction("AddImage", new {id = coolerId});
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
