namespace Model1.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Loaivattuyte")]
    public partial class Loaivattuyte
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Loaivattuyte()
        {
            Vattuytes = new HashSet<Vattuyte>();
        }

        [Key]
        [StringLength(10)]
        public string Maloaivattu { get; set; }

        [StringLength(50)]
        public string Tenloaivattu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Vattuyte> Vattuytes { get; set; }
    }
}
