using Model1.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model1.Dao
{
    public class ChithinhietdoDao
    {
        CSDL_NangcaoDbContext db = null;
        public ChithinhietdoDao()
        {
            db = new CSDL_NangcaoDbContext();
        }

        public List<Chithinhietdo> ListAll()
        {
            return db.Chithinhietdoes.Where(x => x.Tenchithinhietdo != "").OrderBy(x => x.Machithinhietdo).ToList();
        }

        public Chithinhietdo ViewDetail(string id)
        {
            return db.Chithinhietdoes.Find(id);
        }
    }
}
