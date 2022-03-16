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
        public virtual DbSet<Dongxuathuy> Dongxuathuys { get; set; }
        public virtual DbSet<Dongxuattralai> Dongxuattralais { get; set; }
        public virtual DbSet<Hoadonnhap> Hoadonnhaps { get; set; }
        public virtual DbSet<Kho> Khoes { get; set; }
        public virtual DbSet<Lo> Loes { get; set; }
        public virtual DbSet<Loaitochuc> Loaitochucs { get; set; }
        public virtual DbSet<Loaitrieuchung> Loaitrieuchungs { get; set; }
        public virtual DbSet<Loaivattuyte> Loaivattuytes { get; set; }
        public virtual DbSet<Nguon> Nguons { get; set; }
        public virtual DbSet<Nhacungcap> Nhacungcaps { get; set; }
        public virtual DbSet<Nhanvien> Nhanviens { get; set; }
        public virtual DbSet<Nhasanxuat> Nhasanxuats { get; set; }
        public virtual DbSet<Nhomnhanvien> Nhomnhanviens { get; set; }
        public virtual DbSet<Nhomnv_Quyen> Nhomnv_Quyen { get; set; }
        public virtual DbSet<Nhomuutien> Nhomuutiens { get; set; }
        public virtual DbSet<Phieudangky> Phieudangkies { get; set; }
        public virtual DbSet<Phieudky_Tiensu> Phieudky_Tiensu { get; set; }
        public virtual DbSet<Phieulinh> Phieulinhs { get; set; }
        public virtual DbSet<Phieuthongke> Phieuthongkes { get; set; }
        public virtual DbSet<Phieutiem> Phieutiems { get; set; }
        public virtual DbSet<Phieuxuat> Phieuxuats { get; set; }
        public virtual DbSet<Phieuxuathuy> Phieuxuathuys { get; set; }
        public virtual DbSet<Phieuxuattralai> Phieuxuattralais { get; set; }
        public virtual DbSet<Phuong> Phuongs { get; set; }
        public virtual DbSet<Quan> Quans { get; set; }
        public virtual DbSet<Quyen> Quyens { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Thanhpho> Thanhphoes { get; set; }
        public virtual DbSet<Tiensu> Tiensus { get; set; }
        public virtual DbSet<Tinhtrangphieudk> Tinhtrangphieudks { get; set; }
        public virtual DbSet<Tinhtrangpx> Tinhtrangpxes { get; set; }
        public virtual DbSet<Tinhtrangpxuattralai> Tinhtrangpxuattralais { get; set; }
        public virtual DbSet<Tochuc> Tochucs { get; set; }
        public virtual DbSet<Trangthai> Trangthais { get; set; }
        public virtual DbSet<Trangthaitiensu> Trangthaitiensus { get; set; }
        public virtual DbSet<Vattuyte> Vattuytes { get; set; }
        public virtual DbSet<Loaimui> Loaimuis { get; set; }

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

            modelBuilder.Entity<Dongxuathuy>()
                .Property(e => e.Malo)
                .IsUnicode(false);

            modelBuilder.Entity<Dongxuathuy>()
                .Property(e => e.Maphieuxuathuy)
                .IsUnicode(false);

            modelBuilder.Entity<Dongxuattralai>()
                .Property(e => e.Sophieuxuat)
                .IsUnicode(false);

            modelBuilder.Entity<Dongxuattralai>()
                .Property(e => e.Malo)
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

            modelBuilder.Entity<Lo>()
                .HasMany(e => e.Dongxuathuys)
                .WithRequired(e => e.Lo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Lo>()
                .HasMany(e => e.Dongxuattralais)
                .WithRequired(e => e.Lo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Loaimui>()
                .Property(e => e.Maloaimui)
                .IsUnicode(false);

            modelBuilder.Entity<Loaitochuc>()
                .Property(e => e.Maloaitochuc)
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

            modelBuilder.Entity<Nhomuutien>()
                .Property(e => e.Manhomuutien)
                .IsUnicode(false);

            modelBuilder.Entity<Phieudangky>()
                .Property(e => e.Sophieudangky)
                .IsUnicode(false);

            modelBuilder.Entity<Phieudangky>()
                .Property(e => e.CCCD)
                .IsUnicode(false);

            modelBuilder.Entity<Phieudangky>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<Phieudangky>()
                .Property(e => e.Loaimui)
                .IsUnicode(false);

            modelBuilder.Entity<Phieudangky>()
                .Property(e => e.Matochuc)
                .IsUnicode(false);

            modelBuilder.Entity<Phieudangky>()
                .Property(e => e.Matrangthai)
                .IsUnicode(false);

            modelBuilder.Entity<Phieudangky>()
                .Property(e => e.Manhomuutien)
                .IsUnicode(false);

            modelBuilder.Entity<Phieudangky>()
                .Property(e => e.Mathuoc1)
                .IsUnicode(false);

            modelBuilder.Entity<Phieudangky>()
                .Property(e => e.Maphuong)
                .IsUnicode(false);

            modelBuilder.Entity<Phieudangky>()
                .HasMany(e => e.Phieudky_Tiensu)
                .WithRequired(e => e.Phieudangky)
                .HasForeignKey(e => e.Maphieudangky)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Phieudky_Tiensu>()
                .Property(e => e.Matiensu)
                .IsUnicode(false);

            modelBuilder.Entity<Phieudky_Tiensu>()
                .Property(e => e.Maphieudangky)
                .IsUnicode(false);

            modelBuilder.Entity<Phieudky_Tiensu>()
                .Property(e => e.Matrangthai)
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

            modelBuilder.Entity<Phieuxuathuy>()
                .Property(e => e.Sophieuxuat)
                .IsUnicode(false);

            modelBuilder.Entity<Phieuxuathuy>()
                .Property(e => e.Manhanvien)
                .IsUnicode(false);

            modelBuilder.Entity<Phieuxuathuy>()
                .HasMany(e => e.Dongxuathuys)
                .WithRequired(e => e.Phieuxuathuy)
                .HasForeignKey(e => e.Maphieuxuathuy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Phieuxuattralai>()
                .Property(e => e.Sophieuxuat)
                .IsUnicode(false);

            modelBuilder.Entity<Phieuxuattralai>()
                .Property(e => e.Madiemtiem)
                .IsUnicode(false);

            modelBuilder.Entity<Phieuxuattralai>()
                .Property(e => e.Manhanvien)
                .IsUnicode(false);

            modelBuilder.Entity<Phieuxuattralai>()
                .Property(e => e.Matinhtrang)
                .IsUnicode(false);

            modelBuilder.Entity<Phieuxuattralai>()
                .HasMany(e => e.Dongxuattralais)
                .WithRequired(e => e.Phieuxuattralai)
                .WillCascadeOnDelete(false);

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

            modelBuilder.Entity<Tiensu>()
                .Property(e => e.Matiensu)
                .IsUnicode(false);

            modelBuilder.Entity<Tiensu>()
                .HasMany(e => e.Phieudky_Tiensu)
                .WithRequired(e => e.Tiensu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tinhtrangphieudk>()
                .Property(e => e.Matrangthai)
                .IsUnicode(false);

            modelBuilder.Entity<Tinhtrangpx>()
                .Property(e => e.Matinhtrang)
                .IsUnicode(false);

            modelBuilder.Entity<Tinhtrangpxuattralai>()
                .Property(e => e.Matrangthai)
                .IsUnicode(false);

            modelBuilder.Entity<Tinhtrangpxuattralai>()
                .HasMany(e => e.Phieuxuattralais)
                .WithOptional(e => e.Tinhtrangpxuattralai)
                .HasForeignKey(e => e.Matinhtrang);

            modelBuilder.Entity<Tochuc>()
                .Property(e => e.Matochuc)
                .IsUnicode(false);

            modelBuilder.Entity<Tochuc>()
                .Property(e => e.Taikhoan)
                .IsUnicode(false);

            modelBuilder.Entity<Tochuc>()
                .Property(e => e.Matkhau)
                .IsUnicode(false);

            modelBuilder.Entity<Tochuc>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<Tochuc>()
                .Property(e => e.Maloaitochuc)
                .IsUnicode(false);

            modelBuilder.Entity<Trangthai>()
                .Property(e => e.Matrangthai)
                .IsUnicode(false);

            modelBuilder.Entity<Trangthai>()
                .HasMany(e => e.Phieulinhs)
                .WithOptional(e => e.Trangthai)
                .HasForeignKey(e => e.Matt);

            modelBuilder.Entity<Trangthaitiensu>()
                .Property(e => e.Matrangthai)
                .IsUnicode(false);

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
