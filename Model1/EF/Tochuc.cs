namespace Model1.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tochuc")]
    public partial class Tochuc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tochuc()
        {
            Phieudangkies = new HashSet<Phieudangky>();
        }

        [Key]
        [StringLength(10)]
        public string Matochuc { get; set; }

        [StringLength(50)]
        public string Tentochuc { get; set; }

        [StringLength(30)]
        public string Taikhoan { get; set; }

        [StringLength(30)]
        public string Matkhau { get; set; }

        [StringLength(50)]
        public string Tennguoidungdau { get; set; }

        [StringLength(15)]
        public string SDT { get; set; }

        [StringLength(50)]
        public string Diachi { get; set; }

        [StringLength(10)]
        public string Maloaitochuc { get; set; }

        public virtual Loaitochuc Loaitochuc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Phieudangky> Phieudangkies { get; set; }
    }
}
