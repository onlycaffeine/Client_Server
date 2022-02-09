namespace Model1.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Nhacungcap")]
    public partial class Nhacungcap
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Nhacungcap()
        {
            Hoadonnhaps = new HashSet<Hoadonnhap>();
        }

        [Key]
        [StringLength(10)]
        public string Mancc { get; set; }

        [StringLength(100)]
        public string Tencc { get; set; }

        [StringLength(10)]
        public string Sdt { get; set; }

        [StringLength(100)]
        public string Diachi { get; set; }

        [StringLength(10)]
        public string Fax { get; set; }

        [StringLength(15)]
        public string Sotaikhoan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Hoadonnhap> Hoadonnhaps { get; set; }
    }
}
