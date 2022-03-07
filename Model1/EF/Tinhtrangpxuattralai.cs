namespace Model1.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tinhtrangpxuattralai")]
    public partial class Tinhtrangpxuattralai
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tinhtrangpxuattralai()
        {
            Phieuxuattralais = new HashSet<Phieuxuattralai>();
        }

        [Key]
        [StringLength(10)]
        public string Matrangthai { get; set; }

        [StringLength(50)]
        public string Tentrangthai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Phieuxuattralai> Phieuxuattralais { get; set; }
    }
}
