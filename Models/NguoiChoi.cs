using System;
using System.Collections.Generic;

namespace WebBanHang.Models;

public partial class NguoiChoi
{
    public string MaNguoiChoi { get; set; } = null!;

    public string? TenNguoiChoi { get; set; }

    public string? Username { get; set; }

    public DateTime? NgaySinh { get; set; }

    public string? AnhDaiDien { get; set; }

    public string? GhiChu { get; set; }

    public short? CapDoHienTai { get; set; }

    public int? ThoiGianConLai { get; set; }

    public int? Tien { get; set; }

    public short? HanhPhuc { get; set; }

    public short? SucKhoe { get; set; }

    public virtual ICollection<DanhSachCuocSong> DanhSachCuocSongs { get; set; } = new List<DanhSachCuocSong>();

    public virtual Login? UsernameNavigation { get; set; }
}
