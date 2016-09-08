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
    public class UserGroupsController : IrisController
    {

        private IrisDbContext db = new IrisDbContext();

        // GET: /rm/UserGroups/
        public ActionResult Index()
        {
            return View(db.UserGroups.ToList());
        }

        // GET: /rm/UserGroups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserGroup usergroup = db.UserGroups.Find(id);
            if (usergroup == null)
            {
                return HttpNotFound();
            }
            return View(usergroup);
        }

        // GET: /rm/UserGroups/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /rm/UserGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,UserGroupName,LoginType,DateAdded,LastUpdated,Statusflag,Slug")] UserGroup usergroup)
        {
            if (ModelState.IsValid)
            {
                db.UserGroups.Add(usergroup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(usergroup);
        }

        // GET: /rm/UserGroups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserGroup usergroup = db.UserGroups.Find(id);
            if (usergroup == null)
            {
                return HttpNotFound();
            }
            return View(usergroup);
        }

        // POST: /rm/UserGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,UserGroupName,LoginType,DateAdded,LastUpdated,Statusflag,Slug")] UserGroup usergroup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usergroup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usergroup);
        }

        // GET: /rm/UserGroups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserGroup usergroup = db.UserGroups.Find(id);
            if (usergroup == null)
            {
                return HttpNotFound();
            }
            return View(usergroup);
        }

        // POST: /rm/UserGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserGroup usergroup = db.UserGroups.Find(id);
            db.UserGroups.Remove(usergroup);
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
