using Model1.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model1.Dao
{
    public class TrangthaiDao
    {
        CSDL_NangcaoDbContext db = null;
        public TrangthaiDao()
        {
            db = new CSDL_NangcaoDbContext();
        }

        public List<Trangthai> ListAll()
        {
            return db.Trangthais.Where(x => x.Tentrangthai != "").OrderBy(x => x.Matrangthai).ToList();
        }

        public Trangthai ViewDetail(string id)
        {
            return db.Trangthais.Find(id);
        }
    }
}
