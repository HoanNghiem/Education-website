using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DienDanCongNgheThongTin.Models.framework;
namespace DienDanCongNgheThongTin.Controllers
{
    public class GameController : Controller
    {
        // GET: Game
        public ActionResult Index()
        {
            WebITEntities1 db = new WebITEntities1();
            List<Game> game = db.Game.ToList();
            return View(game);
        }

        public ActionResult ChiTietGame(string id)
        {
            WebITEntities1 db = new WebITEntities1();
            Game game = db.Game.Find(id);
            return View(game);
        }
    }
}