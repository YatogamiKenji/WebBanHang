using System;
using System.Collections.Generic;

namespace WebBanHang.Models;

public partial class AnhCthd
{
    public string MaChiTietHd { get; set; } = null!;

    public string TenFileAnh { get; set; } = null!;

    public string? ViTriFile { get; set; }

    public virtual ChiTietHoatDong MaChiTietHdNavigation { get; set; } = null!;
}
