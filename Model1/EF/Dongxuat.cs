namespace Model1.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Dongxuat")]
    public partial class Dongxuat
    {
        [Key]
        [StringLength(10)]
        public string Madongxuat { get; set; }

        [StringLength(10)]
        public string Sophieuxuat { get; set; }

        [StringLength(10)]
        public string Malo { get; set; }

        public int SLxuat { get; set; }

        public int SLnhap { get; set; }

        public int? Dongia { get; set; }

        [Column(TypeName = "date")]
        public DateTime HSD { get; set; } //DateTime?

        public int? Thanhtien { get; set; }

        [StringLength(15)]
        public string Tenthuoc { get; set; }

        [StringLength(10)]
        public string Mathuoc { get; set; }

        public virtual Lo Lo { get; set; }

        public virtual Phieuxuat Phieuxuat { get; set; }
    }
}
