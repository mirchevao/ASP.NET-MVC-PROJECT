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
    public class BakedGoodsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BakedGoods
        public ActionResult Index()
        {
            var bakedGoods = db.BakedGoods.Include(b => b.recipeType);
            return View(bakedGoods.ToList());
        }

        // GET: BakedGoods/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BakedGoods bakedGoods = db.BakedGoods.Find(id);
            if (bakedGoods == null)
            {
                return HttpNotFound();
            }
            return View(bakedGoods);
        }

        // GET: BakedGoods/Create
        public ActionResult Create()
        {
            ViewBag.recipeTypeId = new SelectList(db.RecipeTypes, "RecipeTypeId", "Name");
            return View();
        }

        // POST: BakedGoods/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,recipeTypeId,Name,Ingredients,Description,Rating,ImgURL")] BakedGoods bakedGoods)
        {
            if (ModelState.IsValid)
            {
                db.BakedGoods.Add(bakedGoods);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.recipeTypeId = new SelectList(db.RecipeTypes, "RecipeTypeId", "Name", bakedGoods.recipeTypeId);
            return View(bakedGoods);
        }

        // GET: BakedGoods/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BakedGoods bakedGoods = db.BakedGoods.Find(id);
            if (bakedGoods == null)
            {
                return HttpNotFound();
            }
            ViewBag.recipeTypeId = new SelectList(db.RecipeTypes, "RecipeTypeId", "Name", bakedGoods.recipeTypeId);
            return View(bakedGoods);
        }

        // POST: BakedGoods/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,recipeTypeId,Name,Ingredients,Description,Rating,ImgURL")] BakedGoods bakedGoods)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bakedGoods).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.recipeTypeId = new SelectList(db.RecipeTypes, "RecipeTypeId", "Name", bakedGoods.recipeTypeId);
            return View(bakedGoods);
        }

        // GET: BakedGoods/Delete/5
        
        public ActionResult Delete(int id)
        {
            BakedGoods bakedGoods = db.BakedGoods.Find(id);
            db.BakedGoods.Remove(bakedGoods);
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
