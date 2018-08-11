using PcStoreApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;


namespace PcStoreApp.Controllers
{
    public class ProductController : Controller
    {
        public readonly ProductContext db;

        public ProductController()
        {
            db = new ProductContext();

        }

        // GET: Product
        public ActionResult Index(string searchString)
        {
            var index = from m in db.Products
                        select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                index = index.Where(s => s.Name.Contains(searchString));
            }

            return View(index);
        }

        // GET: Product/Details/5      
        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var detail = db.Products.Find(id);
            if (detail == null)
            {
                return HttpNotFound();
            }
            return View(detail);
        }

        // GET: Product/Create
        public ActionResult Create()
        {


            return View();

        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Product newProduct)
        {

            if (ModelState.IsValid)
            {
                db.Products.Add(newProduct);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View(newProduct);
            }
        }
        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            var edit = db.Products.Find(id);
            if (edit == null)
            {
                return HttpNotFound();
            }
            return View(edit);
        }
        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(Product Products)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Products).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Products);
        }


        // GET: Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var delete = db.Products.Find(id);
            if (delete == null)
            {
                return HttpNotFound();
            }
            return View(delete);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(FormCollection fcNotUsed, int id = 0)
        {
            var delete = db.Products.Find(id);
            if (delete == null)
            {
                return HttpNotFound();
            }
            db.Products.Remove(delete);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
      }
    }
