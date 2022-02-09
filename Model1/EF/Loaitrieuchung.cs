namespace Model1.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Loaitrieuchung")]
    public partial class Loaitrieuchung
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Loaitrieuchung()
        {
            Chitietphhieutiems = new HashSet<Chitietphhieutiem>();
        }

        [Key]
        [StringLength(10)]
        public string Maloaitc { get; set; }

        [StringLength(20)]
        public string Tenloaitc { get; set; }

        [StringLength(50)]
        public string Ghichu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Chitietphhieutiem> Chitietphhieutiems { get; set; }
    }
}
