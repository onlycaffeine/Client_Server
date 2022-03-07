using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model1.DTO
{
    public class HoadonnhapDTO
    {
        public string Sohoadon { get; set; }

        public DateTime Ngaynhap { get; set; } // Datetime?

        public string Diadiem { get; set; }

        public string Manhanvien { get; set; }

        public string Mancc { get; set; }

        public string Manguon { get; set; }

        public string Ghichu { get; set; }

        public string Makhonhap { get; set; }

        public string Nguon { get; set; } // thêm ở đây

        public string Ncc { get; set; } // thêm ở đây

        public string Kho { get; set; } // thêm ở đây
    }
}
