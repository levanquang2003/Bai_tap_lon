using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public partial interface ITaiKhoan
    {
        bool DangNhap(string TenTK, string MatKhau);
        bool TaoTK(string TenTK, string MatKhau, int LoaiTK);
        bool SuaTK(TaiKhoan tk);
        bool XoaTK(string TenTK);
        bool DoiMatKhau(string TenTK, string MatKhauMoi);
        TaiKhoan InfoUser(string TenTK);
    }
}
