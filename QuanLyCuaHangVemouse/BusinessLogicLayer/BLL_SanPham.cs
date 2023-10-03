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
            _res = res;
        }
        public SanPham sp_TimKiemSanPhamTheoTen(string TenSP)
        {
            return _res.sp_TimKiemSanPhamTheoTen(TenSP);
        }
        public SanPham sp_TimKiemSanPhamTheoMa(string id)
        {
            return _res.sp_TimKiemSanPhamTheoMa(id);
        }
        public bool sp_ThemSanPham(SanPham sp)
        {
            return _res.sp_ThemSanPham(sp);
        }
        public bool sp_XoaSanPham(string MaSP)
        {
            return _res.sp_XoaSanPham(MaSP);
        }
        public bool sp_SuaThongTinSanPham(SanPham sp)
        {
            return _res.sp_SuaThongTinSanPham(sp);
        }
        public bool sp_SuaSLBanSanPham(SanPham sp)
        {
            return _res.sp_SuaSLBanSanPham(sp);
        }
    }
}
