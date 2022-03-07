namespace Model1.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Trangthaitiensu")]
    public partial class Trangthaitiensu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Trangthaitiensu()
        {
            Phieudky_Tiensu = new HashSet<Phieudky_Tiensu>();
        }

        [Key]
        [StringLength(10)]
        public string Matrangthai { get; set; }

        [StringLength(10)]
        public string Tentrangthai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Phieudky_Tiensu> Phieudky_Tiensu { get; set; }
    }
}
