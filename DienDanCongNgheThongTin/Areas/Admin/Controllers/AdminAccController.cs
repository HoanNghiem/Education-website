using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DienDanCongNgheThongTin.Models.framework;

namespace DienDanCongNgheThongTin.Areas.Admin.Controllers
{
    [Authorize]
    public class AdminAccController : Controller
    {
        private WebITEntities1 db = new WebITEntities1();

        // GET: Admin/AdminAcc
        public ActionResult Index()
        {
            return View(db.AdminAcc.ToList());
        }

        // GET: Admin/AdminAcc/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminAcc adminAcc = db.AdminAcc.Find(id);
            if (adminAcc == null)
            {
                return HttpNotFound();
            }
            return View(adminAcc);
        }

        // GET: Admin/AdminAcc/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/AdminAcc/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TaiKhoan,MatKhau,Quyen")] AdminAcc adminAcc)
        {
            if (ModelState.IsValid)
            {
                db.AdminAcc.Add(adminAcc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(adminAcc);
        }

        // GET: Admin/AdminAcc/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminAcc adminAcc = db.AdminAcc.Find(id);
            if (adminAcc == null)
            {
                return HttpNotFound();
            }
            return View(adminAcc);
        }

        // POST: Admin/AdminAcc/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TaiKhoan,MatKhau,Quyen")] AdminAcc adminAcc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adminAcc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(adminAcc);
        }

        // GET: Admin/AdminAcc/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminAcc adminAcc = db.AdminAcc.Find(id);
            if (adminAcc == null)
            {
                return HttpNotFound();
            }
            return View(adminAcc);
        }

        // POST: Admin/AdminAcc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            AdminAcc adminAcc = db.AdminAcc.Find(id);
            db.AdminAcc.Remove(adminAcc);
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
