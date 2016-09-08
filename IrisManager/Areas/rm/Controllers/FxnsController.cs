using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using com.iris.RoleManager.Entity;
using com.iris;
using com.iris.Web;

namespace IrisManager.Areas.rm.Controllers
{
    public class FxnsController : IrisController
    {
        private IrisDbContext db = new IrisDbContext();

        // GET: /rm/Fxns/
        public ActionResult Index()
        {
            var fxns = db.Fxns.Include(f => f.App);
            return View(fxns.ToList());
        }

        // GET: /rm/Fxns/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fxn fxn = db.Fxns.Find(id);
            if (fxn == null)
            {
                return HttpNotFound();
            }
            return View(fxn);
        }

        // GET: /rm/Fxns/Create
        public ActionResult Create()
        {
            ViewBag.AppId = new SelectList(db.Apps, "Id", "AppName");
            return View();
        }

        // POST: /rm/Fxns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,FxnName,AppId,FxnGroup,FxnUrl,FxnFlag,FxnSort,FxnSecured,DateAdded,LastUpdated,Statusflag,Slug")] Fxn fxn)
        {
            if (ModelState.IsValid)
            {
                db.Fxns.Add(fxn);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AppId = new SelectList(db.Apps, "Id", "AppName", fxn.AppId);
            return View(fxn);
        }

        // GET: /rm/Fxns/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fxn fxn = db.Fxns.Find(id);
            if (fxn == null)
            {
                return HttpNotFound();
            }
            ViewBag.AppId = new SelectList(db.Apps, "Id", "AppName", fxn.AppId);
            return View(fxn);
        }

        // POST: /rm/Fxns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,FxnName,AppId,FxnGroup,FxnUrl,FxnFlag,FxnSort,FxnSecured,DateAdded,LastUpdated,Statusflag,Slug")] Fxn fxn)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fxn).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AppId = new SelectList(db.Apps, "Id", "AppName", fxn.AppId);
            return View(fxn);
        }

        // GET: /rm/Fxns/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fxn fxn = db.Fxns.Find(id);
            if (fxn == null)
            {
                return HttpNotFound();
            }
            return View(fxn);
        }

        // POST: /rm/Fxns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Fxn fxn = db.Fxns.Find(id);
            db.Fxns.Remove(fxn);
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
