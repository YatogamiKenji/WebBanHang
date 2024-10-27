using WebBanHang.Models;
namespace WebBanHang.ViewModels
{
    public class ActivitiesDetailViewModel
    {
        public DanhMucHoatDong danhMucHoatDong { get; set; }
        public ChiTietHoatDong chiTietHoatDong { get; set; }
        public List<AnhHd> anhHds { get; set; }
    }
}
