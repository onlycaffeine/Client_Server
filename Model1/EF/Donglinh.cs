namespace Model1.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Donglinh")]
    public partial class Donglinh
    {
        [Key]
        [StringLength(10)]
        public string Madonglinh { get; set; }

        [StringLength(10)]
        public string Sophieulinh { get; set; }

        [StringLength(10)]
        public string Mathuoc { get; set; }

        public int SLyeucau { get; set; }
        //public int? SLyeucau { get; set; }

        public int SLcapphat { get; set; }
        //public int? SLcapphat { get; set; }

        public virtual Phieulinh Phieulinh { get; set; }

        public virtual Vattuyte Vattuyte { get; set; }
    }
}
