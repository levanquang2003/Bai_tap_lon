using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public partial interface ISanPham
    {
        bool Create_SP(SanPham nv);
        SanPham GetSP_byID(string MaSP);
        bool Update_SP(SanPham sp);
        bool Delete_SP(string MaSp);
    }
}
