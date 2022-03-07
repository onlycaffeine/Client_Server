namespace Model1.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Phieuxuattralai")]
    public partial class Phieuxuattralai
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Phieuxuattralai()
        {
            Dongxuattralais = new HashSet<Dongxuattralai>();
        }

        [Key]
        [StringLength(10)]
        public string Sophieuxuat { get; set; }

        [StringLength(10)]
        public string Madiemtiem { get; set; }

        [StringLength(50)]
        public string Ghichu { get; set; }

        [Column(TypeName = "date")]
        public DateTime Ngayxuat { get; set; } //DateTime?

        [Column(TypeName = "date")]
        public DateTime Ngaynhap { get; set; } //DateTime?

        [StringLength(10)]
        public string Manhanvien { get; set; }

        [StringLength(10)]
        public string Manhanvien2 { get; set; }

        [StringLength(10)]
        public string Matinhtrang { get; set; }

        public virtual Diemtiem Diemtiem { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Dongxuattralai> Dongxuattralais { get; set; }

        public virtual Tinhtrangpxuattralai Tinhtrangpxuattralai { get; set; }
    }
}
