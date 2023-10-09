﻿using DataAccessLayer.Interfaces;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DAL_NhaCungCap:INhaCungCap
    {
        private IDatabaseHelper _dbHelper;
        public DAL_NhaCungCap(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public NhaCungCap GetNCC_byID(int MaNCC)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_searchNCC_by_MaNCC",
                     "@MaNCC", MaNCC);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<NhaCungCap>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Create_NCC(NhaCungCap ncc)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_nhacungcap_create",
                "@MaNCC", ncc.MaNCC,
                "@TenNCC", ncc.TenNCC,
                "@DiaChi", ncc.DiaChi,
                "@SoDienthoai", ncc.SoDienthoai,
                "@Email", ncc.Email);
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
        public bool Update_NCC(NhaCungCap ncc)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_nhacungcap_update",
                "@MaNCC", ncc.MaNCC,
                "@TenNCC", ncc.TenNCC,
                "@DiaChi", ncc.DiaChi,
                "@SoDienthoai", ncc.SoDienthoai,
                "@Email", ncc.Email);
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
        public bool Delete_NCC(int MaNCC)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_DeleteNCC",
                     "@MaNCC", MaNCC);
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
