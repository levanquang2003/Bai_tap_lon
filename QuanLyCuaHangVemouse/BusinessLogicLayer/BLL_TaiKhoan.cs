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
    public class BLL_TaiKhoan:ITaiKhoan_BLL
    {
        private ITaiKhoan _res;
        public BLL_TaiKhoan(ITaiKhoan res)
        {
            _res = res;
        }
        public bool DangNhap(string TenTK, string MatKhau)
        {
            return _res.DangNhap(TenTK, MatKhau);
        }
    }
}
