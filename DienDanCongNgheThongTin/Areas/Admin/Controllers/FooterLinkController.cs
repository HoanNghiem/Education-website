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
    public class FooterLinkController : Controller
    {
        private WebITEntities1 db = new WebITEntities1();

        // GET: Admin/FooterLink
        public ActionResult Index()
        {
            return View(db.FooterLink.ToList());
        }

        // GET: Admin/FooterLink/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FooterLink footerLink = db.FooterLink.Find(id);
            if (footerLink == null)
            {
                return HttpNotFound();
            }
            return View(footerLink);
        }

        // GET: Admin/FooterLink/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/FooterLink/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaLink,TenLink,Link")] FooterLink footerLink)
        {
            if (ModelState.IsValid)
            {
                db.FooterLink.Add(footerLink);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(footerLink);
        }

        // GET: Admin/FooterLink/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FooterLink footerLink = db.FooterLink.Find(id);
            if (footerLink == null)
            {
                return HttpNotFound();
            }
            return View(footerLink);
        }

        // POST: Admin/FooterLink/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaLink,TenLink,Link")] FooterLink footerLink)
        {
            if (ModelState.IsValid)
            {
                db.Entry(footerLink).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(footerLink);
        }

        // GET: Admin/FooterLink/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FooterLink footerLink = db.FooterLink.Find(id);
            if (footerLink == null)
            {
                return HttpNotFound();
            }
            return View(footerLink);
        }

        // POST: Admin/FooterLink/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            FooterLink footerLink = db.FooterLink.Find(id);
            db.FooterLink.Remove(footerLink);
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
