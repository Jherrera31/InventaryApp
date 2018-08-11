using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PcStoreApp.Models;
using PcStoreApp.ViewModels;

namespace PcStoreApp.Controllers
{
    public class ReciveController : Controller
    {
        private ProductContext db = new ProductContext();

        // GET: Recive
        public ActionResult Index()
        {
            //var viewmodel = new List<POSIndexViewModel>();

            //var recives = db.Recives.ToList();

            //foreach (var recive in recives)
            //{
            //    var item = new POSIndexViewModel
            //    {
            //        ClientName = recive.Customer,
            //        Date = recive.Date,
            //        Quantity = recive.Quantity,

            //        ProductName = recive.Product.Name,
            //        SalePrise = recive.Product.SalePrice,
            //        Total = recive.Quantity * recive.Product.SalePrice
            //    };
            //    viewmodel.Add(item);
             //  slkfjalsdjflkj 
             // lkafjl;kjsdlfjkl; kj upitpii
             // lkjdas;lfkjal;sdkjf 
             //
            //}


            var viewmodel = db.Recives.Select(recive => new POSIndexViewModel
            {
                ID = recive.ID,
                
                ClientName = recive.Customer,
                Date = recive.Date,
                Quantity = recive.Quantity,
               

                ProductName = recive.Product.Name,
                SalePrise = recive.Product.SalePrice,
                Total = recive.Quantity * recive.Product.SalePrice
            }).ToList();

            return View(viewmodel);
        }

        // GET: Recive/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recive recive = db.Recives.Find(id);
            if (recive == null)
            {
                return HttpNotFound();
            }
            return View(recive);
        }

        // GET: Recive/Create
        public ActionResult Create( )
        {

            var viewModel = new POSCreateViewModel
            {
                ProductsSelectList = db.Products?.Select(x => new SelectListItem { Text = x.Name, Value = x.ID.ToString()}).ToList()
            };

            return View(viewModel);
        }

        // POST: Recive/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(POSCreateViewModel model)
        {

            if (ModelState.IsValid)
            {
                var recive = new Recive
                {
                    ProductId = model.ProductId,
                    Date = DateTime.UtcNow,
                    Customer = model.ClientName,
                    Quantity = model.Quantity
                };

                var product = db.Products.Find(model.ProductId);
                product.Quantity = product.Quantity - recive.Quantity;
               
                    
                db.Recives.Add(recive);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: Recive/Edit/5
        public ActionResult Edit(int id)
        {
           
            var viewModel = new POSEditViewModel
            {
                ProductsSelectList = db.Products?.Select(x => new SelectListItem { Text = x.Name, Value = x.ID.ToString() }).ToList()
            };

            var recive = db.Recives.Find(id);
            viewModel.ClientName = recive.Customer;
            viewModel.Quantity = recive.Quantity;
            viewModel.ProductId = recive.ProductId;
                
               

            return View(viewModel);
        }

        // POST: Recive/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Recive recive)
        {
           
            if (ModelState.IsValid)
            {
               
                db.Entry(recive).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();

        }

        // GET: Recive/Delete/5
        public ActionResult Delete(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var recive = db.Recives.Include(nameof(Product)).FirstOrDefault(x => x.ID == id);
            var model = new POSDeleteViewModel
            {

                ID = recive.ID,
               Customer = recive.Customer,
               ProductName = recive.Product.Name,
               Quantity = recive.Quantity,
               SalePrice = recive.Product.SalePrice,
               Date = recive.Date,
               Total = recive.Total,
               
            };

            if (recive == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: Recive/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(FormCollection fcNotUsed, int id = 0)
        {
            
            var delete = db.Recives.Find(id);
            if (delete == null)
            {
                return HttpNotFound();
            }
            db.Recives.Remove(delete);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }

    
}
