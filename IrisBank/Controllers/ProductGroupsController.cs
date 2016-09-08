using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using com.iris.Bank.Entity;
using com.iris;
using com.iris.Web;

namespace IrisBank.Controllers
{
    public class ProductGroupsController : IrisController
    {
        private IrisDbContext db = new IrisDbContext();

        // GET: /ProductGroups/
        public ActionResult Index()
        {
            return View(db.ProductGroups.ToList());
        }

        // GET: /ProductGroups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductGroup productgroup = db.ProductGroups.Find(id);
            if (productgroup == null)
            {
                return HttpNotFound();
            }
            return View(productgroup);
        }

        // GET: /ProductGroups/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /ProductGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,ProductGroupName,DateAdded,LastUpdated,Statusflag,Slug")] ProductGroup productgroup)
        {
            if (ModelState.IsValid)
            {
                db.ProductGroups.Add(productgroup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productgroup);
        }

        // GET: /ProductGroups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductGroup productgroup = db.ProductGroups.Find(id);
            if (productgroup == null)
            {
                return HttpNotFound();
            }
            return View(productgroup);
        }

        // POST: /ProductGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,ProductGroupName,DateAdded,LastUpdated,Statusflag,Slug")] ProductGroup productgroup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productgroup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productgroup);
        }

        // GET: /ProductGroups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductGroup productgroup = db.ProductGroups.Find(id);
            if (productgroup == null)
            {
                return HttpNotFound();
            }
            return View(productgroup);
        }

        // POST: /ProductGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductGroup productgroup = db.ProductGroups.Find(id);
            db.ProductGroups.Remove(productgroup);
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
