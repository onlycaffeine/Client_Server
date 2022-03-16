namespace Model1.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Diemtiem")]
    public partial class Diemtiem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Diemtiem()
        {
            Chitietphhieutiems = new HashSet<Chitietphhieutiem>();
            Phieulinhs = new HashSet<Phieulinh>();
            Phieuxuats = new HashSet<Phieuxuat>();
            Phieuxuattralais = new HashSet<Phieuxuattralai>();
        }

        [Key]
        [StringLength(10)]
        public string Madiemtiem { get; set; }

        [StringLength(100)]
        public string Tendiemtiem { get; set; }

        [StringLength(50)]
        public string Tennguoidungdau { get; set; }

        [StringLength(10)]
        public string Mathanhpho { get; set; }

        [StringLength(10)]
        public string Maquan { get; set; }

        [StringLength(20)]
        public string Tenquan { get; set; }

        [StringLength(10)]
        public string Maphuong { get; set; }

        [StringLength(50)]
        public string Diachi { get; set; }

        public bool Trangthai { get; set; } // fix here

        public int? Sobantiem { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Chitietphhieutiem> Chitietphhieutiems { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Phieulinh> Phieulinhs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Phieuxuat> Phieuxuats { get; set; }

        public virtual Phuong Phuong { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Phieuxuattralai> Phieuxuattralais { get; set; }
    }
}
