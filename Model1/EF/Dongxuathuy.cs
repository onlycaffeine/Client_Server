namespace Model1.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Dongxuathuy")]
    public partial class Dongxuathuy
    {
        [Key]
        [StringLength(10)]
        public string Madongxuathuy { get; set; }

        //[Key]
        //[Column(Order = 0)]
        [StringLength(10)]
        public string Malo { get; set; }

        //[Key]
        //[Column(Order = 1)]
        [StringLength(10)]
        public string Maphieuxuathuy { get; set; }

        public int Slxuat { get; set; }  //int?

        public virtual Lo Lo { get; set; }

        public virtual Phieuxuathuy Phieuxuathuy { get; set; }
    }
}
