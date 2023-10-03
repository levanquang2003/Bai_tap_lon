using BusinessLogicLayer.Interfaces;
using DataModel;
using Microsoft.AspNetCore.Mvc;

namespace QuanLyCuaHangVemouse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiTaiKhoanControllers : Controller
    {
        private ILoaiTaiKhoan_BLL _LoaiTKBLL;
        public LoaiTaiKhoanControllers(ILoaiTaiKhoan_BLL LoaiTKBLL)
        {
            _LoaiTKBLL = LoaiTKBLL;
        }
        [Route("TimKiemLoaiTKTheoMa")]
        [HttpGet]
        public LoaiTaiKhoan sp_TimKiemLoaiTaiKhoantheoma(string MaLoaiTK)
        {
            return _LoaiTKBLL.sp_TimKiemLoaiTaiKhoantheoma(MaLoaiTK);
        }
        [Route("TimKiemLoaiTKTheoTen")]
        [HttpGet]
        public LoaiTaiKhoan sp_TimKiemLoaiTaiKhoan(string TenSP)
        {
            return _LoaiTKBLL.sp_TimKiemLoaiTaiKhoan(TenSP);
        }
        [Route("ThemLoaiTK")]
        [HttpPost]
        public LoaiTaiKhoan sp_ThemLoaiTaiKhoan([FromBody] LoaiTaiKhoan ltk)
        {
            _LoaiTKBLL.sp_ThemLoaiTaiKhoan(ltk);
            return ltk;
        }
        [Route("SuaThongTinLoaiTK")]
        [HttpPut]
        public LoaiTaiKhoan sp_SuaLoaiTaiKhoan([FromBody] LoaiTaiKhoan ltk)
        {
            _LoaiTKBLL.sp_SuaLoaiTaiKhoan(ltk);
            return ltk;
        }
        [Route("XoaLoaiTK")]
        [HttpDelete]
        public IActionResult sp_XoaLoaiTaiKhoan([FromBody] string MaLoaiTK)
        {
            _LoaiTKBLL.sp_XoaLoaiTaiKhoan(MaLoaiTK);
            return Ok();
        }
    }
}
