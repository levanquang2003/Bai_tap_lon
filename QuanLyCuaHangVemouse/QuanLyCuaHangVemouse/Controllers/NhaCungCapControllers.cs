using BusinessLogicLayer.Interfaces;
using DataModel;
using Microsoft.AspNetCore.Mvc;

namespace QuanLyCuaHangVemouse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhaCungCapControllers: ControllerBase
    {
        private INhaCungCap_BLL _NhaCungCapBLL;
        public NhaCungCapControllers(INhaCungCap_BLL NhaCungCapBLL)
        {
            _NhaCungCapBLL = NhaCungCapBLL;
        }
        [Route("TimKiemNCC")]
        [HttpGet]
        public NhaCungCap GetNCCbyID(string id)
        {
            return _NhaCungCapBLL.GetNCC_byID(id);
        }
        [Route("ThemNCC")]
        [HttpPost]
        public NhaCungCap CreateNCC([FromBody] NhaCungCap ncc)
        {
            _NhaCungCapBLL.Create_NCC(ncc);
            return ncc;
        }
        [Route("SuaNCC")]
        [HttpPut]
        public NhaCungCap Update_NCC([FromBody] NhaCungCap ncc)
        {
            _NhaCungCapBLL.Update_NCC(ncc);
            return ncc;
        }
        [Route("XoaNCC")]
        [HttpDelete]
        public IActionResult Delete_NCC([FromBody] string mancc)
        {
            _NhaCungCapBLL.Delete_NCC(mancc);
            return Ok();
        }
    }
}
