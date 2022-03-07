namespace Model1.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Phuong")]
    public partial class Phuong
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Phuong()
        {
            Diemtiems = new HashSet<Diemtiem>();
            Phieudangkies = new HashSet<Phieudangky>();
        }

        [Key]
        [StringLength(10)]
        public string Maphuong { get; set; }

        [StringLength(50)]
        public string Tenphuong { get; set; }

        [StringLength(10)]
        public string Maquan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Diemtiem> Diemtiems { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Phieudangky> Phieudangkies { get; set; }

        public virtual Quan Quan { get; set; }
    }
}
