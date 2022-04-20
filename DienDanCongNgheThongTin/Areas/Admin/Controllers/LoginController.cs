using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DienDanCongNgheThongTin.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(DienDanCongNgheThongTin.Areas.Admin.Data.DTO.User user)
        {
            if (ModelState.IsValid)
            {
                DienDanCongNgheThongTin.Models.framework.WebITEntities1 db = new DienDanCongNgheThongTin.Models.framework.WebITEntities1();
                var _user = db.AdminAcc.FirstOrDefault(x => x.TaiKhoan == user.TaiKhoan && x.MatKhau == user.MatKhau);
                if( _user != null)
                {
                    // dang nhap thanh cong
                    // luu trang thai dang nhap lai
                    FormsAuthentication.SetAuthCookie(user.TaiKhoan, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    // dang nhap that bai
                    ModelState.AddModelError("", "Tài khoản hoặc mật khẩu không đúng!");
                }
            }
            return View(user);
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}