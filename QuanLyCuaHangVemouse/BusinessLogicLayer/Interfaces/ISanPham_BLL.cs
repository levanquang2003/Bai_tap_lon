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
        List<SanPham> SearchSP(int pageIndex, int pageSize, out int total, string TenSanPham, string TenTheLoai, string giatien);
        bool sp_ThemSanPham(SanPham sp);
        List<SanPham> sp_TimKiemSanPhamTheoTen(string TenSP);
        List<SanPham> sp_TimKiemSanPhamTheoMa(int MaSP);
        bool sp_SuaThongTinSanPham(SanPham sp);
        bool sp_SuaSLBanSanPham(int MaSP, int SoLuongBan);
        bool sp_XoaSanPham(int MaSP);
    }
}
