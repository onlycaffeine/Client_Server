namespace Model1.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tinhtrangpx")]
    public partial class Tinhtrangpx
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tinhtrangpx()
        {
            Phieuxuats = new HashSet<Phieuxuat>();
        }

        [Key]
        [StringLength(10)]
        public string Matinhtrang { get; set; }

        [StringLength(50)]
        public string Tentinhtrang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Phieuxuat> Phieuxuats { get; set; }
    }
}
