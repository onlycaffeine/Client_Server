namespace Model1.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Chitietphhieutiem")]
    public partial class Chitietphhieutiem
    {
        [Key]
        [StringLength(10)]
        public string Machitietphieutiem { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Ngaytiem { get; set; }

        [StringLength(10)]
        public string Loaimui { get; set; }

        [StringLength(50)]
        public string Trieuchung { get; set; }

        [StringLength(10)]
        public string Mathuoc { get; set; }

        [StringLength(10)]
        public string Sophieutiem { get; set; }

        [StringLength(10)]
        public string Madiemtiem { get; set; }

        [StringLength(50)]
        public string Tendiemtiem { get; set; }

        [StringLength(30)]
        public string Tenthuoc { get; set; }

        [StringLength(10)]
        public string Loaitc { get; set; }

        [StringLength(50)]
        public string Ghichu { get; set; }

        [StringLength(50)]
        public string Tenloaitc { get; set; }

        [StringLength(10)]
        public string Malo { get; set; }

        public virtual Diemtiem Diemtiem { get; set; }

        public virtual Lo Lo { get; set; }

        public virtual Loaitrieuchung Loaitrieuchung { get; set; }

        public virtual Phieutiem Phieutiem { get; set; }
    }
}
