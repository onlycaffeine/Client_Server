using Model1.DTO;
using Model1.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model1
{
    public class ModelCollection
    {
        public IEnumerable<HoadonnhapDTO> HoadonnhapDTOs { get; set; }
        public IEnumerable<VattuyteDTO> VattuyteDTOs { get; set; }
        public IEnumerable<Vattuyte> Vattuytes { get; set; }
        public IEnumerable<Lo> Los { get; set; }

        public IEnumerable<LoDTO> LoDTOs { get; set; }

        public IEnumerable<PhieulinhDTO> PhieulinhDTOs { get; set; }

        public IEnumerable<DonglinhDTO> DonglinhDTOs { get; set; }
        public IEnumerable<DonglinhDTO> DonglinhDTO1s { get; set; }
        public IEnumerable<Donglinh> Donglinhs { get; set; }

        public IEnumerable<PhieuxuatDTO> PhieuxuatDTOs { get; set; }
        public IEnumerable<Dongxuat> Dongxuats { get; set; }
        public IEnumerable<DongxuatDTO> DongxuatDTOs { get; set; }

        public IEnumerable<Phieuxuathuy> Phieuxuathuys { get; set; }
        public IEnumerable<Dongxuathuy> Dongxuathuys { get; set; }

        public IEnumerable<Phieuxuattralai> Phieuxuattralais { get; set; }
        public IEnumerable<DongxuattralaiDTO> DongxuattralaiDTOs { get; set; }
        public IEnumerable<Dongxuattralai> Dongxuattralais { get; set; }
    }
}
