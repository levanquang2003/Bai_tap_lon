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
        bool sp_ThemTL(TheLoai tl);
        TheLoai sp_TimKiemTL(int MaLoai);
        bool sp_SuaTL(TheLoai tl);
        bool sp_XoaTL(int MaLoai);
    }
}
