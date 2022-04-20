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
    public class KhoaHocController : Controller
    {
        private WebITEntities1 db = new WebITEntities1();

        // GET: Admin/KhoaHoc
        public ActionResult Index()
        {
            return View(db.KhoaHoc.ToList());
        }

        // GET: Admin/KhoaHoc/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhoaHoc khoaHoc = db.KhoaHoc.Find(id);
            if (khoaHoc == null)
            {
                return HttpNotFound();
            }
            return View(khoaHoc);
        }

        // GET: Admin/KhoaHoc/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/KhoaHoc/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaKhoaHoc,TenKhoaHoc")] KhoaHoc khoaHoc)
        {
            if (ModelState.IsValid)
            {
                db.KhoaHoc.Add(khoaHoc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(khoaHoc);
        }

        // GET: Admin/KhoaHoc/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhoaHoc khoaHoc = db.KhoaHoc.Find(id);
            if (khoaHoc == null)
            {
                return HttpNotFound();
            }
            return View(khoaHoc);
        }

        // POST: Admin/KhoaHoc/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaKhoaHoc,TenKhoaHoc")] KhoaHoc khoaHoc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(khoaHoc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(khoaHoc);
        }

        // GET: Admin/KhoaHoc/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhoaHoc khoaHoc = db.KhoaHoc.Find(id);
            if (khoaHoc == null)
            {
                return HttpNotFound();
            }
            return View(khoaHoc);
        }

        // POST: Admin/KhoaHoc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            KhoaHoc khoaHoc = db.KhoaHoc.Find(id);
            db.KhoaHoc.Remove(khoaHoc);
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
