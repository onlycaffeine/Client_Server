using Model1.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model1.Dao
{
    public class TiensuDao
    {
        CSDL_NangcaoDbContext db = null;
        public TiensuDao()
        {
            db = new CSDL_NangcaoDbContext();
        }

        public List<Tiensu> ListAll()
        {
            return db.Tiensus.Where(x => x.Ten != "").OrderBy(x => x.Matiensu).ToList();
        }

        public IEnumerable<Tiensu> ListAllPaging()
        {
            List<Tiensu> listLinks = new List<Tiensu>();
            var model = from l in db.Tiensus
                        select new { l.Matiensu, l.Ten, l.Trieuchung, l.Ghiro };
            foreach (var item in model)
            {
                Tiensu temp = new Tiensu();
                temp.Matiensu = item.Matiensu;
                temp.Ten = item.Ten;
                temp.Trieuchung = item.Trieuchung;
                temp.Ghiro = item.Ghiro;
                listLinks.Add(temp);
            }

            return listLinks.OrderBy(x => x.Matiensu);
        }
    }
}
