namespace Model1.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Phieuxuat")]
    public partial class Phieuxuat
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Phieuxuat()
        {
            Dongxuats = new HashSet<Dongxuat>();
        }

        [Key]
        [StringLength(10)]
        public string Sophieuxuat { get; set; }

        [Column(TypeName = "date")]
        public DateTime Ngayxuat { get; set; } //DateTime?

        [Column(TypeName = "date")]
        public DateTime Ngaynhap { get; set; } //DateTime?

        [StringLength(100)]
        public string Khoxuat { get; set; }

        [StringLength(150)]
        public string Ghichu { get; set; }

        [StringLength(100)]
        public string Khonhan { get; set; }

        [StringLength(10)]
        public string Manhanvien { get; set; }

        [StringLength(10)]
        public string Madiemtiem { get; set; }

        [StringLength(10)]
        public string Makhoxuat { get; set; }

        public int? Tongtien { get; set; }

        [StringLength(10)]
        public string Matinhtrang { get; set; }

        public virtual Diemtiem Diemtiem { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Dongxuat> Dongxuats { get; set; }

        public virtual Kho Kho { get; set; }

        public virtual Tinhtrangpx Tinhtrangpx { get; set; }
    }
}
