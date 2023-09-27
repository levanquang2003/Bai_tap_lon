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
    public class BLL_SanPham : ISanPham_BLL
    {
        private ISanPham _res;
        public BLL_SanPham(ISanPham res)
        {
            _res = res;
        }
        public SanPham GetSP_byID(string id)
        {
            return _res.GetSP_byID(id);
        }
        public bool Create_SP(SanPham model)
        {
            return _res.Create_SP(model);
        }
        public bool Delete_SP(string MaSP)
        {
            return _res.Delete_SP(MaSP);
        }
        public bool Update_SP(SanPham model)
        {
            return _res.Update_SP(model);
        }
    }
}
