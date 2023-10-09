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
        public List<SanPham> sp_TimKiemSanPhamTheoMa(int MaSP)
        {
            return _SanPhamBLL.sp_TimKiemSanPhamTheoMa(MaSP);
        }
        [Route("TimKiemSanPhamTheoTen")]
        [HttpGet]
        public List<SanPham> sp_TimKiemSanPhamTheoTen(string TenSP)
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
        public IActionResult sp_SuaSLBanSanPham(int MaSP, int SoLuongBan)
        {
            bool check = _SanPhamBLL.sp_SuaSLBanSanPham(MaSP, SoLuongBan);
            if (check)
            {
                return Ok("Sua so luong thanh cong");
            }
            return BadRequest("Sua so luong khong thanh cong");
        }
        [Route("XoaSanPham")]
        [HttpDelete]
        public IActionResult Delete_SP([FromBody] int MaSP)
        {
            _SanPhamBLL.sp_XoaSanPham(MaSP);
            return Ok();
        }
    }
}
