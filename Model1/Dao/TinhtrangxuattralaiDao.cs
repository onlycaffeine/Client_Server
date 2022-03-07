using Model1.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model1.Dao
{
    public class TinhtrangxuattralaiDao
    {
        CSDL_NangcaoDbContext db = null;
        public TinhtrangxuattralaiDao()
        {
            db = new CSDL_NangcaoDbContext();
        }

        public List<Tinhtrangpxuattralai> ListAll()
        {
            return db.Tinhtrangpxuattralais.Where(x => x.Tentrangthai != "").OrderBy(x => x.Matrangthai).ToList();
        }

        public Tinhtrangpxuattralai ViewDetail(string id)
        {
            return db.Tinhtrangpxuattralais.Find(id);
        }
    }
}
