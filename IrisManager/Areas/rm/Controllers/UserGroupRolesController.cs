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
    public class UserGroupRolesController : IrisController
    {
        private IrisDbContext db = new IrisDbContext();

        // GET: /rm/UserGroupRoles/
        public ActionResult Index()
        {
            var usergrouproles = db.UserGroupRoles.Include(u => u.Role).Include(u => u.UserGroup);
            return View(usergrouproles.ToList());
        }

        // GET: /rm/UserGroupRoles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserGroupRole usergrouprole = db.UserGroupRoles.Find(id);
            if (usergrouprole == null)
            {
                return HttpNotFound();
            }
            return View(usergrouprole);
        }

        // GET: /rm/UserGroupRoles/Create
        public ActionResult Create()
        {
            ViewBag.RoleId = new SelectList(db.Roles, "Id", "RoleName");
            ViewBag.UserGroupId = new SelectList(db.UserGroups, "Id", "UserGroupName");
            return View();
        }

        // POST: /rm/UserGroupRoles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="UserGroupId,RoleId,DateAdded,LastUpdated,Statusflag,Slug")] UserGroupRole usergrouprole)
        {
            if (ModelState.IsValid)
            {
                db.UserGroupRoles.Add(usergrouprole);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RoleId = new SelectList(db.Roles, "Id", "RoleName", usergrouprole.RoleId);
            ViewBag.UserGroupId = new SelectList(db.UserGroups, "Id", "UserGroupName", usergrouprole.UserGroupId);
            return View(usergrouprole);
        }

        // GET: /rm/UserGroupRoles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserGroupRole usergrouprole = db.UserGroupRoles.Find(id);
            if (usergrouprole == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoleId = new SelectList(db.Roles, "Id", "RoleName", usergrouprole.RoleId);
            ViewBag.UserGroupId = new SelectList(db.UserGroups, "Id", "UserGroupName", usergrouprole.UserGroupId);
            return View(usergrouprole);
        }

        // POST: /rm/UserGroupRoles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="UserGroupId,RoleId,DateAdded,LastUpdated,Statusflag,Slug")] UserGroupRole usergrouprole)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usergrouprole).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RoleId = new SelectList(db.Roles, "Id", "RoleName", usergrouprole.RoleId);
            ViewBag.UserGroupId = new SelectList(db.UserGroups, "Id", "UserGroupName", usergrouprole.UserGroupId);
            return View(usergrouprole);
        }

        // GET: /rm/UserGroupRoles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserGroupRole usergrouprole = db.UserGroupRoles.Find(id);
            if (usergrouprole == null)
            {
                return HttpNotFound();
            }
            return View(usergrouprole);
        }

        // POST: /rm/UserGroupRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserGroupRole usergrouprole = db.UserGroupRoles.Find(id);
            db.UserGroupRoles.Remove(usergrouprole);
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
