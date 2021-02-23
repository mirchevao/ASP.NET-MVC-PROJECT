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
    public class EasyDinnersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: EasyDinners
        public ActionResult Index()
        {
            var easyDinners = db.EasyDinners.Include(e => e.recipeType);
            return View(easyDinners.ToList());
        }

        // GET: EasyDinners/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EasyDinner easyDinner = db.EasyDinners.Find(id);
            if (easyDinner == null)
            {
                return HttpNotFound();
            }
            return View(easyDinner);
        }

        // GET: EasyDinners/Create
        public ActionResult Create()
        {
            ViewBag.recipeTypeId = new SelectList(db.RecipeTypes, "RecipeTypeId", "Name");
            return View();
        }

        // POST: EasyDinners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,recipeTypeId,Name,Ingredients,Description,Rating,ImgURL")] EasyDinner easyDinner)
        {
            if (ModelState.IsValid)
            {
                db.EasyDinners.Add(easyDinner);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.recipeTypeId = new SelectList(db.RecipeTypes, "RecipeTypeId", "Name", easyDinner.recipeTypeId);
            return View(easyDinner);
        }

        // GET: EasyDinners/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EasyDinner easyDinner = db.EasyDinners.Find(id);
            if (easyDinner == null)
            {
                return HttpNotFound();
            }
            ViewBag.recipeTypeId = new SelectList(db.RecipeTypes, "RecipeTypeId", "Name", easyDinner.recipeTypeId);
            return View(easyDinner);
        }

        // POST: EasyDinners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,recipeTypeId,Name,Ingredients,Description,Rating,ImgURL")] EasyDinner easyDinner)
        {
            if (ModelState.IsValid)
            {
                db.Entry(easyDinner).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.recipeTypeId = new SelectList(db.RecipeTypes, "RecipeTypeId", "Name", easyDinner.recipeTypeId);
            return View(easyDinner);
        }

        // GET: EasyDinners/Delete/5
      
        public ActionResult Delete(int id)
        {
            EasyDinner easyDinner = db.EasyDinners.Find(id);
            db.EasyDinners.Remove(easyDinner);
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
