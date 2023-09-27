using DataAccessLayer.Interfaces;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DAL_SanPham : ISanPham
    {
        private IDatabaseHelper _dbHelper;
        public DAL_SanPham(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public SanPham GetSP_byID(string MaSP)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_searchNV_by_MaNV",
                     "@MaSP", MaSP);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<SanPham>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Create_SP(SanPham sp)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_nhanvien_create",
                "@MaSP", sp.MaSP,
                "@TenMH", sp.TenMH,
                "@Size", sp.Size,
                "@GiaBan", sp.GiaBan,
                "@MaLoai", sp.MaLoai,
                "@SoLuongTon", sp.SoLuongTon,
                "@ImageURL", sp.ImageUrl,
                "@Mota", sp.Mota);
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
        public bool Update_SP(SanPham sp)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_nhanvien_update",
               "@MaSP", sp.MaSP,
                "@TenMH", sp.TenMH,
                "@Size", sp.Size,
                "@GiaBan", sp.GiaBan,
                "@MaLoai", sp.MaLoai,
                "@SoLuongTon", sp.SoLuongTon,
                "@ImageURL", sp.ImageUrl,
                "@Mota", sp.Mota);
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
        public bool Delete_SP(string MaSP)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_DeleteNV",
                     "@MaSP", MaSP);
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
