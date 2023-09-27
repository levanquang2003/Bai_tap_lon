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
        [Route("get-byid/{id}")]
        [HttpGet]
        public SanPham GetSPbyID(string id)
        {
            return _SanPhamBLL.GetSP_byID(id);
        }
        [Route("create-sanpham")]
        [HttpPost]
        public SanPham CreateSP([FromBody] SanPham sp)
        {
            _SanPhamBLL.Create_SP(sp);
            return sp;
        }
        [Route("update_sanpham")]
        [HttpPut]
        public SanPham Update_SP([FromBody] SanPham sp)
        {
            _SanPhamBLL.Update_SP(sp);
            return sp;
        }
        [Route("delete_sanpham")]
        [HttpDelete]
        public IActionResult Delete_SP([FromBody] string masp)
        {
            _SanPhamBLL.Delete_SP(masp);
            return Ok();
        }
    }
}
