using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DienDanCongNgheThongTin.Models.framework;
namespace DienDanCongNgheThongTin.Controllers
{
    public class BaiHocController : Controller
    {
        // GET: BaiHoc
        public ActionResult Index()
        {
            WebITEntities1 db = new WebITEntities1();
            List<BaiHoc> baihoc = db.BaiHoc.ToList();
            return View(baihoc);
        }

        public ActionResult ChiTietBaiHoc(string id)
        {
            WebITEntities1 db = new WebITEntities1();
            BaiHoc bh = db.BaiHoc.Find(id);
            return View(bh);
        }
    }
}