using System;
using System.Collections.Generic;

namespace WebBanHang.Models;

public partial class DanhSachCuocSong
{
    public string MaCuocSong { get; set; } = null!;

    public string MaNguoiChoi { get; set; } = null!;

    public DateTime? NgayBatDau { get; set; }

    public DateTime? NgayKetThuc { get; set; }

    public int? TongSoHoatDong { get; set; }

    public string? LyDoChet { get; set; }

    public int? ThoiGianConLai { get; set; }

    public int? TienConLai { get; set; }

    public short? SucKhoeConLai { get; set; }

    public short? HanhPhucConLai { get; set; }

    public bool? TrangThai { get; set; }

    public virtual HoatDongTrongCuocSong MaCuocSongNavigation { get; set; } = null!;

    public virtual NguoiChoi MaNguoiChoiNavigation { get; set; } = null!;
}
