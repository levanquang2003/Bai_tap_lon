using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public partial interface ISanPham_BLL
    {
        bool sp_ThemSanPham(SanPham sp);
        List<SanPham> sp_TimKiemSanPhamTheoTen(string TenSP);
        List<SanPham> sp_TimKiemSanPhamTheoMa(int MaSP);
        bool sp_SuaThongTinSanPham(SanPham sp);
        bool sp_SuaSLBanSanPham(int MaSP, int SoLuongBan);
        bool sp_XoaSanPham(int MaSP);
    }
}
