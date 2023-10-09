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
    public class BLL_LoaiTaiKhoan : ILoaiTaiKhoan_BLL
    {
        private ILoaiTaiKhoan _res;
        public BLL_LoaiTaiKhoan(ILoaiTaiKhoan res)
        {
            _res = res;
        }
        public List<LoaiTaiKhoan> sp_TimKiemLoaiTaiKhoan(string TenLoaiTK)
        {
            return _res.sp_TimKiemLoaiTaiKhoan(TenLoaiTK);
        }
        public List<LoaiTaiKhoan> sp_TimKiemLoaiTaiKhoantheoma(int MaLoaiTK)
        {
            return _res.sp_TimKiemLoaiTaiKhoantheoma(MaLoaiTK);
        }
        public bool sp_ThemLoaiTaiKhoan(LoaiTaiKhoan ltk)
        {
            return _res.sp_ThemLoaiTaiKhoan(ltk);
        }
        public bool sp_XoaLoaiTaiKhoan(int MaLoaiTK)
        {
            return _res.sp_XoaLoaiTaiKhoan(MaLoaiTK);
        }
        public bool sp_SuaLoaiTaiKhoan(LoaiTaiKhoan ltk)
        {
            return _res.sp_SuaLoaiTaiKhoan(ltk);
        }
    }
}
