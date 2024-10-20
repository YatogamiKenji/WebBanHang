using System;
using System.Collections.Generic;

namespace WebBanHang.Models;

public partial class AnhHd
{
    public string MaHd { get; set; } = null!;

    public string TenFileAnh { get; set; } = null!;

    public string ViTriFile { get; set; } = null!;

    public virtual DanhMucHoatDong MaHdNavigation { get; set; } = null!;
}
