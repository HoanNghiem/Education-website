using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DienDanCongNgheThongTin.Models.framework
{
    public class userDao
    {
        WebITEntities1 db = null;
        public userDao()
        {
            db = new WebITEntities1();
        }

        public bool CheckTK(string tk)
        {
            return db.ThanhVien.Count(y => y.TaiKhoan == tk) > 0;
        }
    }
}