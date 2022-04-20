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
    public class BaiHocController : Controller
    {
        private WebITEntities1 db = new WebITEntities1();

        // GET: Admin/BaiHoc
        public ActionResult Index()
        {
            var baiHoc = db.BaiHoc.Include(b => b.KhoaHoc);
            return View(baiHoc.ToList());
        }

        // GET: Admin/BaiHoc/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaiHoc baiHoc = db.BaiHoc.Find(id);
            if (baiHoc == null)
            {
                return HttpNotFound();
            }
            return View(baiHoc);
        }

        // GET: Admin/BaiHoc/Create
        public ActionResult Create()
        {
            ViewBag.MaKhoaHoc = new SelectList(db.KhoaHoc, "MaKhoaHoc", "TenKhoaHoc");
            return View();
        }

        // POST: Admin/BaiHoc/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaBaiHoc,TenBaiHoc,MaKhoaHoc,MoTa,TacGia,imgUrl,iconUrl")] BaiHoc baiHoc)
        {
            if (ModelState.IsValid)
            {
                db.BaiHoc.Add(baiHoc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaKhoaHoc = new SelectList(db.KhoaHoc, "MaKhoaHoc", "TenKhoaHoc", baiHoc.MaKhoaHoc);
            return View(baiHoc);
        }

        // GET: Admin/BaiHoc/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaiHoc baiHoc = db.BaiHoc.Find(id);
            if (baiHoc == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaKhoaHoc = new SelectList(db.KhoaHoc, "MaKhoaHoc", "TenKhoaHoc", baiHoc.MaKhoaHoc);
            return View(baiHoc);
        }

        // POST: Admin/BaiHoc/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaBaiHoc,TenBaiHoc,MaKhoaHoc,MoTa,TacGia,imgUrl,iconUrl")] BaiHoc baiHoc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(baiHoc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaKhoaHoc = new SelectList(db.KhoaHoc, "MaKhoaHoc", "TenKhoaHoc", baiHoc.MaKhoaHoc);
            return View(baiHoc);
        }

        // GET: Admin/BaiHoc/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaiHoc baiHoc = db.BaiHoc.Find(id);
            if (baiHoc == null)
            {
                return HttpNotFound();
            }
            return View(baiHoc);
        }

        // POST: Admin/BaiHoc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            BaiHoc baiHoc = db.BaiHoc.Find(id);
            db.BaiHoc.Remove(baiHoc);
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
