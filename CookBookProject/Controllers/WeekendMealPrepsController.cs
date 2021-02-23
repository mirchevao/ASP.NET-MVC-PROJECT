using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CookBookProject.Models;

namespace CookBookProject.Controllers
{
    public class WeekendMealPrepsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: WeekendMealPreps
        public ActionResult Index()
        {
            var weekendMealPreps = db.WeekendMealPreps.Include(w => w.recipeType);
            return View(weekendMealPreps.ToList());
        }

        // GET: WeekendMealPreps/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WeekendMealPrep weekendMealPrep = db.WeekendMealPreps.Find(id);
            if (weekendMealPrep == null)
            {
                return HttpNotFound();
            }
            return View(weekendMealPrep);
        }

        // GET: WeekendMealPreps/Create
        public ActionResult Create()
        {
            ViewBag.recipeTypeId = new SelectList(db.RecipeTypes, "RecipeTypeId", "Name");
            return View();
        }

        // POST: WeekendMealPreps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,recipeTypeId,Name,Ingredients,Description,Rating,ImgURL")] WeekendMealPrep weekendMealPrep)
        {
            if (ModelState.IsValid)
            {
                db.WeekendMealPreps.Add(weekendMealPrep);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.recipeTypeId = new SelectList(db.RecipeTypes, "RecipeTypeId", "Name", weekendMealPrep.recipeTypeId);
            return View(weekendMealPrep);
        }

        // GET: WeekendMealPreps/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WeekendMealPrep weekendMealPrep = db.WeekendMealPreps.Find(id);
            if (weekendMealPrep == null)
            {
                return HttpNotFound();
            }
            ViewBag.recipeTypeId = new SelectList(db.RecipeTypes, "RecipeTypeId", "Name", weekendMealPrep.recipeTypeId);
            return View(weekendMealPrep);
        }

        // POST: WeekendMealPreps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,recipeTypeId,Name,Ingredients,Description,Rating,ImgURL")] WeekendMealPrep weekendMealPrep)
        {
            if (ModelState.IsValid)
            {
                db.Entry(weekendMealPrep).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.recipeTypeId = new SelectList(db.RecipeTypes, "RecipeTypeId", "Name", weekendMealPrep.recipeTypeId);
            return View(weekendMealPrep);
        }

        // GET: WeekendMealPreps/Delete/5
       
        public ActionResult Delete(int id)
        {
            WeekendMealPrep weekendMealPrep = db.WeekendMealPreps.Find(id);
            db.WeekendMealPreps.Remove(weekendMealPrep);
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
