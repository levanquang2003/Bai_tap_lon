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
    public class BLL_HoaDonBan : IHoaDonBan_BLL
    {
        private IHoaDonBan _res;
        public BLL_HoaDonBan(IHoaDonBan res)
        {
            _res = res;
        }
        public bool Create_HDB(HoaDonBan hdb)
        {
            return _res.Create_HDB(hdb);
        }
        public bool Delete_HDB(int MaHDB)
        {
            return _res.Delete_HDB(MaHDB);
        }
        public bool ConFirm_HDB(int MaHDB)
        {
            return _res.ConFirm_HDB(MaHDB);
        }
    }
}
