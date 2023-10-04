using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public partial interface ITaiKhoan_BLL
    {
        bool DangNhap(string taikhoan, string matkhau);
    }
}
