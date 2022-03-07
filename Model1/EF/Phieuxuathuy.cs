namespace Model1.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Phieuxuathuy")]
    public partial class Phieuxuathuy
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Phieuxuathuy()
        {
            Dongxuathuys = new HashSet<Dongxuathuy>();
        }

        [Key]
        [StringLength(10)]
        public string Sophieuxuat { get; set; }

        [StringLength(50)]
        public string Ghichu { get; set; }

        [StringLength(10)]
        public string Manhanvien { get; set; }

        [Column(TypeName = "date")]
        public DateTime Ngayxuat { get; set; } //DateTime?

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Dongxuathuy> Dongxuathuys { get; set; }
    }
}
