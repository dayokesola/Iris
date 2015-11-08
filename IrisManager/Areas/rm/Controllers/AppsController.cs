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

namespace IrisManager.Areas.rm.Controllers
{
    public class AppsController : Controller
    {
        private IrisDbContext db = new IrisDbContext();

        // GET: /rm/Apps/
        public ActionResult Index()
        {
            return View(db.Apps.ToList());
        }

        // GET: /rm/Apps/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            App app = db.Apps.Find(id);
            if (app == null)
            {
                return HttpNotFound();
            }
            return View(app);
        }

        // GET: /rm/Apps/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /rm/Apps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,AppName,DateAdded,LastUpdated,Statusflag,Slug")] App app)
        {
            if (ModelState.IsValid)
            {
                db.Apps.Add(app);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(app);
        }

        // GET: /rm/Apps/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            App app = db.Apps.Find(id);
            if (app == null)
            {
                return HttpNotFound();
            }
            return View(app);
        }

        // POST: /rm/Apps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,AppName,DateAdded,LastUpdated,Statusflag,Slug")] App app)
        {
            if (ModelState.IsValid)
            {
                db.Entry(app).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(app);
        }

        // GET: /rm/Apps/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            App app = db.Apps.Find(id);
            if (app == null)
            {
                return HttpNotFound();
            }
            return View(app);
        }

        // POST: /rm/Apps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            App app = db.Apps.Find(id);
            db.Apps.Remove(app);
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
