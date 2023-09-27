using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class SanPham
    {
        public string MaSP { get; set; }
        public string TenMH { get; set;}
        public string Size { get; set;}
        public float GiaBan { get; set;}
        public string MaLoai { get; set;}
        public int SoLuongTon { get; set;}
        public string ImageUrl { get; set;}
        public string Mota { get; set;}
        public TheLoai TheLoai { get; set;}

    }
}
