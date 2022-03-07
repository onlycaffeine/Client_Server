namespace Model1.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Phieutiem")]
    public partial class Phieutiem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Phieutiem()
        {
            Chitietphhieutiems = new HashSet<Chitietphhieutiem>();
        }

        [Key]
        [StringLength(10)]
        public string Sophieu { get; set; }

        [StringLength(60)]
        public string Tennguoidan { get; set; }

        [StringLength(20)]
        public string CCCD { get; set; }

        [StringLength(20)]
        public string SDT { get; set; }

        public DateTime Ngaysinh { get; set; } //public DateTime? Ngaysinh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Chitietphhieutiem> Chitietphhieutiems { get; set; }
    }
}
