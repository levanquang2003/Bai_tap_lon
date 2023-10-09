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
        public bool TaoTK(string TenTK, string MatKhau, int LoaiTK)
        {
            return _res.TaoTK(TenTK, MatKhau, LoaiTK);
        }
        public bool SuaTK(TaiKhoan tk)
        {
            return _res.SuaTK(tk);
        }
        public bool XoaTK(string TenTK)
        {
            return _res.XoaTK(TenTK);
        }
        public bool DoiMatKhau(string TenTK, string MatKhauMoi)
        {
            return _res.DoiMatKhau(TenTK, MatKhauMoi);
        }
        public TaiKhoan InfoUser(string TenTK)
        {
            if (_res.InfoUser(TenTK)== null)
            {
                return null;
            }
            return _res.InfoUser(TenTK);
        }
    }
}
