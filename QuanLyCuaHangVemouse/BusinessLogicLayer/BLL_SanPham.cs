using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Interfaces;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class BLL_SanPham : ISanPham_BLL
    {
        private ISanPham _res;
        public BLL_SanPham(ISanPham res)
        {
            res = _res;
        }
        public List<SanPham> sp_TimKiemSanPhamTheoTen(string TenSP)
        {
            return _res.sp_TimKiemSanPhamTheoTen(TenSP);
        }
        public List<SanPham> sp_TimKiemSanPhamTheoMa(int MaSP)
        {
            return _res.sp_TimKiemSanPhamTheoMa(MaSP);
        }
        public bool sp_ThemSanPham(SanPham sp)
        {
            return _res.sp_ThemSanPham(sp);
        }
        public bool sp_XoaSanPham(int MaSP)
        {
            return _res.sp_XoaSanPham(MaSP);
        }
        public bool sp_SuaThongTinSanPham(SanPham sp)
        {
            return _res.sp_SuaThongTinSanPham(sp);
        }
        public bool sp_SuaSLBanSanPham(int MaSP, int SoLuongBan)
        {
            return _res.sp_SuaSLBanSanPham(MaSP, SoLuongBan);
        }
    }
}
