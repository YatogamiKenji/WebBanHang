using System;
using System.Collections.Generic;

namespace WebBanHang.Models;

public partial class Login
{
    public string Username { get; set; } = null!;

    public string? Password { get; set; }

    public string? LoaiUser { get; set; }

    public virtual ICollection<NguoiChoi> NguoiChois { get; set; } = new List<NguoiChoi>();
}
