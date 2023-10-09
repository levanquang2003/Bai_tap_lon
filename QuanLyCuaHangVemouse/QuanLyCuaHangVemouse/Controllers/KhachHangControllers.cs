using BusinessLogicLayer.Interfaces;
using DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace QuanLyCuaHangVemouse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhachHangControllers : ControllerBase
    {
        private IKhachHang_BLL _KhachHangBLL;
        public KhachHangControllers(IKhachHang_BLL KhachHangBLL)
        {
            _KhachHangBLL = KhachHangBLL;
        }
        [Route("TimKiemKH")]
        [HttpGet]
        public KhachHang GetKH_byID(int MaKH)
        {
            return _KhachHangBLL.GetKH_ByID(MaKH);
        }
        [Route("ThemKH")]
        [HttpPost]
        public KhachHang CreateKH([FromBody] KhachHang kh)
        {
            _KhachHangBLL.Create_KH(kh);
            return kh;
        }
        [Route("SuaKH")]
        [HttpPut]
        public KhachHang Update_KH([FromBody] KhachHang kh)
        {
            _KhachHangBLL.Update_KH(kh);
            return kh;
        }
        [Route("XoaKH")]
        [HttpDelete]
        public IActionResult Delete_KH([FromBody] int MaKH)
        {
            _KhachHangBLL.Delete_KH(MaKH);
            return Ok();
        }
    }
}
