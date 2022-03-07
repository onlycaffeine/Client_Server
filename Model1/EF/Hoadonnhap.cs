namespace Model1.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Hoadonnhap")]
    public partial class Hoadonnhap
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Hoadonnhap()
        {
            Loes = new HashSet<Lo>();
        }

        [Key]
        [StringLength(10)]
        public string Sohoadon { get; set; }

        [Column(TypeName = "date")]
        public DateTime Ngaynhap { get; set; } // DateTime?

        [StringLength(100)]
        public string Diadiem { get; set; }

        [StringLength(10)]
        public string Manhanvien { get; set; }

        [StringLength(10)]
        public string Mancc { get; set; }

        [StringLength(10)]
        public string Manguon { get; set; }

        [StringLength(50)]
        public string Ghichu { get; set; }

        [StringLength(10)]
        public string Makhonhap { get; set; }

        public int? Tongtien { get; set; }

        public virtual Nhacungcap Nhacungcap { get; set; }

        public virtual Kho Kho { get; set; }

        public virtual Nguon Nguon { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Lo> Loes { get; set; }
    }
}
