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

        [Route("search_SP")]
        [HttpPost]
        public IActionResult SearchSanPham([FromBody] Dictionary<string, object> ch)
        {
            try
            {
                int page = ch.ContainsKey("page") ? Convert.ToInt32(ch["page"].ToString()) : 1;
                int pageSize = ch.ContainsKey("pageSize") ? Convert.ToInt32(ch["pageSize"].ToString()) : 10;
                string tenSanPham = ch.ContainsKey("tenSanPham") ? Convert.ToString(ch["tenSanPham"].ToString()) : "";
                string tenTheLoai = ch.ContainsKey("tenTheLoai") ? Convert.ToString(ch["tenTheLoai"].ToString()) : "";
                string giatien = ch.ContainsKey("giatien") ? Convert.ToString(ch["giatien"].ToString()) : "";

                int total = 0;
                var data = _SanPhamBLL.SearchSP(page, pageSize, out total, tenSanPham, tenTheLoai, giatien);

                return Ok(new
                {
                    TotalItems = total,
                    Data = data,
                    Page = page,
                    PageSize = pageSize
                });
            }
            catch (Exception ex)
            {
                return BadRequest($"Lỗi: {ex.Message}");
            }
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
