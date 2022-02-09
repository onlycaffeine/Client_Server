namespace Model1.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Nhomnv_Quyen
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string Manhomnv { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string Maquyen { get; set; }

        [StringLength(30)]
        public string Chuthich { get; set; }

        public virtual Nhomnhanvien Nhomnhanvien { get; set; }

        public virtual Quyen Quyen { get; set; }
    }
}
