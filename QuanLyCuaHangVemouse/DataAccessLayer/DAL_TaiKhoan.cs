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
                     ,"@MatKhau",MatKhau
                     );
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
    }
}
