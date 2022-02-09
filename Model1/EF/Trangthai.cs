namespace Model1.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Trangthai")]
    public partial class Trangthai
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Trangthai()
        {
            Phieulinhs = new HashSet<Phieulinh>();
        }

        [Key]
        [StringLength(10)]
        public string Matrangthai { get; set; }

        [StringLength(19)]
        public string Tentrangthai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Phieulinh> Phieulinhs { get; set; }
    }
}
