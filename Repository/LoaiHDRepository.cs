using WebBanHang.Models;

namespace WebBanHang.Repository
{
    public class LoaiHDRepository : ILoaiHDRepository
    {
        private readonly QlcuocSongContext _context;
        public LoaiHDRepository(QlcuocSongContext context)
        {
            _context = context;
        }
        public LoaiHoatDong Add(LoaiHoatDong loaiHD)
        {
            _context.LoaiHoatDongs.Add(loaiHD);
            _context.SaveChanges();
            return loaiHD;
        }

        public LoaiHoatDong Delete(string maLoaiHD)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LoaiHoatDong> GetAllLoaiHD()
        {
            return _context.LoaiHoatDongs;
        }

        public LoaiHoatDong? GetLoaiHD(string maLoaiHD)
        {
            var foundlhd = _context.LoaiHoatDongs.Find(maLoaiHD);
            return foundlhd != null ? foundlhd : null;
        }

        public LoaiHoatDong Update(LoaiHoatDong loaiHD)
        {
            _context.Update(loaiHD);
            _context.SaveChanges();
            return loaiHD;
        }
    }
}
