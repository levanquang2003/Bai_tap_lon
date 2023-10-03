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
        public SanPham sp_TimKiemSanPhamTheoTen(string TenSP)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_TimKiemSanPhamTheoTen",
                     "@TenSP", TenSP);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<SanPham>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public SanPham sp_TimKiemSanPhamTheoMa(string MaSP)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_TimKiemSanPhamTheoMa",
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
        public bool sp_ThemSanPham(SanPham sp)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_ThemSanPham",
                "@MaSP", sp.MaSP,
                "@TenSP", sp.TenSP,
                "@Size", sp.Size,
                "@GiaBan", sp.GiaBan,
                "@GiaGiam", sp.GiaGiam,
                "@MaLoai", sp.MaLoai,
                "@SoLuongTon", sp.SoLuongTon,
                "@SoLuongBan", sp.SoLuongBan,
                "@ImageURL", sp.ImageUrl,
                "@Mota", sp.Mota,
                "@TrangThai", sp.TrangThai);
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
        public bool sp_SuaThongTinSanPham(SanPham sp)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_SuaThongTinSanPham",
                "@MaSP", sp.MaSP,
                "@TenSP", sp.TenSP,
                "@Size", sp.Size,
                "@GiaBan", sp.GiaBan,
                "@GiaGiam", sp.GiaGiam,
                "@MaLoai", sp.MaLoai,
                "@SoLuongTon", sp.SoLuongTon,
                "@ImageURL", sp.ImageUrl,
                "@Mota", sp.Mota,
                "@TrangThai", sp.TrangThai);
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
        public bool sp_SuaSLBanSanPham(SanPham sp)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_SuaSLBanSanPham",
                "@MaSP", sp.MaSP,
                "@SoLuongBan", sp.SoLuongBan);
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
        public bool sp_XoaSanPham(string MaSP)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_XoaSanPham",
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
