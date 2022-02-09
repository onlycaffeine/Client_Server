namespace Model1.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Quan")]
    public partial class Quan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Quan()
        {
            Phuongs = new HashSet<Phuong>();
        }

        [Key]
        [StringLength(10)]
        public string Maquan { get; set; }

        [StringLength(100)]
        public string Tenquan { get; set; }

        [StringLength(10)]
        public string Mathanhpho { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Phuong> Phuongs { get; set; }

        public virtual Thanhpho Thanhpho { get; set; }
    }
}
