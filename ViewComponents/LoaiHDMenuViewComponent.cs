using WebBanHang.Models;
using Microsoft.AspNetCore.Mvc;
using WebBanHang.Repository;
namespace WebBanHang.ViewComponents
{
    public class LoaiHDMenuViewComponent: ViewComponent
    {
        private readonly ILoaiHDRepository _loaiHD;
        public LoaiHDMenuViewComponent(ILoaiHDRepository loaiHDRepository)
        {
            _loaiHD = loaiHDRepository;
        }
        public IViewComponentResult Invoke()
        {
            var loaiHD= _loaiHD.GetAllLoaiHD().OrderBy(x =>x.TenLoaiHd);
            return View(loaiHD);
        }
    }
}
