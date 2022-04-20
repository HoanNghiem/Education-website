using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DienDanCongNgheThongTin.Models.framework;
namespace DienDanCongNgheThongTin.Controllers
{
    
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            WebITEntities1 db = new WebITEntities1();
            List<ChuyenMuc> chuyenmuc = db.ChuyenMuc.ToList();
            List<TinTuc> tintuc = db.TinTuc.ToList();
            return View(tintuc);
        }
    }
}