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
    public class FooterHelpController : Controller
    {
        private WebITEntities1 db = new WebITEntities1();

        // GET: Admin/FooterHelp
        public ActionResult Index()
        {
            return View(db.FooterHelp.ToList());
        }

        // GET: Admin/FooterHelp/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FooterHelp footerHelp = db.FooterHelp.Find(id);
            if (footerHelp == null)
            {
                return HttpNotFound();
            }
            return View(footerHelp);
        }

        // GET: Admin/FooterHelp/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/FooterHelp/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHelp,TenHelp,Link")] FooterHelp footerHelp)
        {
            if (ModelState.IsValid)
            {
                db.FooterHelp.Add(footerHelp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(footerHelp);
        }

        // GET: Admin/FooterHelp/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FooterHelp footerHelp = db.FooterHelp.Find(id);
            if (footerHelp == null)
            {
                return HttpNotFound();
            }
            return View(footerHelp);
        }

        // POST: Admin/FooterHelp/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHelp,TenHelp,Link")] FooterHelp footerHelp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(footerHelp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(footerHelp);
        }

        // GET: Admin/FooterHelp/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FooterHelp footerHelp = db.FooterHelp.Find(id);
            if (footerHelp == null)
            {
                return HttpNotFound();
            }
            return View(footerHelp);
        }

        // POST: Admin/FooterHelp/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            FooterHelp footerHelp = db.FooterHelp.Find(id);
            db.FooterHelp.Remove(footerHelp);
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
