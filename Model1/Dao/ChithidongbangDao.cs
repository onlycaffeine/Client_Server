using Model1.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model1.Dao
{
    public class ChithidongbangDao
    {
        CSDL_NangcaoDbContext db = null;
        public ChithidongbangDao()
        {
            db = new CSDL_NangcaoDbContext();
        }

        public List<Chithidongbang> ListAll()
        {
            return db.Chithidongbangs.Where(x => x.Tenchithidongbang != "").OrderBy(x => x.Machithidongbang).ToList();
        }

        public Chithidongbang ViewDetail(string id)
        {
            return db.Chithidongbangs.Find(id);
        }
    }
}
