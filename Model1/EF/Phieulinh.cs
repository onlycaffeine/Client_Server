namespace Model1.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Phieulinh")]
    public partial class Phieulinh
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Phieulinh()
        {
            Donglinhs = new HashSet<Donglinh>();
        }

        [Key]
        [StringLength(10)]
        public string Sophieulinh { get; set; }

        [Column(TypeName = "date")]
        public DateTime Ngayyeucau { get; set; } //DateTime?

        [StringLength(10)]
        public string Manhanvien { get; set; }

        [StringLength(10)]
        public string Madiemtiem { get; set; }

        [StringLength(10)]
        public string Matt { get; set; }

        public virtual Diemtiem Diemtiem { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Donglinh> Donglinhs { get; set; }

        public virtual Trangthai Trangthai { get; set; }
    }
}
