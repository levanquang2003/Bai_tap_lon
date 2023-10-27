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

        public List<SanPham> SearchSP(int pageIndex, int pageSize, out int total, string TenSanPham, string TenTheLoai, string giatien)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_TimKiemVaPhanTrang",
                    "@page_index ", pageIndex,
                    "@page_size", pageSize,
                    "@ten_sanpham", TenSanPham,
                    "@gia_tien", giatien,
                    "@ten_theloai ", TenTheLoai
                    );
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (int)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<SanPham>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SanPham> sp_TimKiemSanPhamTheoTen(string TenSP)
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
                "@SoLuongBan",sp.SoLuongBan,
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
