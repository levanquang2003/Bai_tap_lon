using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public partial interface ISanPham_BLL
    {
        bool Create_SP(SanPham sp);
        SanPham GetSP_byID(string MaSP);
        bool Update_SP(SanPham sp);
        bool Delete_SP(string MaSP);
    }
}
