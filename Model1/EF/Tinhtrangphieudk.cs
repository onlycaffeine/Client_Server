namespace Model1.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tinhtrangphieudk")]
    public partial class Tinhtrangphieudk
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tinhtrangphieudk()
        {
            Phieudangkies = new HashSet<Phieudangky>();
        }

        [Key]
        [StringLength(10)]
        public string Matrangthai { get; set; }

        [StringLength(50)]
        public string Tentranthai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Phieudangky> Phieudangkies { get; set; }
    }
}
