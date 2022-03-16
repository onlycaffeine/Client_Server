namespace Model1.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Phieudangky")]
    public partial class Phieudangky
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Phieudangky()
        {
            Phieudky_Tiensu = new HashSet<Phieudky_Tiensu>();
        }

        [Key]
        [StringLength(10)]
        public string Sophieudangky { get; set; }

        [StringLength(50)]
        public string Tennguoidan { get; set; }

        [StringLength(15)]
        public string CCCD { get; set; }

        [StringLength(15)]
        public string SDT { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Ngaysinh { get; set; }

        [StringLength(30)]
        public string Loaimui { get; set; }

        [StringLength(10)]
        public string Matochuc { get; set; }

        [StringLength(50)]
        public string Diachi { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Ngaymongmuon { get; set; }

        [StringLength(10)]
        public string Matrangthai { get; set; }

        [StringLength(10)]
        public string Manhomuutien { get; set; }

        [StringLength(10)]
        public string Maphuong { get; set; }

        [StringLength(30)]
        public string Buoimongmuon { get; set; }


        [StringLength(3)]
        public string Gioitinh { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(30)]
        public string Bhyt { get; set; }

        [StringLength(10)]
        public string Dantoc { get; set; }

        [StringLength(10)]
        public string Quoctich { get; set; }

        [StringLength(50)]
        public string Hotengiamho { get; set; }

        [StringLength(10)]
        public string Quanhegiamho { get; set; }

        [StringLength(15)]
        public string SDTgiamho { get; set; }

        [StringLength(10)]
        public string Mathuoc1 { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Ngaytiem1 { get; set; }

        [StringLength(10)]
        public string Malo1 { get; set; }

        [StringLength(50)]
        public string Diadiemtiem1 { get; set; }

        [StringLength(500)]
        public string Phanungtiem1 { get; set; }

        [StringLength(50)]
        public string Hotendangky { get; set; }

        [StringLength(50)]
        public string Nghenghiep { get; set; }

        [StringLength(15)]
        public string SDTdangky { get; set; }

        [StringLength(50)]
        public string Donvicongtac { get; set; }

        [StringLength(30)]
        public string Tentt { get; set; }

        [StringLength(15)]
        public string Tenthuoc1 { get; set; }

        [StringLength(500)]
        public string Tennhomuutien { get; set; }

        [StringLength(50)]
        public string Tenphuong { get; set; }

        public virtual Nhomuutien Nhomuutien { get; set; }

        public virtual Phuong Phuong { get; set; }

        //public virtual Vattuyte Vattuyte { get; set; }

        public virtual Tinhtrangphieudk Tinhtrangphieudk { get; set; }

        public virtual Tochuc Tochuc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Phieudky_Tiensu> Phieudky_Tiensu { get; set; }
    }
}
