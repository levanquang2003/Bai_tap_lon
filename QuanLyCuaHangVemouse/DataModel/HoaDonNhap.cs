using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class HoaDonNhap
    {
        public int MaHDN { get; set; }
        public DateTime NgayNhap { get; set; }
        public int MaNCC { get; set; }
        public string TenTK { get; set; }
        public string GhiChu { get; set; }
        public List<ChiTietHoaDonNhap> ChiTietHoaDonNhap { get; set; }
    }
}
