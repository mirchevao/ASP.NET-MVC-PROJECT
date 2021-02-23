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
    public class LowCarbMealsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: LowCarbMeals
        public ActionResult Index()
        {
            var lowCarbMeals = db.LowCarbMeals.Include(l => l.recipeType);
            return View(lowCarbMeals.ToList());
        }

        // GET: LowCarbMeals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LowCarbMeals lowCarbMeals = db.LowCarbMeals.Find(id);
            if (lowCarbMeals == null)
            {
                return HttpNotFound();
            }
            return View(lowCarbMeals);
        }

        // GET: LowCarbMeals/Create
        public ActionResult Create()
        {
            ViewBag.recipeTypeId = new SelectList(db.RecipeTypes, "RecipeTypeId", "Name");
            return View();
        }

        // POST: LowCarbMeals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,recipeTypeId,Name,Ingredients,Description,Rating,ImgURL")] LowCarbMeals lowCarbMeals)
        {
            if (ModelState.IsValid)
            {
                db.LowCarbMeals.Add(lowCarbMeals);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.recipeTypeId = new SelectList(db.RecipeTypes, "RecipeTypeId", "Name", lowCarbMeals.recipeTypeId);
            return View(lowCarbMeals);
        }

        // GET: LowCarbMeals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LowCarbMeals lowCarbMeals = db.LowCarbMeals.Find(id);
            if (lowCarbMeals == null)
            {
                return HttpNotFound();
            }
            ViewBag.recipeTypeId = new SelectList(db.RecipeTypes, "RecipeTypeId", "Name", lowCarbMeals.recipeTypeId);
            return View(lowCarbMeals);
        }

        // POST: LowCarbMeals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,recipeTypeId,Name,Ingredients,Description,Rating,ImgURL")] LowCarbMeals lowCarbMeals)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lowCarbMeals).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.recipeTypeId = new SelectList(db.RecipeTypes, "RecipeTypeId", "Name", lowCarbMeals.recipeTypeId);
            return View(lowCarbMeals);
        }

        // GET: LowCarbMeals/Delete/5
       
        public ActionResult Delete(int id)
        {
            LowCarbMeals lowCarbMeals = db.LowCarbMeals.Find(id);
            db.LowCarbMeals.Remove(lowCarbMeals);
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
