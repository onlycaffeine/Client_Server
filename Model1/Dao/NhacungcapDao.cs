using Model1.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model1.Dao
{
    public class NhacungcapDao
    {
        CSDL_NangcaoDbContext db = null;
        public NhacungcapDao()
        {
            db = new CSDL_NangcaoDbContext();
        }

        public List<Nhacungcap> ListAll()
        {
            return db.Nhacungcaps.Where(x => x.Tencc != "").OrderBy(x => x.Mancc).ToList();
        }

        public Nhacungcap ViewDetail(string id)
        {
            return db.Nhacungcaps.Find(id);
        }
    }
}
