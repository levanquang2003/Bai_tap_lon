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
        List<LoaiTaiKhoan> sp_TimKiemLoaiTaiKhoantheoma(int MaLoaiTK);
        List<LoaiTaiKhoan> sp_TimKiemLoaiTaiKhoan(string TenLoaiTK);
        bool sp_SuaLoaiTaiKhoan(LoaiTaiKhoan ltk);
        bool sp_XoaLoaiTaiKhoan(int MaLoaiTK);
    }
}
