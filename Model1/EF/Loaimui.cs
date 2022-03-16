using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model1.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Loaimui")]
    public partial class Loaimui
    {

        [Key]
        [StringLength(10)]
        public string Maloaimui { get; set; }

        [StringLength(1)]
        public string Tenloaimui { get; set; }

        [StringLength(30)]
        public string Ten { get; set; }

    }
}
