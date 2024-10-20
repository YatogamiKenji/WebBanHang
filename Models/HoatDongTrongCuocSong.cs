using System;
using System.Collections.Generic;

namespace WebBanHang.Models;

public partial class HoatDongTrongCuocSong
{
    public string MaCuocSong { get; set; } = null!;

    public int? Tthd { get; set; }

    public string? MaChiTietHd { get; set; }

    public int? ThoiGian { get; set; }

    public int? Tien { get; set; }

    public short? SucKhoe { get; set; }

    public short? HanhPhuc { get; set; }

    public virtual ICollection<DanhSachCuocSong> DanhSachCuocSongs { get; set; } = new List<DanhSachCuocSong>();

    public virtual ChiTietHoatDong? MaChiTietHdNavigation { get; set; }
}
