using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace QuanLyCuaHangVemouse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaiKhoanControllers : ControllerBase
    {
        private ITaiKhoan_BLL _TaiKhoanBLL;
        public TaiKhoanControllers(ITaiKhoan_BLL TaiKhoanBLL)
        {
            _TaiKhoanBLL = TaiKhoanBLL;
        }
        [Route("login")]
        [HttpPost]
        public IActionResult DangNhap(string TenTK, string MatKhau)
        {
            bool check = _TaiKhoanBLL.DangNhap(TenTK, MatKhau);
            if (check == true)
            {
                return Ok("ok");

            }
            return BadRequest("không");
        }
    }
}
