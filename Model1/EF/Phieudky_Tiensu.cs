namespace Model1.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Phieudky_Tiensu
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string Matiensu { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string Maphieudangky { get; set; }

        [StringLength(100)]
        public string Trieuchung { get; set; }

        [StringLength(10)]
        public string Matrangthai { get; set; }

        public virtual Phieudangky Phieudangky { get; set; }

        public virtual Tiensu Tiensu { get; set; }

        public virtual Trangthaitiensu Trangthaitiensu { get; set; }
    }
}
