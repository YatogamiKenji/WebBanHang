using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebBanHang.Models;
using WebBanHang.ViewModels;
using X.PagedList;

namespace WebBanHang.Controllers
{
    public class HomeController : Controller
    {
        QlcuocSongContext db = new QlcuocSongContext();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(int? page)
        {
            int pageSize = 8;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var listHD = db.DanhMucHoatDongs.AsNoTracking().OrderBy(x => x.TenHd);
            PagedList<DanhMucHoatDong> lst = new PagedList<DanhMucHoatDong>(listHD, pageNumber, pageSize);
            return View(lst);
        }
        public IActionResult ChiTietHoatDong(string maHD)
        {
            var hoatDong = db.DanhMucHoatDongs.SingleOrDefault(x => x.MaHd == maHD);
            var anhHoatDong = db.AnhHds.Where(x => x.MaHd == maHD).ToList();
            ViewBag.anhHoatDong = anhHoatDong;
            return View(hoatDong);
        } 
        public IActionResult HoatDongTheoLoai(string maLoaiHD, int? page)
        {
            int pageSize = 8;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var listHD = db.DanhMucHoatDongs.AsNoTracking().Where(x=>x.MaLoaiHd == maLoaiHD).OrderBy(x => x.TenHd);
            PagedList<DanhMucHoatDong> lst = new PagedList<DanhMucHoatDong>(listHD, pageNumber, pageSize);
            ViewBag.maLoaiHD = maLoaiHD;
            return View(lst);
        }
        public IActionResult ActivitiesDetail(string maHD)
        {
            var hoatDong = db.DanhMucHoatDongs.SingleOrDefault(x => x.MaHd == maHD);
            var chiTiet = db.ChiTietHoatDongs.SingleOrDefault(x => x.MaHd == maHD);
            var anhHoatDong = db.AnhHds.Where(x => x.MaHd == maHD).ToList();
            var actDetViewModel = new ActivitiesDetailViewModel 
            { 
                anhHds = anhHoatDong, 
                danhMucHoatDong = hoatDong, 
                chiTietHoatDong = chiTiet 
            };
            return View(actDetViewModel);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
