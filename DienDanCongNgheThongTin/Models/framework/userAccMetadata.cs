using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DienDanCongNgheThongTin.Models.framework
{
    public class userAccMetadata
    {
        [Required(ErrorMessage = "Bạn chưa nhập tài khoản!")]
        public string TaiKhoan { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập mật khẩu!")]
        [MinLength(3,ErrorMessage ="Mật khẩu tối thiểu 3 ký tự!")]
        public string MatKhau { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập email!")]
        [EmailAddress(ErrorMessage ="Email không đúng định dạng!")]
        public string Email { get; set; }
    }
}