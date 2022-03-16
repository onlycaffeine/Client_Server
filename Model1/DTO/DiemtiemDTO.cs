using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model1.DTO
{
    public class DiemtiemDTO
    {
        public string Madiemtiem { get; set; }

        public string Tendiemtiem { get; set; }
        public string Tennguoidungdau { get; set; }

        public string Mathanhpho { get; set; }

        public bool Trangthai { get; set; } // fix here
        public string Maquan { get; set; }

        public string Tenquan { get; set; }
        public string Tenthanhpho { get; set; }

        public string Maphuong { get; set; }

        public string Tenphuong { get; set; }

        public string Diachi { get; set; }
        public int? Sobantiem { get; set; }
    }
}
