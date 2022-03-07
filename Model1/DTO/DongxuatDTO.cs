using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model1.DTO
{
    public class DongxuatDTO
    {
        public string Madongxuat { get; set; }

        public string Sophieuxuat { get; set; }

        public string Malo { get; set; }

        public int SLxuat { get; set; }

        public int SLnhap { get; set; }

        public int? Dongia { get; set; }

        public DateTime HSD { get; set; } //DateTime?

        public int? Thanhtien { get; set; }

        public string Tenthuoc { get; set; }

        public string Mathuoc { get; set; }

        public DateTime Ngayxuat { get; set; } //DateTime?
    }
}
