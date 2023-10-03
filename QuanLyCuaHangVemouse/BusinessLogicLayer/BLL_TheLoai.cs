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
    public class BLL_TheLoai:ITheLoai_BLL
    {
        private ITheLoai _res;
        public BLL_TheLoai(ITheLoai res)
        {
            _res = res;
        }
        public TheLoai sp_TimKiemTL(string id)
        {
            return _res.sp_TimKiemTL(id);
        }
        public bool sp_ThemTL(TheLoai model)
        {
            return _res.sp_ThemTL(model);
        }
        public bool sp_XoaTL(string MaLoai)
        {
            return _res.sp_XoaTL(MaLoai);
        }
        public bool sp_SuaTL(TheLoai model)
        {
            return _res.sp_SuaTL(model);
        }
    }
}
