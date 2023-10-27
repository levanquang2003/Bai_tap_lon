using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public partial interface IHoaDonBan_BLL
    {
        bool Create_HDB(HoaDonBan hdb);
        bool Delete_HDB(int MaHDB);
        bool ConFirm_HDB(int MaHDB);
    }
}
