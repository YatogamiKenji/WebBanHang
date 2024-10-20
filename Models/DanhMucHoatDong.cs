using System;
using System.Collections.Generic;

namespace WebBanHang.Models;

public partial class DanhMucHoatDong
{
    public string MaHd { get; set; } = null!;

    public string? TenHd { get; set; }

    public string? AnhDaiDien { get; set; }

    public string? GioiThieuHd { get; set; }

    public byte? CapDoHd { get; set; }

    public string? MaLoaiHd { get; set; }

    public virtual ICollection<AnhHd> AnhHds { get; set; } = new List<AnhHd>();

    public virtual ICollection<ChiTietHoatDong> ChiTietHoatDongs { get; set; } = new List<ChiTietHoatDong>();

    public virtual LoaiHoatDong? MaLoaiHdNavigation { get; set; }
}
