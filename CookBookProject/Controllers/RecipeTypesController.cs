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
    public class RecipeTypesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: RecipeTypes
        [Authorize(Roles = "Administrator")]
        public ActionResult Index()
        {
            return View(db.RecipeTypes.ToList());
        }

        // GET: RecipeTypes/Details/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecipeType recipeType = db.RecipeTypes.Find(id);
            if (recipeType == null)
            {
                return HttpNotFound();
            }
            return View(recipeType);
        }
        [Authorize(Roles = "Administrator")]
        // GET: RecipeTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RecipeTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult Create([Bind(Include = "RecipeTypeId,Name")] RecipeType recipeType)
        {
            if (ModelState.IsValid)
            {
                db.RecipeTypes.Add(recipeType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(recipeType);
        }

        // GET: RecipeTypes/Edit/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecipeType recipeType = db.RecipeTypes.Find(id);
            if (recipeType == null)
            {
                return HttpNotFound();
            }
            return View(recipeType);
        }

        // POST: RecipeTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit([Bind(Include = "RecipeTypeId,Name")] RecipeType recipeType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recipeType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(recipeType);
        }

        // GET: RecipeTypes/Delete/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int id)
        {
            RecipeType recipeType = db.RecipeTypes.Find(id);
            db.RecipeTypes.Remove(recipeType);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Administrator")]
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
