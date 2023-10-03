using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public partial interface ITheLoai_BLL
    {
        bool sp_ThemTL(TheLoai tl);
        TheLoai sp_TimKiemTL(string MaLoai);
        bool sp_SuaTL(TheLoai tl);
        bool sp_XoaTL(string MaLoai);
    }
}
