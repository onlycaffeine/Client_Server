namespace Model1.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CSDL_NangcaoDbContext : DbContext
    {
        public CSDL_NangcaoDbContext()
            : base("name=CSDL_NangcaoDbContext")
        {
        }

        public virtual DbSet<Chithidongbang> Chithidongbangs { get; set; }
        public virtual DbSet<Chithinhietdo> Chithinhietdoes { get; set; }
        public virtual DbSet<Chitietphhieutiem> Chitietphhieutiems { get; set; }
        public virtual DbSet<Diemtiem> Diemtiems { get; set; }
        public virtual DbSet<Donglinh> Donglinhs { get; set; }
        public virtual DbSet<Dongxuat> Dongxuats { get; set; }
        public virtual DbSet<Hoadonnhap> Hoadonnhaps { get; set; }
        public virtual DbSet<Kho> Khoes { get; set; }
        public virtual DbSet<Lo> Loes { get; set; }
        public virtual DbSet<Loaitrieuchung> Loaitrieuchungs { get; set; }
        public virtual DbSet<Loaivattuyte> Loaivattuytes { get; set; }
        public virtual DbSet<Nguon> Nguons { get; set; }
        public virtual DbSet<Nhacungcap> Nhacungcaps { get; set; }
        public virtual DbSet<Nhanvien> Nhanviens { get; set; }
        public virtual DbSet<Nhasanxuat> Nhasanxuats { get; set; }
        public virtual DbSet<Nhomnhanvien> Nhomnhanviens { get; set; }
        public virtual DbSet<Nhomnv_Quyen> Nhomnv_Quyen { get; set; }
        public virtual DbSet<Phieulinh> Phieulinhs { get; set; }
        public virtual DbSet<Phieuthongke> Phieuthongkes { get; set; }
        public virtual DbSet<Phieutiem> Phieutiems { get; set; }
        public virtual DbSet<Phieuxuat> Phieuxuats { get; set; }
        public virtual DbSet<Phuong> Phuongs { get; set; }
        public virtual DbSet<Quan> Quans { get; set; }
        public virtual DbSet<Quyen> Quyens { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Thanhpho> Thanhphoes { get; set; }
        public virtual DbSet<Tinhtrangpx> Tinhtrangpxes { get; set; }
        public virtual DbSet<Trangthai> Trangthais { get; set; }
        public virtual DbSet<Vattuyte> Vattuytes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chithidongbang>()
                .Property(e => e.Machithidongbang)
                .IsUnicode(false);

            modelBuilder.Entity<Chithinhietdo>()
                .Property(e => e.Machithinhietdo)
                .IsUnicode(false);

            modelBuilder.Entity<Chitietphhieutiem>()
                .Property(e => e.Machitietphieutiem)
                .IsUnicode(false);

            modelBuilder.Entity<Chitietphhieutiem>()
                .Property(e => e.Loaimui)
                .IsUnicode(false);

            modelBuilder.Entity<Chitietphhieutiem>()
                .Property(e => e.Mathuoc)
                .IsUnicode(false);

            modelBuilder.Entity<Chitietphhieutiem>()
                .Property(e => e.Sophieutiem)
                .IsUnicode(false);

            modelBuilder.Entity<Chitietphhieutiem>()
                .Property(e => e.Madiemtiem)
                .IsUnicode(false);

            modelBuilder.Entity<Chitietphhieutiem>()
                .Property(e => e.Loaitc)
                .IsUnicode(false);

            modelBuilder.Entity<Chitietphhieutiem>()
                .Property(e => e.Malo)
                .IsUnicode(false);

            modelBuilder.Entity<Diemtiem>()
                .Property(e => e.Madiemtiem)
                .IsUnicode(false);

            modelBuilder.Entity<Diemtiem>()
                .Property(e => e.Maquan)
                .IsUnicode(false);

            modelBuilder.Entity<Diemtiem>()
                .Property(e => e.Maphuong)
                .IsUnicode(false);

            modelBuilder.Entity<Donglinh>()
                .Property(e => e.Madonglinh)
                .IsUnicode(false);

            modelBuilder.Entity<Donglinh>()
                .Property(e => e.Sophieulinh)
                .IsUnicode(false);

            modelBuilder.Entity<Donglinh>()
                .Property(e => e.Mathuoc)
                .IsUnicode(false);

            modelBuilder.Entity<Dongxuat>()
                .Property(e => e.Madongxuat)
                .IsUnicode(false);

            modelBuilder.Entity<Dongxuat>()
                .Property(e => e.Sophieuxuat)
                .IsUnicode(false);

            modelBuilder.Entity<Dongxuat>()
                .Property(e => e.Malo)
                .IsUnicode(false);

            modelBuilder.Entity<Dongxuat>()
                .Property(e => e.Mathuoc)
                .IsUnicode(false);

            modelBuilder.Entity<Hoadonnhap>()
                .Property(e => e.Sohoadon)
                .IsUnicode(false);

            modelBuilder.Entity<Hoadonnhap>()
                .Property(e => e.Manhanvien)
                .IsUnicode(false);

            modelBuilder.Entity<Hoadonnhap>()
                .Property(e => e.Mancc)
                .IsUnicode(false);

            modelBuilder.Entity<Hoadonnhap>()
                .Property(e => e.Manguon)
                .IsUnicode(false);

            modelBuilder.Entity<Hoadonnhap>()
                .Property(e => e.Makhonhap)
                .IsUnicode(false);

            modelBuilder.Entity<Kho>()
                .Property(e => e.Makho)
                .IsUnicode(false);

            modelBuilder.Entity<Kho>()
                .HasMany(e => e.Hoadonnhaps)
                .WithOptional(e => e.Kho)
                .HasForeignKey(e => e.Makhonhap);

            modelBuilder.Entity<Kho>()
                .HasMany(e => e.Phieuxuats)
                .WithOptional(e => e.Kho)
                .HasForeignKey(e => e.Makhoxuat);

            modelBuilder.Entity<Lo>()
                .Property(e => e.Malo)
                .IsUnicode(false);

            modelBuilder.Entity<Lo>()
                .Property(e => e.Sohoadon)
                .IsUnicode(false);

            modelBuilder.Entity<Lo>()
                .Property(e => e.SDK_gnpk)
                .IsUnicode(false);

            modelBuilder.Entity<Lo>()
                .Property(e => e.Nongdo)
                .IsUnicode(false);

            modelBuilder.Entity<Lo>()
                .Property(e => e.Hopchat)
                .IsUnicode(false);

            modelBuilder.Entity<Lo>()
                .Property(e => e.Machithidongbang)
                .IsUnicode(false);

            modelBuilder.Entity<Lo>()
                .Property(e => e.Machithinhietdo)
                .IsUnicode(false);

            modelBuilder.Entity<Lo>()
                .Property(e => e.Mavattu)
                .IsUnicode(false);

            modelBuilder.Entity<Loaitrieuchung>()
                .Property(e => e.Maloaitc)
                .IsUnicode(false);

            modelBuilder.Entity<Loaitrieuchung>()
                .HasMany(e => e.Chitietphhieutiems)
                .WithOptional(e => e.Loaitrieuchung)
                .HasForeignKey(e => e.Loaitc);

            modelBuilder.Entity<Loaivattuyte>()
                .Property(e => e.Maloaivattu)
                .IsUnicode(false);

            modelBuilder.Entity<Nguon>()
                .Property(e => e.Manguon)
                .IsUnicode(false);

            modelBuilder.Entity<Nhacungcap>()
                .Property(e => e.Mancc)
                .IsUnicode(false);

            modelBuilder.Entity<Nhacungcap>()
                .Property(e => e.Sdt)
                .IsUnicode(false);

            modelBuilder.Entity<Nhacungcap>()
                .Property(e => e.Fax)
                .IsUnicode(false);

            modelBuilder.Entity<Nhacungcap>()
                .Property(e => e.Sotaikhoan)
                .IsUnicode(false);

            modelBuilder.Entity<Nhanvien>()
                .Property(e => e.Manhanvien)
                .IsUnicode(false);

            modelBuilder.Entity<Nhanvien>()
                .Property(e => e.Taikhoan)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Nhanvien>()
                .Property(e => e.Manhom)
                .IsUnicode(false);

            modelBuilder.Entity<Nhanvien>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<Nhanvien>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Nhanvien>()
                .Property(e => e.Matkhau)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Nhanvien>()
                .Property(e => e.Madiemtiem)
                .IsUnicode(false);

            modelBuilder.Entity<Nhanvien>()
                .Property(e => e.Maquan)
                .IsUnicode(false);

            modelBuilder.Entity<Nhanvien>()
                .Property(e => e.Mathanhpho)
                .IsUnicode(false);

            modelBuilder.Entity<Nhanvien>()
                .Property(e => e.Maphuong)
                .IsUnicode(false);

            modelBuilder.Entity<Nhasanxuat>()
                .Property(e => e.Mansx)
                .IsUnicode(false);

            modelBuilder.Entity<Nhomnhanvien>()
                .Property(e => e.Manhomnv)
                .IsUnicode(false);

            modelBuilder.Entity<Nhomnhanvien>()
                .HasMany(e => e.Nhanviens)
                .WithOptional(e => e.Nhomnhanvien)
                .HasForeignKey(e => e.Manhom);

            modelBuilder.Entity<Nhomnhanvien>()
                .HasMany(e => e.Nhomnv_Quyen)
                .WithRequired(e => e.Nhomnhanvien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Nhomnv_Quyen>()
                .Property(e => e.Manhomnv)
                .IsUnicode(false);

            modelBuilder.Entity<Nhomnv_Quyen>()
                .Property(e => e.Maquyen)
                .IsUnicode(false);

            modelBuilder.Entity<Phieulinh>()
                .Property(e => e.Sophieulinh)
                .IsUnicode(false);

            modelBuilder.Entity<Phieulinh>()
                .Property(e => e.Manhanvien)
                .IsUnicode(false);

            modelBuilder.Entity<Phieulinh>()
                .Property(e => e.Madiemtiem)
                .IsUnicode(false);

            modelBuilder.Entity<Phieulinh>()
                .Property(e => e.Matt)
                .IsUnicode(false);

            modelBuilder.Entity<Phieuthongke>()
                .Property(e => e.Sophieu)
                .IsUnicode(false);

            modelBuilder.Entity<Phieutiem>()
                .Property(e => e.Sophieu)
                .IsUnicode(false);

            modelBuilder.Entity<Phieutiem>()
                .Property(e => e.CCCD)
                .IsUnicode(false);

            modelBuilder.Entity<Phieutiem>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<Phieutiem>()
                .HasMany(e => e.Chitietphhieutiems)
                .WithOptional(e => e.Phieutiem)
                .HasForeignKey(e => e.Sophieutiem);

            modelBuilder.Entity<Phieuxuat>()
                .Property(e => e.Sophieuxuat)
                .IsUnicode(false);

            modelBuilder.Entity<Phieuxuat>()
                .Property(e => e.Manhanvien)
                .IsUnicode(false);

            modelBuilder.Entity<Phieuxuat>()
                .Property(e => e.Madiemtiem)
                .IsUnicode(false);

            modelBuilder.Entity<Phieuxuat>()
                .Property(e => e.Makhoxuat)
                .IsUnicode(false);

            modelBuilder.Entity<Phieuxuat>()
                .Property(e => e.Matinhtrang)
                .IsUnicode(false);

            modelBuilder.Entity<Phuong>()
                .Property(e => e.Maphuong)
                .IsUnicode(false);

            modelBuilder.Entity<Phuong>()
                .Property(e => e.Maquan)
                .IsUnicode(false);

            modelBuilder.Entity<Quan>()
                .Property(e => e.Maquan)
                .IsUnicode(false);

            modelBuilder.Entity<Quan>()
                .Property(e => e.Mathanhpho)
                .IsUnicode(false);

            modelBuilder.Entity<Quyen>()
                .Property(e => e.Maquyen)
                .IsUnicode(false);

            modelBuilder.Entity<Quyen>()
                .HasMany(e => e.Nhomnv_Quyen)
                .WithRequired(e => e.Quyen)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Thanhpho>()
                .Property(e => e.Mathanhpho)
                .IsUnicode(false);

            modelBuilder.Entity<Tinhtrangpx>()
                .Property(e => e.Matinhtrang)
                .IsUnicode(false);

            modelBuilder.Entity<Trangthai>()
                .Property(e => e.Matrangthai)
                .IsUnicode(false);

            modelBuilder.Entity<Trangthai>()
                .HasMany(e => e.Phieulinhs)
                .WithOptional(e => e.Trangthai)
                .HasForeignKey(e => e.Matt);

            modelBuilder.Entity<Vattuyte>()
                .Property(e => e.Mavattu)
                .IsUnicode(false);

            modelBuilder.Entity<Vattuyte>()
                .Property(e => e.Mansx)
                .IsUnicode(false);

            modelBuilder.Entity<Vattuyte>()
                .Property(e => e.Maloaivattu)
                .IsUnicode(false);

            modelBuilder.Entity<Vattuyte>()
                .HasMany(e => e.Donglinhs)
                .WithOptional(e => e.Vattuyte)
                .HasForeignKey(e => e.Mathuoc);
        }
    }
}
