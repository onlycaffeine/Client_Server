namespace Model1.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Nhomuutien")]
    public partial class Nhomuutien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Nhomuutien()
        {
            Phieudangkies = new HashSet<Phieudangky>();
        }

        [Key]
        [StringLength(10)]
        public string Manhomuutien { get; set; }

        [StringLength(50)]
        public string Tennhomuutien { get; set; }

        public int? Trongso { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Phieudangky> Phieudangkies { get; set; }
    }
}
