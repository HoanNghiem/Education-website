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
    public class ChuyenMucController : Controller
    {
        private WebITEntities1 db = new WebITEntities1();

        // GET: Admin/ChuyenMuc
        public ActionResult Index()
        {
            return View(db.ChuyenMuc.ToList());
        }

        // GET: Admin/ChuyenMuc/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChuyenMuc chuyenMuc = db.ChuyenMuc.Find(id);
            if (chuyenMuc == null)
            {
                return HttpNotFound();
            }
            return View(chuyenMuc);
        }

        // GET: Admin/ChuyenMuc/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/ChuyenMuc/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaChuyenMuc,TenChuyenMuc")] ChuyenMuc chuyenMuc)
        {
            if (ModelState.IsValid)
            {
                db.ChuyenMuc.Add(chuyenMuc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(chuyenMuc);
        }

        // GET: Admin/ChuyenMuc/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChuyenMuc chuyenMuc = db.ChuyenMuc.Find(id);
            if (chuyenMuc == null)
            {
                return HttpNotFound();
            }
            return View(chuyenMuc);
        }

        // POST: Admin/ChuyenMuc/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaChuyenMuc,TenChuyenMuc")] ChuyenMuc chuyenMuc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chuyenMuc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(chuyenMuc);
        }

        // GET: Admin/ChuyenMuc/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChuyenMuc chuyenMuc = db.ChuyenMuc.Find(id);
            if (chuyenMuc == null)
            {
                return HttpNotFound();
            }
            return View(chuyenMuc);
        }

        // POST: Admin/ChuyenMuc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ChuyenMuc chuyenMuc = db.ChuyenMuc.Find(id);
            db.ChuyenMuc.Remove(chuyenMuc);
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
