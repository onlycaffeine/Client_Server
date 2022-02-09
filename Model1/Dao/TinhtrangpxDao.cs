using Model1.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model1.Dao
{
    public class TinhtrangpxDao
    {
        CSDL_NangcaoDbContext db = null;
        public TinhtrangpxDao()
        {
            db = new CSDL_NangcaoDbContext();
        }

        public List<Tinhtrangpx> ListAll()
        {
            return db.Tinhtrangpxes.Where(x => x.Tentinhtrang != "").OrderByDescending(x => x.Matinhtrang).ToList();
        }

        public Tinhtrangpx ViewDetail(string id)
        {
            return db.Tinhtrangpxes.Find(id);
        }
    }
}
