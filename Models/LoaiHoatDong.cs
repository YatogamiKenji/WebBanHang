using System;
using System.Collections.Generic;

namespace WebBanHang.Models;

public partial class LoaiHoatDong
{
    public string MaLoaiHd { get; set; } = null!;

    public string? TenLoaiHd { get; set; }

    public virtual ICollection<DanhMucHoatDong> DanhMucHoatDongs { get; set; } = new List<DanhMucHoatDong>();
}
