using DienDanCongNgheThongTin.Models.framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DienDanCongNgheThongTin.Controllers
{
    public class LoginUserController : Controller
    {
        
        // GET: LoginUser
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(DienDanCongNgheThongTin.Models.dtos.userAcc useracc)
        {
            if (ModelState.IsValid)
            {
                DienDanCongNgheThongTin.Models.framework.WebITEntities1 dbs = new DienDanCongNgheThongTin.Models.framework.WebITEntities1();
                var _useracc = dbs.ThanhVien.FirstOrDefault(a => a.TaiKhoan == useracc.TaiKhoanUs && a.MatKhau == useracc.MatKhauUs);
                if(_useracc != null)
                {
                    FormsAuthentication.SetAuthCookie(useracc.TaiKhoanUs, false);
                    return RedirectToAction("Index", "HomeAcc");
                }
                else
                {
                    ModelState.AddModelError("", "Tài khoản hoặc mật khẩu không đúng!");
                }
            }
            return View(useracc);
        }

       
        public ActionResult Register()
        {
            return View(new ThanhVien());
        }

        [HttpPost]
        public ActionResult Register(ThanhVien thanhVien)
        {
            if (ModelState.IsValid)
            {
                var dao = new userDao();
                if (dao.CheckTK(thanhVien.TaiKhoan))
                {
                    ModelState.AddModelError("", "Tài khoản đã tồn tại!");
                    return View(thanhVien);
                }
                WebITEntities1 db = new WebITEntities1();
                db.ThanhVien.Add(thanhVien);
                db.SaveChanges();
                if (thanhVien.TaiKhoan != null)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "dang ki khong thanh cong");
                    
                }
            }
            return View(thanhVien);
            
        }

        public ActionResult LogoutAcc()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index","LoginUser");
        }
    }
}