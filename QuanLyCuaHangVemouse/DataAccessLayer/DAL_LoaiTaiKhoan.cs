using DataAccessLayer.Interfaces;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DAL_LoaiTaiKhoan : ILoaiTaiKhoan
    {
        private IDatabaseHelper _dbHelper;
        public DAL_LoaiTaiKhoan(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public bool Create(LoaiTaiKhoan LoaiTK)
        {
            throw new NotImplementedException();
        }

        public LoaiTaiKhoan sp_TimKiemLoaiTaiKhoan(string TenLoaiTK)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_TimKiemLoaiTaiKhoan",
                     "@TenLoaiTK", TenLoaiTK);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<LoaiTaiKhoan>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public LoaiTaiKhoan sp_TimKiemLoaiTaiKhoantheoma(string MaLoaiTK)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_TimKiemLoaiTaiKhoantheoma",
                     "@MaLoaiTK", MaLoaiTK);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<LoaiTaiKhoan>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool sp_ThemLoaiTaiKhoan(LoaiTaiKhoan ltk)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_ThemLoaiTaiKhoan",
                "@MaLoaiTK", ltk.MaLoaiTK,
                "@TenLoaiTK", ltk.TenLoaiTK);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool sp_SuaLoaiTaiKhoan(LoaiTaiKhoan ltk)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_SuaLoaiTaiKhoan",
                "@MaLoaiTK", ltk.MaLoaiTK,
                "@TenLoaiTK", ltk.TenLoaiTK);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool sp_XoaLoaiTaiKhoan(string MaLoaiTK)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_XoaLoaiTaiKhoan",
                     "@MaLoaiTK", MaLoaiTK);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
