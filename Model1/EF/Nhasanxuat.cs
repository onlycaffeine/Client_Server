namespace Model1.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Nhasanxuat")]
    public partial class Nhasanxuat
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Nhasanxuat()
        {
            Vattuytes = new HashSet<Vattuyte>();
        }

        [Key]
        [StringLength(10)]
        public string Mansx { get; set; }

        [StringLength(30)]
        public string Tennsx { get; set; }

        [StringLength(30)]
        public string Quocgia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Vattuyte> Vattuytes { get; set; }
    }
}
