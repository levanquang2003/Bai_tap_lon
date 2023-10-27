using DataAccessLayer.Interfaces;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DAL_HoaDonBan : IHoaDonBan
    {
        private IDatabaseHelper _dbHelper;
        public DAL_HoaDonBan(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public bool Create_HDB(HoaDonBan hdb)
        {

            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_CreateDonHangBan",
                    "@TrangThai", 0,
                    "@NgayTao", DateTime.Now,
                    "@TenKH", hdb.TenKH,
                    "@Diachi", hdb.DiaChi,
                    "@Email", hdb.Email,
                    "@SDT", hdb.SDT,
                    "@DiaChiGiaoHang", hdb.DiaChiGiaoHang,
                    "@ThoiGianGiaoHang", DateTime.Now.AddDays(2),
                    "list_json_chitietHDB", hdb.ChiTietHoaDonBan != null ? MessageConvert.SerializeObject(hdb.ChiTietHoaDonBan) : null);
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
        public bool Delete_HDB(int MaHDB)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_Delete_DonHangBan",
                    "@MaHDB", MaHDB);
                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError + result.ToString());
                }
                return string.IsNullOrEmpty(msgError) ? true : false;
            }
            catch (Exception ex) 
            { 
                throw ex; 
            }
        }
        public bool ConFirm_HDB(int MaHDB)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_XacNhan_HDB",
                    "@MaHDB", MaHDB);

                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError + result.ToString());
                }
                return string.IsNullOrEmpty(msgError) ? true : false;
            }
            catch (Exception ex) 
            {
                throw ex; 
            }
        }
    }
}
