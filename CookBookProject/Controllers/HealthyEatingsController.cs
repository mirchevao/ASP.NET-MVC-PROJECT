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
    public class HealthyEatingsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: HealthyEatings
        public ActionResult Index()
        {
            var healthyEatings = db.HealthyEatings.Include(h => h.recipeType);
            return View(healthyEatings.ToList());
        }

        // GET: HealthyEatings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HealthyEating healthyEating = db.HealthyEatings.Find(id);
            if (healthyEating == null)
            {
                return HttpNotFound();
            }
            return View(healthyEating);
        }

        // GET: HealthyEatings/Create
        public ActionResult Create()
        {
            ViewBag.recipeTypeId = new SelectList(db.RecipeTypes, "RecipeTypeId", "Name");
            return View();
        }

        // POST: HealthyEatings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,recipeTypeId,Name,Ingredients,Description,Rating,ImgURL")] HealthyEating healthyEating)
        {
            if (ModelState.IsValid)
            {
                db.HealthyEatings.Add(healthyEating);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.recipeTypeId = new SelectList(db.RecipeTypes, "RecipeTypeId", "Name", healthyEating.recipeTypeId);
            return View(healthyEating);
        }

        // GET: HealthyEatings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HealthyEating healthyEating = db.HealthyEatings.Find(id);
            if (healthyEating == null)
            {
                return HttpNotFound();
            }
            ViewBag.recipeTypeId = new SelectList(db.RecipeTypes, "RecipeTypeId", "Name", healthyEating.recipeTypeId);
            return View(healthyEating);
        }

        // POST: HealthyEatings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,recipeTypeId,Name,Ingredients,Description,Rating,ImgURL")] HealthyEating healthyEating)
        {
            if (ModelState.IsValid)
            {
                db.Entry(healthyEating).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.recipeTypeId = new SelectList(db.RecipeTypes, "RecipeTypeId", "Name", healthyEating.recipeTypeId);
            return View(healthyEating);
        }

        // GET: HealthyEatings/Delete/5
      
        public ActionResult Delete(int id)
        {
            HealthyEating healthyEating = db.HealthyEatings.Find(id);
            db.HealthyEatings.Remove(healthyEating);
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
