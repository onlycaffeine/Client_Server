namespace Model1.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Loaitochuc")]
    public partial class Loaitochuc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Loaitochuc()
        {
            Tochucs = new HashSet<Tochuc>();
        }

        [Key]
        [StringLength(10)]
        public string Maloaitochuc { get; set; }

        [StringLength(50)]
        public string Tenloaitochuc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tochuc> Tochucs { get; set; }
    }
}
