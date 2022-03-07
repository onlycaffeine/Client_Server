namespace Model1.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Nhanvien")]
    public partial class Nhanvien
    {
        [Key]
        [StringLength(10)]
        public string Manhanvien { get; set; }

        [StringLength(100)]
        public string Tennhanvien { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Ngaysinh { get; set; }

        [StringLength(20)]
        public string Chucvu { get; set; }

        [StringLength(30)]
        public string Taikhoan { get; set; }

        [StringLength(10)]
        public string Manhom { get; set; }

        [StringLength(15)]
        public string SDT { get; set; }

        [StringLength(55)]
        public string Email { get; set; }

        public bool Trangthai { get; set; } // fix here

        [StringLength(50)]
        public string Matkhau { get; set; }

        [StringLength(10)]
        public string Madiemtiem { get; set; }

        [StringLength(10)]
        public string Maquan { get; set; }

        [StringLength(10)]
        public string Mathanhpho { get; set; }

        public bool? Tkqg { get; set; }

        [StringLength(10)]
        public string Maphuong { get; set; }

        public virtual Nhomnhanvien Nhomnhanvien { get; set; }
    }
}
