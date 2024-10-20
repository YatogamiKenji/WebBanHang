using System;
using System.Collections.Generic;

namespace WebBanHang.Models;

public partial class ChiTietHoatDong
{
    public string MaChiTietHd { get; set; } = null!;

    public string? MaHd { get; set; }

    public string? AnhDaiDien { get; set; }

    public int? ThoiGian { get; set; }

    public int? Tien { get; set; }

    public short? SucKhoe { get; set; }

    public short? HanhPhuc { get; set; }

    public string? MoTaHoatDong { get; set; }

    public virtual ICollection<AnhCthd> AnhCthds { get; set; } = new List<AnhCthd>();

    public virtual ICollection<HoatDongTrongCuocSong> HoatDongTrongCuocSongs { get; set; } = new List<HoatDongTrongCuocSong>();

    public virtual DanhMucHoatDong? MaHdNavigation { get; set; }
}
