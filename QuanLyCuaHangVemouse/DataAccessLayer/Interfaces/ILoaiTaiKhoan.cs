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
        LoaiTaiKhoan sp_TimKiemLoaiTaiKhoan(string TenLoaiTK);
        LoaiTaiKhoan sp_TimKiemLoaiTaiKhoantheoma(string MaLoaiTK);
        bool sp_ThemLoaiTaiKhoan(LoaiTaiKhoan ltk);
        bool sp_SuaLoaiTaiKhoan(LoaiTaiKhoan ltk);
        bool sp_XoaLoaiTaiKhoan(string MaLoaiTK);
    }
}
