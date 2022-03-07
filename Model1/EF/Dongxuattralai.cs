namespace Model1.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Dongxuattralai")]
    public partial class Dongxuattralai
    {
        [Key]
        [StringLength(10)]
        public string Madongxuattralai { get; set; }

        //[Key]
        //[Column(Order = 0)]
        [StringLength(10)]
        public string Sophieuxuat { get; set; }

        //[Key]
        //[Column(Order = 1)]
        [StringLength(10)]
        public string Malo { get; set; }

        public int SLxuat { get; set; } //int?

        public int SLnhap { get; set; }  //int?

        [Column(TypeName = "date")]
        public DateTime HSD { get; set; } // DateTime?

        [StringLength(50)]
        public string Tenvattu { get; set; }

        public virtual Lo Lo { get; set; }

        public virtual Phieuxuattralai Phieuxuattralai { get; set; }
    }
}
