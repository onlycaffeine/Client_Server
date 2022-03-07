using Model1.DTO;
using Model1.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model1.Dao
{
    public class PhieuxuathuyDao
    {
        CSDL_NangcaoDbContext db = null;
        public PhieuxuathuyDao()
        {
            db = new CSDL_NangcaoDbContext();
        }

        public long Sldong()
        {
            long a = db.Phieuxuathuys.LongCount();
            return a;
        }

        public string Insert(Phieuxuathuy order)
        {
            db.Phieuxuathuys.Add(order);
            db.SaveChanges();
            return order.Sophieuxuat;
        }

        public bool Update(Phieuxuathuy entity)
        {
            try
            {
                var pr = db.Phieuxuathuys.Find(entity.Sophieuxuat);
                pr.Sophieuxuat = entity.Sophieuxuat;
                pr.Ngayxuat = entity.Ngayxuat;
                pr.Manhanvien = entity.Manhanvien;
                pr.Ghichu = entity.Ghichu;
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
                var pr = db.Phieuxuathuys.Find(id);

                var model = from l in db.Dongxuathuys where l.Maphieuxuathuy == id select new { l.Madongxuathuy };
                foreach (var item in model)
                {
                    var pr1 = db.Dongxuathuys.Find(item.Madongxuathuy);
                    var lo = db.Loes.Find(pr1.Malo);
                    lo.SLnhap += pr1.Slxuat;
                    db.Dongxuathuys.Remove(pr1);
                }

                db.Phieuxuathuys.Remove(pr);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool Deleteslxuat0(string id)
        {
            try
            {
                var pr = db.Phieuxuathuys.Find(id);

                var model = from l in db.Dongxuathuys 
                            where l.Maphieuxuathuy == id && l.Slxuat == 0
                            select new { l.Madongxuathuy };
                foreach (var item in model)
                {
                    var pr1 = db.Dongxuathuys.Find(item.Madongxuathuy);
                    db.Dongxuathuys.Remove(pr1);
                }

                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public Phieuxuathuy ViewDetail(string id)
        {
            return db.Phieuxuathuys.Find(id);
        }

        public IEnumerable<Phieuxuathuy> ListAllPaging(string searchString, string a, string b)
        {
            List<Phieuxuathuy> listLinks = new List<Phieuxuathuy>();

            var model = from l in db.Phieuxuathuys
                        select new { l.Sophieuxuat, l.Ngayxuat,  l.Manhanvien };

            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Sophieuxuat.Contains(searchString) || x.Sophieuxuat.Contains(searchString));
            }

            //if (!string.IsNullOrEmpty(a) && !string.IsNullOrEmpty(b))
            //{
            //    DateTime createdate1 = Convert.ToDateTime(a);
            //    DateTime createdate2 = Convert.ToDateTime(b);
            //    model = model.Where(x => x.Ngayxuat >= createdate1 && x.Ngayxuat <= createdate2);
            //}

            //if (!string.IsNullOrEmpty(a))
            //{
            //    DateTime createdate1 = Convert.ToDateTime(a);
            //    model = model.Where(x => x.Ngayxuat >= createdate1);
            //}

            //if (!string.IsNullOrEmpty(b))
            //{
            //    DateTime createdate2 = Convert.ToDateTime(b);
            //    model = model.Where(x => x.Ngayxuat <= createdate2);
            //}

            foreach (var item in model)
            {
                Phieuxuathuy temp = new Phieuxuathuy();
                temp.Sophieuxuat = item.Sophieuxuat; 
                temp.Manhanvien = item.Manhanvien;
                temp.Ngayxuat = item.Ngayxuat;
                listLinks.Add(temp);
            }

            return listLinks.OrderByDescending(x => x.Ngayxuat);
        }
    }
}
