using BusinessLogicLayer.Interfaces;
using DataModel;
using Microsoft.AspNetCore.Mvc;

namespace QuanLyCuaHangVemouse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TheLoaiControllers : Controller
    {
        private ITheLoai_BLL _TheLoaiBLL;
        public TheLoaiControllers(ITheLoai_BLL TheLoaiBLL)
        {
            _TheLoaiBLL = TheLoaiBLL;
        }
        [Route("TimKiemTL")]
        [HttpGet]
        public TheLoai sp_TimKiemTL(string id)
        {
            return _TheLoaiBLL.sp_TimKiemTL(id);
        }
        [Route("ThemTL")]
        [HttpPost]
        public TheLoai sp_ThemTL([FromBody] TheLoai tl)
        {
            _TheLoaiBLL.sp_ThemTL(tl);
            return tl;
        }
        [Route("SuaTL")]
        [HttpPut]
        public TheLoai sp_SuaTL([FromBody] TheLoai tl)
        {
            _TheLoaiBLL.sp_SuaTL(tl);
            return tl;
        }
        [Route("XoaTL")]
        [HttpDelete]
        public IActionResult sp_XoaTL([FromBody] string maloai)
        {
            _TheLoaiBLL.sp_XoaTL(maloai);
            return Ok();
        }
    }
}
