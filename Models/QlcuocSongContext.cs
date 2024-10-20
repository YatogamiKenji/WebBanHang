using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebBanHang.Models;

public partial class QlcuocSongContext : DbContext
{
    public QlcuocSongContext()
    {
    }

    public QlcuocSongContext(DbContextOptions<QlcuocSongContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AnhCthd> AnhCthds { get; set; }

    public virtual DbSet<AnhHd> AnhHds { get; set; }

    public virtual DbSet<ChiTietHoatDong> ChiTietHoatDongs { get; set; }

    public virtual DbSet<DanhMucHoatDong> DanhMucHoatDongs { get; set; }

    public virtual DbSet<DanhSachCuocSong> DanhSachCuocSongs { get; set; }

    public virtual DbSet<HoatDongTrongCuocSong> HoatDongTrongCuocSongs { get; set; }

    public virtual DbSet<LoaiHoatDong> LoaiHoatDongs { get; set; }

    public virtual DbSet<Login> Logins { get; set; }

    public virtual DbSet<NguoiChoi> NguoiChois { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=HOANGLAM-LAPTOP;Initial Catalog=QLCuocSong;Integrated Security=True;Encrypt=False;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AnhCthd>(entity =>
        {
            entity.HasKey(e => new { e.MaChiTietHd, e.TenFileAnh });

            entity.ToTable("AnhCTHD");

            entity.Property(e => e.MaChiTietHd)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("MaChiTietHD");
            entity.Property(e => e.TenFileAnh).HasMaxLength(50);

            entity.HasOne(d => d.MaChiTietHdNavigation).WithMany(p => p.AnhCthds)
                .HasForeignKey(d => d.MaChiTietHd)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AnhCTHD_ChiTietHoatDong");
        });

        modelBuilder.Entity<AnhHd>(entity =>
        {
            entity.HasKey(e => new { e.MaHd, e.TenFileAnh });

            entity.ToTable("AnhHD");

            entity.Property(e => e.MaHd)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("MaHD");
            entity.Property(e => e.TenFileAnh).HasMaxLength(50);

            entity.HasOne(d => d.MaHdNavigation).WithMany(p => p.AnhHds)
                .HasForeignKey(d => d.MaHd)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AnhHD_DanhMucHoatDong");
        });

        modelBuilder.Entity<ChiTietHoatDong>(entity =>
        {
            entity.HasKey(e => e.MaChiTietHd);

            entity.ToTable("ChiTietHoatDong");

            entity.Property(e => e.MaChiTietHd)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("MaChiTietHD");
            entity.Property(e => e.MaHd)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("MaHD");
            entity.Property(e => e.MoTaHoatDong)
                .HasMaxLength(10)
                .IsFixedLength();

            entity.HasOne(d => d.MaHdNavigation).WithMany(p => p.ChiTietHoatDongs)
                .HasForeignKey(d => d.MaHd)
                .HasConstraintName("FK_ChiTietHoatDong_DanhMucHoatDong");
        });

        modelBuilder.Entity<DanhMucHoatDong>(entity =>
        {
            entity.HasKey(e => e.MaHd);

            entity.ToTable("DanhMucHoatDong");

            entity.Property(e => e.MaHd)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("MaHD");
            entity.Property(e => e.CapDoHd).HasColumnName("CapDoHD");
            entity.Property(e => e.GioiThieuHd).HasColumnName("GioiThieuHD");
            entity.Property(e => e.MaLoaiHd)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("MaLoaiHD");
            entity.Property(e => e.TenHd)
                .HasMaxLength(100)
                .HasColumnName("TenHD");

            entity.HasOne(d => d.MaLoaiHdNavigation).WithMany(p => p.DanhMucHoatDongs)
                .HasForeignKey(d => d.MaLoaiHd)
                .HasConstraintName("FK_DanhMucHoatDong_LoaiHoatDong");
        });

        modelBuilder.Entity<DanhSachCuocSong>(entity =>
        {
            entity.HasKey(e => new { e.MaCuocSong, e.MaNguoiChoi });

            entity.ToTable("DanhSachCuocSong");

            entity.Property(e => e.MaCuocSong)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.MaNguoiChoi)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.LyDoChet).HasMaxLength(100);
            entity.Property(e => e.NgayBatDau).HasColumnType("datetime");
            entity.Property(e => e.NgayKetThuc).HasColumnType("datetime");

            entity.HasOne(d => d.MaCuocSongNavigation).WithMany(p => p.DanhSachCuocSongs)
                .HasForeignKey(d => d.MaCuocSong)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DanhSachCuocSong_HoatDongTrongCuocSong");

            entity.HasOne(d => d.MaNguoiChoiNavigation).WithMany(p => p.DanhSachCuocSongs)
                .HasForeignKey(d => d.MaNguoiChoi)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DanhSachCuocSong_NguoiChoi");
        });

        modelBuilder.Entity<HoatDongTrongCuocSong>(entity =>
        {
            entity.HasKey(e => e.MaCuocSong);

            entity.ToTable("HoatDongTrongCuocSong");

            entity.Property(e => e.MaCuocSong)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.MaChiTietHd)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("MaChiTietHD");
            entity.Property(e => e.Tthd).HasColumnName("TTHD");

            entity.HasOne(d => d.MaChiTietHdNavigation).WithMany(p => p.HoatDongTrongCuocSongs)
                .HasForeignKey(d => d.MaChiTietHd)
                .HasConstraintName("FK_HoatDongTrongCuocSong_ChiTietHoatDong");
        });

        modelBuilder.Entity<LoaiHoatDong>(entity =>
        {
            entity.HasKey(e => e.MaLoaiHd);

            entity.ToTable("LoaiHoatDong");

            entity.Property(e => e.MaLoaiHd)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("MaLoaiHD");
            entity.Property(e => e.TenLoaiHd)
                .HasMaxLength(20)
                .HasColumnName("TenLoaiHD");
        });

        modelBuilder.Entity<Login>(entity =>
        {
            entity.HasKey(e => e.Username);

            entity.ToTable("Login");

            entity.Property(e => e.Username)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("username");
            entity.Property(e => e.LoaiUser)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("password");
        });

        modelBuilder.Entity<NguoiChoi>(entity =>
        {
            entity.HasKey(e => e.MaNguoiChoi);

            entity.ToTable("NguoiChoi");

            entity.Property(e => e.MaNguoiChoi)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.NgaySinh).HasColumnType("datetime");
            entity.Property(e => e.TenNguoiChoi).HasMaxLength(20);
            entity.Property(e => e.Username)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("username");

            entity.HasOne(d => d.UsernameNavigation).WithMany(p => p.NguoiChois)
                .HasForeignKey(d => d.Username)
                .HasConstraintName("FK_NguoiChoi_Login");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
