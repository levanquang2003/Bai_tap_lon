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
        public List<SanPham>? sp_TimKiemSanPhamTheoTen(string TenSP)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_TimKiemSanPhamTheoTen",
                     "@TenSP", TenSP);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<SanPham>().ToList().Count>0?dt.ConvertTo<SanPham>().ToList():null;
            }
            catch (Exception ex)
            {
                throw new Exception(msgError, ex);
            }
        }
        public List<SanPham> sp_TimKiemSanPhamTheoMa(int MaSP)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_TimKiemSanPhamTheoMa",
                     "@MaSP", MaSP);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<SanPham>().ToList().Count > 0 ? dt.ConvertTo<SanPham>().ToList() : null;
            }
            catch (Exception ex)
            {
                throw new Exception(msgError, ex);
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
                "@ImageURL", sp.ImageURL,
                "@Mota", sp.MoTa,
                "@TrangThai", sp.TrangThai);
                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }
                return string.IsNullOrEmpty(msgError) == true ? true : false;
            }
            catch (Exception ex)
            {
                throw new Exception(msgError, ex);
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
                "@ImageURL", sp.ImageURL,
                "@Mota", sp.MoTa,
                "@TrangThai", sp.TrangThai);
                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }
                return string.IsNullOrEmpty(msgError) == true ? true : false;
            }
            catch (Exception ex)
            {
                throw new Exception(msgError, ex);
            }
        }
        public bool sp_SuaSLBanSanPham(int MaSP, int SoLuongBan)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_SuaSLBanSanPham",
                "@MaSP", MaSP,
                "@SoLuongBan", SoLuongBan);
                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }
                return string.IsNullOrEmpty(msgError) == true ? true : false;
            }
            catch (Exception ex)
            {
                throw new Exception(msgError, ex);
            }
        }
        public bool sp_XoaSanPham(int MaSP)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_XoaSanPham",
                     "@MaSP", MaSP);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return string.IsNullOrEmpty(msgError) == true ? true : false;
            }
            catch (Exception ex)
            {
                throw new Exception(msgError, ex);
            }
        }
    }
}
