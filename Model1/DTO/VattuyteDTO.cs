using Model1.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model1.DTO
{
    public class VattuyteDTO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VattuyteDTO()
        {
            Chitietphhieutiems = new HashSet<Chitietphhieutiem>();
            Donglinhs = new HashSet<Donglinh>();
            Dongxuats = new HashSet<Dongxuat>();
        }

        public string Mavattu { get; set; }

        public string Tenvattu { get; set; }

        public bool Trangthai { get; set; } // fix here
        public string Malo { get; set; }

        public string Mansx { get; set; }

        public string Maloaivattu { get; set; }

        public string Tenloaivattu { get; set; }

        public string Tennsx { get; set; }

        public string Xuatxu { get; set; }

        public int Tongsoluong { get; set; }

        public int Slyeucau { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Chitietphhieutiem> Chitietphhieutiems { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Donglinh> Donglinhs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Dongxuat> Dongxuats { get; set; }

        public virtual Lo Lo { get; set; }

        public virtual Loaivattuyte Loaivattuyte { get; set; }

        public virtual Nhasanxuat Nhasanxuat { get; set; }

        //public string CategoryName { get; set; } // thêm ở đây
    }
}
