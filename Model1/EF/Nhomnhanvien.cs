namespace Model1.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Nhomnhanvien")]
    public partial class Nhomnhanvien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Nhomnhanvien()
        {
            Nhanviens = new HashSet<Nhanvien>();
            Nhomnv_Quyen = new HashSet<Nhomnv_Quyen>();
        }

        [Key]
        [StringLength(10)]
        public string Manhomnv { get; set; }

        [StringLength(30)]
        public string Tennhomnv { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Nhanvien> Nhanviens { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Nhomnv_Quyen> Nhomnv_Quyen { get; set; }
    }
}
