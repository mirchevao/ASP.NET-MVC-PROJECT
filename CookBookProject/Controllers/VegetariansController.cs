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
    public class VegetariansController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Vegetarians
        public ActionResult Index()
        {
            var vegetarians = db.Vegetarians.Include(v => v.recipeType);
            return View(vegetarians.ToList());
        }

        // GET: Vegetarians/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vegetarian vegetarian = db.Vegetarians.Find(id);
            if (vegetarian == null)
            {
                return HttpNotFound();
            }
            return View(vegetarian);
        }

        // GET: Vegetarians/Create
        public ActionResult Create()
        {
            ViewBag.recipeTypeId = new SelectList(db.RecipeTypes, "RecipeTypeId", "Name");
            return View();
        }

        // POST: Vegetarians/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,recipeTypeId,Name,Ingredients,Description,Rating,ImgURL")] Vegetarian vegetarian)
        {
            if (ModelState.IsValid)
            {
                db.Vegetarians.Add(vegetarian);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.recipeTypeId = new SelectList(db.RecipeTypes, "RecipeTypeId", "Name", vegetarian.recipeTypeId);
            return View(vegetarian);
        }

        // GET: Vegetarians/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vegetarian vegetarian = db.Vegetarians.Find(id);
            if (vegetarian == null)
            {
                return HttpNotFound();
            }
            ViewBag.recipeTypeId = new SelectList(db.RecipeTypes, "RecipeTypeId", "Name", vegetarian.recipeTypeId);
            return View(vegetarian);
        }

        // POST: Vegetarians/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,recipeTypeId,Name,Ingredients,Description,Rating,ImgURL")] Vegetarian vegetarian)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vegetarian).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.recipeTypeId = new SelectList(db.RecipeTypes, "RecipeTypeId", "Name", vegetarian.recipeTypeId);
            return View(vegetarian);
        }

        // GET: Vegetarians/Delete/5
        
        public ActionResult Delete(int id)
        {
            Vegetarian vegetarian = db.Vegetarians.Find(id);
            db.Vegetarians.Remove(vegetarian);
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
