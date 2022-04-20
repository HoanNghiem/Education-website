using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DienDanCongNgheThongTin.Models.framework;
namespace DienDanCongNgheThongTin.Controllers
{
    public class TermController : Controller
    {
        // GET: Term
        public ActionResult Index()
        {
            WebITEntities1 db = new WebITEntities1();
            List<Terms> term = db.Terms.ToList();
            return View(term);
        }
    }
}