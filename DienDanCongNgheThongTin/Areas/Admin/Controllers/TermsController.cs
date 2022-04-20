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
    public class TermsController : Controller
    {
        private WebITEntities1 db = new WebITEntities1();

        // GET: Admin/Terms
        public ActionResult Index()
        {
            return View(db.Terms.ToList());
        }

        // GET: Admin/Terms/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Terms terms = db.Terms.Find(id);
            if (terms == null)
            {
                return HttpNotFound();
            }
            return View(terms);
        }

        // GET: Admin/Terms/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Terms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaTerms,NoiDung")] Terms terms)
        {
            if (ModelState.IsValid)
            {
                db.Terms.Add(terms);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(terms);
        }

        // GET: Admin/Terms/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Terms terms = db.Terms.Find(id);
            if (terms == null)
            {
                return HttpNotFound();
            }
            return View(terms);
        }

        // POST: Admin/Terms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaTerms,NoiDung")] Terms terms)
        {
            if (ModelState.IsValid)
            {
                db.Entry(terms).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(terms);
        }

        // GET: Admin/Terms/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Terms terms = db.Terms.Find(id);
            if (terms == null)
            {
                return HttpNotFound();
            }
            return View(terms);
        }

        // POST: Admin/Terms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Terms terms = db.Terms.Find(id);
            db.Terms.Remove(terms);
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
