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
    public class FooterInfoController : Controller
    {
        private WebITEntities1 db = new WebITEntities1();

        // GET: Admin/FooterInfo
        public ActionResult Index()
        {
            return View(db.FooterInfo.ToList());
        }

        // GET: Admin/FooterInfo/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FooterInfo footerInfo = db.FooterInfo.Find(id);
            if (footerInfo == null)
            {
                return HttpNotFound();
            }
            return View(footerInfo);
        }

        // GET: Admin/FooterInfo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/FooterInfo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaInfo,TenInfo,Link")] FooterInfo footerInfo)
        {
            if (ModelState.IsValid)
            {
                db.FooterInfo.Add(footerInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(footerInfo);
        }

        // GET: Admin/FooterInfo/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FooterInfo footerInfo = db.FooterInfo.Find(id);
            if (footerInfo == null)
            {
                return HttpNotFound();
            }
            return View(footerInfo);
        }

        // POST: Admin/FooterInfo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaInfo,TenInfo,Link")] FooterInfo footerInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(footerInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(footerInfo);
        }

        // GET: Admin/FooterInfo/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FooterInfo footerInfo = db.FooterInfo.Find(id);
            if (footerInfo == null)
            {
                return HttpNotFound();
            }
            return View(footerInfo);
        }

        // POST: Admin/FooterInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            FooterInfo footerInfo = db.FooterInfo.Find(id);
            db.FooterInfo.Remove(footerInfo);
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
