using Model1.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model1.Dao
{
    public class NguonDao
    {
        CSDL_NangcaoDbContext db = null;
        public NguonDao()
        {
            db = new CSDL_NangcaoDbContext();
        }

        public List<Nguon> ListAll()
        {
            return db.Nguons.Where(x => x.Tennguon != "").OrderBy(x => x.Manguon).ToList();
        }

        public Nguon ViewDetail(string id)
        {
            return db.Nguons.Find(id);
        }
    }
}
