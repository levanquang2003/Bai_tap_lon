using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API_User.Controllers
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
    }
}
