﻿using System;
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
using com.iris.Util;

namespace IrisManager.Areas.rm.Controllers
{
    public class UsersController : IrisController
    {
        private IrisDbContext db = new IrisDbContext();

        // GET: /rm/Users/
        public ActionResult Index()
        {
            var users = db.Users.Include(u => u.Location).Include(u => u.UserGroup);
            return View(users.ToList());
        }

        // GET: /rm/Users/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: /rm/Users/Create
        public ActionResult Create()
        {
            ViewBag.LocationId = new SelectList(db.Locations, "Id", "LocationName");
            ViewBag.UserGroupId = new SelectList(db.UserGroups, "Id", "UserGroupName");
            return View();
        }

        // POST: /rm/Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,UserName,Pwd,Salt,Code,PwdExpire,LastName,FirstName,Email,Mobile,LocationId,UserGroupId,UserCode1,UserCode2,UserCode3,UserCode4,UserCode5,DateAdded,LastUpdated,Statusflag,Slug")] User user)
        {
            if (ModelState.IsValid)
            {
                user.Salt = GenUtil.RandomLower(15);
                user.Pwd = CryptUtil.Enkrypt(user.UserName + user.Pwd + user.Salt);
                user.Code = "0";

                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LocationId = new SelectList(db.Locations, "Id", "LocationName", user.LocationId);
            ViewBag.UserGroupId = new SelectList(db.UserGroups, "Id", "UserGroupName", user.UserGroupId);
            return View(user);
        }

        // GET: /rm/Users/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.LocationId = new SelectList(db.Locations, "Id", "LocationName", user.LocationId);
            ViewBag.UserGroupId = new SelectList(db.UserGroups, "Id", "UserGroupName", user.UserGroupId);
            return View(user);
        }

        // POST: /rm/Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,UserName,Pwd,Salt,Code,PwdExpire,LastName,FirstName,Email,Mobile,LocationId,UserGroupId,UserCode1,UserCode2,UserCode3,UserCode4,UserCode5,DateAdded,LastUpdated,Statusflag,Slug")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LocationId = new SelectList(db.Locations, "Id", "LocationName", user.LocationId);
            ViewBag.UserGroupId = new SelectList(db.UserGroups, "Id", "UserGroupName", user.UserGroupId);
            return View(user);
        }

        // GET: /rm/Users/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: /rm/Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
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