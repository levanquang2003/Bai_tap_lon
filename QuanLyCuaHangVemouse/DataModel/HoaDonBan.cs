using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class HoaDonBan
    {
        public int MaHDB { get; set; }
        public bool TrangThai { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayDuyet { get; set; }
        public string TenKH { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }
        public string SDT { get; set; }
        public string DiaChiGiaoHang { get; set; }
        public DateTime ThoiGianGiaoHang { get; set; }
        public List<ChiTietHoaDonBan> ChiTietHoaDonBan { get; set; }
    }
}
