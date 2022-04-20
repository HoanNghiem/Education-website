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
    public class TopBarMenusController : Controller
    {
        private WebITEntities1 db = new WebITEntities1();

        // GET: Admin/TopBarMenus
        public ActionResult Index()
        {
            return View(db.TopBarMenu.ToList());
        }

        // GET: Admin/TopBarMenus/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TopBarMenu topBarMenu = db.TopBarMenu.Find(id);
            if (topBarMenu == null)
            {
                return HttpNotFound();
            }
            return View(topBarMenu);
        }

        // GET: Admin/TopBarMenus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/TopBarMenus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaMenu,TenMenu,Link")] TopBarMenu topBarMenu)
        {
            if (ModelState.IsValid)
            {
                db.TopBarMenu.Add(topBarMenu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(topBarMenu);
        }

        // GET: Admin/TopBarMenus/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TopBarMenu topBarMenu = db.TopBarMenu.Find(id);
            if (topBarMenu == null)
            {
                return HttpNotFound();
            }
            return View(topBarMenu);
        }

        // POST: Admin/TopBarMenus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaMenu,TenMenu,Link")] TopBarMenu topBarMenu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(topBarMenu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(topBarMenu);
        }

        // GET: Admin/TopBarMenus/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TopBarMenu topBarMenu = db.TopBarMenu.Find(id);
            if (topBarMenu == null)
            {
                return HttpNotFound();
            }
            return View(topBarMenu);
        }

        // POST: Admin/TopBarMenus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            TopBarMenu topBarMenu = db.TopBarMenu.Find(id);
            db.TopBarMenu.Remove(topBarMenu);
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
