using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public partial interface ILoaiTaiKhoan
    {
        List<LoaiTaiKhoan> sp_TimKiemLoaiTaiKhoan(string TenLoaiTK);
        List<LoaiTaiKhoan> sp_TimKiemLoaiTaiKhoantheoma(int MaLoaiTK);
        bool sp_ThemLoaiTaiKhoan(LoaiTaiKhoan ltk);
        bool sp_SuaLoaiTaiKhoan(LoaiTaiKhoan ltk);
        bool sp_XoaLoaiTaiKhoan(int MaLoaiTK);
    }
}
