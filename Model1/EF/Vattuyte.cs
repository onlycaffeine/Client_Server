namespace Model1.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Vattuyte")]
    public partial class Vattuyte
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Vattuyte()
        {
            Donglinhs = new HashSet<Donglinh>();
            Loes = new HashSet<Lo>();
            //Phieudangkies = new HashSet<Phieudangky>();
        }

        [Key]
        [StringLength(10)]
        public string Mavattu { get; set; }

        [StringLength(100)]
        public string Tenvattu { get; set; }

        [StringLength(10)]
        public string Mansx { get; set; }

        public bool Trangthai { get; set; } // fix here

        [StringLength(10)]
        public string Maloaivattu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Donglinh> Donglinhs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Lo> Loes { get; set; }

        public virtual Loaivattuyte Loaivattuyte { get; set; }

        public virtual Nhasanxuat Nhasanxuat { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Phieudangky> Phieudangkies { get; set; }
    }
}
