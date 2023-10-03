using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public partial interface ILoaiTaiKhoan_BLL
    {
        bool sp_ThemLoaiTaiKhoan(LoaiTaiKhoan ltk);
        LoaiTaiKhoan sp_TimKiemLoaiTaiKhoantheoma(string MaLoaiTK);
        LoaiTaiKhoan sp_TimKiemLoaiTaiKhoan(string MaLoaiTK);
        bool sp_SuaLoaiTaiKhoan(LoaiTaiKhoan ltk);
        bool sp_XoaLoaiTaiKhoan(string MaLoaiTK);
    }
}
