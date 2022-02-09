using Model1.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model1.Dao
{
    public class QuanDao
    {
            CSDL_NangcaoDbContext db = null;
            public QuanDao()
            {
                db = new CSDL_NangcaoDbContext();
            }

            public List<Quan> ListAll()
            {
                return db.Quans.Where(x => x.Tenquan != "").OrderBy(x => x.Maquan).ToList();
            }

            public string Check(string id)
            {
                Quan dt = db.Quans.Find(id);
                return dt.Maquan;
            }

            public Quan ViewDetail(string id)
            {
                return db.Quans.Find(id);
            }
        }

}
