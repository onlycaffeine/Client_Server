using Model1.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model1.Dao
{
    public class KhoDao
    {
        CSDL_NangcaoDbContext db = null;
        public KhoDao()
        {
            db = new CSDL_NangcaoDbContext();
        }

        public List<Kho> ListAll()
        {
            return db.Khoes.Where(x => x.Tenkho != "").OrderBy(x => x.Makho).ToList();
        }

        public Kho ViewDetail(string id)
        {
            return db.Khoes.Find(id);
        }
    }
}
