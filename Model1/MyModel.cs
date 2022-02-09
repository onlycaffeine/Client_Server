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
        public IEnumerable<Lo> Los { get; set; }

        public IEnumerable<LoDTO> LoDTOs { get; set; }

        public IEnumerable<PhieulinhDTO> PhieulinhDTOs { get; set; }

        public IEnumerable<DonglinhDTO> DonglinhDTOs { get; set; }

        public IEnumerable<PhieuxuatDTO> PhieuxuatDTOs { get; set; }
        public IEnumerable<Dongxuat> Dongxuats { get; set; }
    }
}
