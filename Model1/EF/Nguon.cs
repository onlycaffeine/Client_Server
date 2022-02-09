namespace Model1.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Nguon")]
    public partial class Nguon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Nguon()
        {
            Hoadonnhaps = new HashSet<Hoadonnhap>();
        }

        [Key]
        [StringLength(10)]
        public string Manguon { get; set; }

        [StringLength(30)]
        public string Tennguon { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Hoadonnhap> Hoadonnhaps { get; set; }
    }
}
