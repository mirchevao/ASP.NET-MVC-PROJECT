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
    public class KetoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Ketoes
        public ActionResult Index()
        {
            var ketos = db.Ketos.Include(k => k.recipeType);
            return View(ketos.ToList());
        }

        // GET: Ketoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Keto keto = db.Ketos.Find(id);
            if (keto == null)
            {
                return HttpNotFound();
            }
            return View(keto);
        }

        // GET: Ketoes/Create
        public ActionResult Create()
        {
            ViewBag.recipeTypeId = new SelectList(db.RecipeTypes, "RecipeTypeId", "Name");
            return View();
        }

        // POST: Ketoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,recipeTypeId,Name,Ingredients,Description,Rating,ImgURL")] Keto keto)
        {
            if (ModelState.IsValid)
            {
                db.Ketos.Add(keto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.recipeTypeId = new SelectList(db.RecipeTypes, "RecipeTypeId", "Name", keto.recipeTypeId);
            return View(keto);
        }

        // GET: Ketoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Keto keto = db.Ketos.Find(id);
            if (keto == null)
            {
                return HttpNotFound();
            }
            ViewBag.recipeTypeId = new SelectList(db.RecipeTypes, "RecipeTypeId", "Name", keto.recipeTypeId);
            return View(keto);
        }

        // POST: Ketoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,recipeTypeId,Name,Ingredients,Description,Rating,ImgURL")] Keto keto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(keto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.recipeTypeId = new SelectList(db.RecipeTypes, "RecipeTypeId", "Name", keto.recipeTypeId);
            return View(keto);
        }

        // GET: Ketoes/Delete/5
        
        public ActionResult Delete(int id)
        {
            Keto keto = db.Ketos.Find(id);
            db.Ketos.Remove(keto);
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
