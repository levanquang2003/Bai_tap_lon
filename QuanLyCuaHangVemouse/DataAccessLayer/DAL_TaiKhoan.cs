using DataAccessLayer.Interfaces;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DAL_TaiKhoan : ITaiKhoan
    {
        private IDatabaseHelper _dbHelper;
        public DAL_TaiKhoan(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public bool DangNhap(string TenTK,string MatKhau)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_DangNhap",
                     "@TenTK", TenTK
                     ,"@MatKhau",MatKhau);
                int tk=dt.ConvertTo<TaiKhoan>().Count;
                if (tk>0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public TaiKhoan InfoUser(string TenTK)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_InfoUser",
                    "@TenTK", TenTK);
                if (!string.IsNullOrEmpty(msgError))
                {
                    return null;
                }
                return dt.ConvertTo<TaiKhoan>().FirstOrDefault();
            }
            catch (Exception ex) { 
                throw new Exception(msgError, ex); 
            }
        }
        public bool TaoTK(string TenTK, string MatKhau, int LoaiTK)
        {
            string msgError = "";
            try
            {
                int count = InfoUser(TenTK) != null ? 1 : 0;
                if (count == 1)
                {
                    return false;
                }
                var dt = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_ThemTaiKhoan",
                     "@TenTK", TenTK,
                     "@MatKhau", MatKhau,
                     "@LoaiTK", LoaiTK);
                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }
                bool check = string.IsNullOrEmpty(msgError) == true ? true : false;
                return check;

            }
            catch (Exception ex) { 
                throw new Exception(msgError, ex); 
            }
        }
        public bool SuaTK(TaiKhoan tk)
        {
            string msgError = "";
            try
            {
                var Check = InfoUser(tk.TenTK);
                if (Check == null)
                {
                    return false;
                }
                var dt = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_CapNhatTaiKhoan",
                    "@TenTK", tk.TenTK,
                    "@Email", tk.Email,
                    "@HoTen", tk.HoTen,
                    "@DiaChi", tk.DiaChi,
                    "@SDT", tk.SDT,
                    "@Avatar", tk.Avatar);
                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }
                bool check = string.IsNullOrEmpty(msgError) == true ? true : false;
                return check;
            }
            catch (Exception ex) { 
                throw new Exception(msgError, ex); 
            }
        }
        public bool XoaTK(string TenTK)
        {
            string msgError = "";
            try
            {
                int FindTK = InfoUser(TenTK) != null ? 1 : 0;
                if (FindTK == 0)
                {
                    return false;
                }
                var dt = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_XoaTaiKhoan",
                    "@TenTK", TenTK);
                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }
                bool check = string.IsNullOrEmpty(msgError) == true ? true : false;
                return check;
            }
            catch (Exception ex) { 
                throw new Exception(msgError, ex); 
            }
        }
        public bool DoiMatKhau(string TenTK, string MatKhauMoi)
        {
            string msgError = "";
            try
            {
                int FindTK = InfoUser(TenTK) != null ? 1 : 0;
                if (FindTK == 0)
                {
                    return false;
                }
                var dt = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_DoiMatKhau",
                    "@TenTK", TenTK,
                    "@MatKhauMoi", MatKhauMoi);
                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }
                bool check = string.IsNullOrEmpty(msgError) == true ? true : false;
                return check;
            }
            catch (Exception ex) { throw new Exception(msgError, ex); }
        }
    }
}
