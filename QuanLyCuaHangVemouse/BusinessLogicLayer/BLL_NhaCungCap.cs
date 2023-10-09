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
    public class BLL_NhaCungCap:INhaCungCap_BLL
    {
        private INhaCungCap _res;
        public BLL_NhaCungCap(INhaCungCap res)
        {
            _res = res;
        }
        public NhaCungCap GetNCC_byID(int MaNCC)
        {
            return _res.GetNCC_byID(MaNCC);
        }
        public bool Create_NCC(NhaCungCap ncc)
        {
            return _res.Create_NCC(ncc);
        }
        public bool Delete_NCC(int MaNCC)
        {
            return _res.Delete_NCC(MaNCC);
        }
        public bool Update_NCC(NhaCungCap ncc)
        {
            return (_res.Update_NCC(ncc));
        }
    }
}
