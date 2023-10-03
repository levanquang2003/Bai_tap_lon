using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public partial interface ISanPham
    {
        bool sp_ThemSanPham(SanPham sp);
        SanPham sp_TimKiemSanPhamTheoTen(string MaSP);
        SanPham sp_TimKiemSanPhamTheoMa(string MaSP);
        bool sp_SuaThongTinSanPham(SanPham sp);
        bool sp_SuaSLBanSanPham(SanPham sp);
        bool sp_XoaSanPham(string MaSP);
    }
}
