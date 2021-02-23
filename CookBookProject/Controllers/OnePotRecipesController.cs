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
    public class OnePotRecipesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: OnePotRecipes
        public ActionResult Index()
        {
            var onePotRecipes = db.OnePotRecipes.Include(o => o.recipeType);
            return View(onePotRecipes.ToList());
        }

        // GET: OnePotRecipes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OnePotRecipe onePotRecipe = db.OnePotRecipes.Find(id);
            if (onePotRecipe == null)
            {
                return HttpNotFound();
            }
            return View(onePotRecipe);
        }

        // GET: OnePotRecipes/Create
        public ActionResult Create()
        {
            ViewBag.recipeTypeId = new SelectList(db.RecipeTypes, "RecipeTypeId", "Name");
            return View();
        }

        // POST: OnePotRecipes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,recipeTypeId,Name,Ingredients,Description,Rating,ImgURL")] OnePotRecipe onePotRecipe)
        {
            if (ModelState.IsValid)
            {
                db.OnePotRecipes.Add(onePotRecipe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.recipeTypeId = new SelectList(db.RecipeTypes, "RecipeTypeId", "Name", onePotRecipe.recipeTypeId);
            return View(onePotRecipe);
        }

        // GET: OnePotRecipes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OnePotRecipe onePotRecipe = db.OnePotRecipes.Find(id);
            if (onePotRecipe == null)
            {
                return HttpNotFound();
            }
            ViewBag.recipeTypeId = new SelectList(db.RecipeTypes, "RecipeTypeId", "Name", onePotRecipe.recipeTypeId);
            return View(onePotRecipe);
        }

        // POST: OnePotRecipes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,recipeTypeId,Name,Ingredients,Description,Rating,ImgURL")] OnePotRecipe onePotRecipe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(onePotRecipe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.recipeTypeId = new SelectList(db.RecipeTypes, "RecipeTypeId", "Name", onePotRecipe.recipeTypeId);
            return View(onePotRecipe);
        }

        // GET: OnePotRecipes/Delete/5
       
        public ActionResult Delete(int id)
        {
            OnePotRecipe onePotRecipe = db.OnePotRecipes.Find(id);
            db.OnePotRecipes.Remove(onePotRecipe);
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
