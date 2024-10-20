using WebBanHang.Models;
namespace WebBanHang.Repository
{
    public interface ILoaiHDRepository
    {
        LoaiHoatDong Add(LoaiHoatDong loaiHD);
        LoaiHoatDong Update(LoaiHoatDong loaiHD);
        LoaiHoatDong Delete(string maLoaiHD);
        LoaiHoatDong? GetLoaiHD(string maLoaiHD);
        IEnumerable<LoaiHoatDong> GetAllLoaiHD();
    }
}
