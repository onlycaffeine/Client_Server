namespace Model1.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Chithinhietdo")]
    public partial class Chithinhietdo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Chithinhietdo()
        {
            Loes = new HashSet<Lo>();
        }

        [Key]
        [StringLength(10)]
        public string Machithinhietdo { get; set; }

        [StringLength(10)]
        public string Tenchithinhietdo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Lo> Loes { get; set; }
    }
}
