namespace Model1.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Kho")]
    public partial class Kho
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Kho()
        {
            Hoadonnhaps = new HashSet<Hoadonnhap>();
            Phieuxuats = new HashSet<Phieuxuat>();
        }

        [Key]
        [StringLength(10)]
        public string Makho { get; set; }

        [StringLength(30)]
        public string Tenkho { get; set; }

        [StringLength(30)]
        public string Diadiem { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Hoadonnhap> Hoadonnhaps { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Phieuxuat> Phieuxuats { get; set; }
    }
}
