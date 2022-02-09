namespace Model1.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Thanhpho")]
    public partial class Thanhpho
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Thanhpho()
        {
            Quans = new HashSet<Quan>();
        }

        [Key]
        [StringLength(10)]
        public string Mathanhpho { get; set; }

        [StringLength(50)]
        public string Tenthanhpho { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Quan> Quans { get; set; }
    }
}
