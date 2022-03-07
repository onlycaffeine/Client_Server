namespace Model1.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tiensu")]
    public partial class Tiensu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tiensu()
        {
            Phieudky_Tiensu = new HashSet<Phieudky_Tiensu>();
        }

        [Key]
        [StringLength(10)]
        public string Matiensu { get; set; }

        [StringLength(100)]
        public string Ghiro { get; set; }

        [StringLength(500)]
        public string Ten { get; set; }
        public bool? Trieuchung { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Phieudky_Tiensu> Phieudky_Tiensu { get; set; }
    }
}
