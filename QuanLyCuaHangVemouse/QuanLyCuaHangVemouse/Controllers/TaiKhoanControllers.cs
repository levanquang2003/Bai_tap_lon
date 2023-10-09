using BusinessLogicLayer.Interfaces;
using DataModel;
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
        [Route("DangNhap")]
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
        [Route("TaoTK")]
        [HttpPost]
        public async Task<IActionResult> TaoTK(string TenTK, string MatKhau)
        {
            if (_TaiKhoanBLL.TaoTK(TenTK, MatKhau, 1))
            {
                return Ok("Đăng kí Thành Công");
            }
            return BadRequest("Đăng kí không thành công");
        }
        [Route("SuaTK")]
        [HttpPut]
        public async Task<IActionResult> SuaTK([FromBody] TaiKhoan tk)
        {
            if (_TaiKhoanBLL.SuaTK(tk))
            {
                return Ok("Cập Nhật Thành Công");
            }
            return BadRequest("Cập nhập không thành công");
        }
        [Route("XoaTK")]
        [HttpDelete]
        public async Task<IActionResult> XoaTK(string tk)
        {
            if (_TaiKhoanBLL.XoaTK(tk))
            {
                return Ok("Xóa Thành Công");
            }
            return BadRequest("Xóa không thành công");
        }
        [Route("DoiMatKhau")]
        [HttpPut]
        public async Task<IActionResult> DoiMatKhau(string TenTk, string MatKhauMoi)
        {
            if (_TaiKhoanBLL.DoiMatKhau(TenTk, MatKhauMoi))
            {
                return Ok("Đổi mật khẩu Thành Công");
            }
            return BadRequest("Đổi mật khẩu không thành công");
        }
        [Route("InfoUser")]
        [HttpGet]
        public TaiKhoan InfoUser(string TenTK)
        {
            return _TaiKhoanBLL.InfoUser(TenTK);
        }
    }
}
