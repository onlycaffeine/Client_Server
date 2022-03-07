using Model1.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model1.Dao
{
    public class DongxuathuyDao
    {
        CSDL_NangcaoDbContext db = null;
        public DongxuathuyDao()
        {
            db = new CSDL_NangcaoDbContext();
        }

        public long Sldong()
        {
            long a = db.Dongxuathuys.LongCount();
            return a;
        }

        public string Insert(Dongxuathuy order)
        {
            db.Dongxuathuys.Add(order);

            var lo = db.Loes.Find(order.Malo);
            lo.SLnhap -= order.Slxuat;

            db.SaveChanges();
            return order.Maphieuxuathuy;
        }

        public bool Update(Dongxuathuy entity)
        {
            try
            {
                var pr = db.Dongxuathuys.Find(entity.Madongxuathuy);
                pr.Madongxuathuy = entity.Madongxuathuy;
                pr.Maphieuxuathuy = entity.Maphieuxuathuy;
                pr.Malo = entity.Malo;
                pr.Slxuat = entity.Slxuat;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                //logging
                return false;
            }
        }

        public bool Delete(string id)
        {
            try
            {
                var pr = db.Dongxuathuys.Find(id);

                var lo = db.Loes.Find(pr.Malo);
                lo.SLnhap += pr.Slxuat;

                db.Dongxuathuys.Remove(pr);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public Dongxuathuy ViewDetail(string id)
        {
            return db.Dongxuathuys.Find(id);
        }

        public IEnumerable<Dongxuathuy> ListAllPaging(string mathuoc)
        {
            List<Dongxuathuy> listLinks = new List<Dongxuathuy>();

            var model = from l in db.Dongxuathuys // lấy toàn bộ sp
                        join p in db.Loes on l.Malo equals p.Malo
                        join k in db.Vattuytes on p.Mavattu equals k.Mavattu
                        where l.Maphieuxuathuy == null
                        select new { l.Malo, k.Tenvattu, l.Slxuat, l.Maphieuxuathuy, l.Madongxuathuy};

            foreach (var item in model)
            {
                Dongxuathuy temp = new Dongxuathuy();
                temp.Maphieuxuathuy = item.Maphieuxuathuy;
                temp.Malo = item.Malo;
                temp.Slxuat = item.Slxuat;
                temp.Madongxuathuy = item.Madongxuathuy;
                listLinks.Add(temp);
            }

            return listLinks.OrderByDescending(x => x.Malo);
        }

        public IEnumerable<Dongxuathuy> ListAllPagingWithSohd(Phieuxuathuy hd)
        {
            List<Dongxuathuy> listLinks = new List<Dongxuathuy>();

            var model = from l in db.Dongxuathuys // lấy toàn bộ sp
                        join p in db.Loes on l.Malo equals p.Malo
                        join k in db.Vattuytes on p.Mavattu equals k.Mavattu
                        where l.Maphieuxuathuy == hd.Sophieuxuat
                        select new { l.Malo, k.Tenvattu, l.Slxuat, l.Maphieuxuathuy, l.Madongxuathuy};

            foreach (var item in model)
            {
                Dongxuathuy temp = new Dongxuathuy();
                temp.Maphieuxuathuy = item.Maphieuxuathuy;
                temp.Malo = item.Malo;
                temp.Slxuat = item.Slxuat;
                temp.Madongxuathuy = item.Madongxuathuy;
                listLinks.Add(temp);
            }

            return listLinks.OrderByDescending(x => x.Malo);
        }
        
    }
}
