using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class SanPham
    {
        public int MaSP { get; set; }
        public string TenSP { get; set;}
        public string Size { get; set;}
        public float GiaBan { get; set;}
        public float GiaGiam { get; set;}
        public string MaLoai { get; set;}
        public int SoLuongTon { get; set;}
        public int SoLuongBan { get; set;}
        public string ImageURL { get; set;}
        public string MoTa { get; set;}
        public string TrangThai { get; set;}
    }
}
