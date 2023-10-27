using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace QuanLyCuaHangVemouse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoaDonBanControllers : ControllerBase
    {
        private IHoaDonBan_BLL _HoaDonBanBLL;
        public HoaDonBanControllers(IHoaDonBan_BLL HoaDonBanBLL)
        {
            _HoaDonBanBLL = HoaDonBanBLL;
        }
        [Route("Delete_HDB")]
        [HttpDelete]
        public IActionResult Delete_HDB([FromBody] int MaHDB)
        {
            _HoaDonBanBLL.Delete_HDB(MaHDB);
            return Ok();
        }
        [Route("ConFirm_HDB")]
        [HttpPut]
        public IActionResult ConFirm_HDB([FromBody] int MaHDB)
        {
            _HoaDonBanBLL.ConFirm_HDB(MaHDB);
            return Ok();
        }
    }
}
