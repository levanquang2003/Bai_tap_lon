using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public partial interface ITheLoai
    {
        bool Create_TL(TheLoai tl);
        TheLoai GetTL_byID(string MaLoai);
        bool Update_TL(TheLoai tl);
        bool Delete_TL(string MaLoai);
    }
}
