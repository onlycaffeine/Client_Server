namespace Model1.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Phieuthongke")]
    public partial class Phieuthongke
    {
        [Key]
        [StringLength(10)]
        public string Sophieu { get; set; }

        public short? SLtiem { get; set; }
    }
}
