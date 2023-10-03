using BusinessLogicLayer.Interfaces;
using DataModel;
using Microsoft.AspNetCore.Mvc;

namespace QuanLyCuaHangVemouse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamControllers : ControllerBase
    {
        private ISanPham_BLL _SanPhamBLL;
        public SanPhamControllers(ISanPham_BLL SanPhamBLL)
        {
            _SanPhamBLL = SanPhamBLL;
        }
        [Route("TimKiemSanPhamTheoMa")]
        [HttpGet]
        public SanPham sp_TimKiemSanPhamTheoMa(string id)
        {
            return _SanPhamBLL.sp_TimKiemSanPhamTheoMa(id);
        }
        [Route("TimKiemSanPhamTheoTen")]
        [HttpGet]
        public SanPham sp_TimKiemSanPhamTheoTen(string TenSP)
        {
            return _SanPhamBLL.sp_TimKiemSanPhamTheoTen(TenSP);
        }
        [Route("ThemSanPham")]
        [HttpPost]
        public SanPham sp_ThemSanPham([FromBody] SanPham sp)
        {
            _SanPhamBLL.sp_ThemSanPham(sp);
            return sp;
        }
        [Route("SuaThongTinSanPham")]
        [HttpPut]
        public SanPham sp_SuaThongTinSanPham([FromBody] SanPham sp)
        {
            _SanPhamBLL.sp_SuaThongTinSanPham(sp);
            return sp;
        }
        [Route("SuaSLBanSanPham")]
        [HttpPut]
        public SanPham sp_SuaSLBanSanPham([FromBody] SanPham sp)
        {
            _SanPhamBLL.sp_SuaSLBanSanPham(sp);
            return sp;
        }
        [Route("XoaSanPham")]
        [HttpDelete]
        public IActionResult Delete_SP([FromBody] string MaSP)
        {
            _SanPhamBLL.sp_XoaSanPham(MaSP);
            return Ok();
        }
    }
}
