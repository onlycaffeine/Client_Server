using Model1.DTO;
using Model1.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model1.Dao
{
    public class DongxuatDao
    {
        CSDL_NangcaoDbContext db = null;
        public DongxuatDao()
        {
            db = new CSDL_NangcaoDbContext();
        }

        public long Sldong()
        {
            long a = db.Dongxuats.LongCount();
            return a;
        }

        public string Insert(Dongxuat order)
        {
            db.Dongxuats.Add(order);

            //var lo = db.Loes.Find(order.Malo);
            //lo.SLnhap -= order.SLxuat;

            db.SaveChanges();
            return order.Madongxuat;
        }

        public bool Update(Dongxuat entity)
        {
            try
            {
                var pr = db.Dongxuats.Find(entity.Madongxuat);
                pr.Sophieuxuat = entity.Sophieuxuat;
                pr.Malo = entity.Malo;
                pr.SLxuat = entity.SLxuat;
                pr.Dongia = entity.Dongia;
                pr.Thanhtien = entity.Thanhtien;
                pr.Tenthuoc = entity.Tenthuoc;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                //logging
                return false;
            }
        }

        public bool Update1(ref string cc)
        {
            try
            {
                var model = from l in db.Dongxuats where l.Sophieuxuat == null select new { l.Madongxuat };
                foreach (var item in model)
                {
                    var pr = db.Dongxuats.Find(item.Madongxuat);
                    pr.Sophieuxuat = cc;

                }
                db.SaveChanges();
            }

            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public bool Delete(string id)
        {
            try
            {
                var pr = db.Dongxuats.Find(id);

                var lo = db.Loes.Find(pr.Malo);
                lo.SLnhap += pr.SLxuat;

                db.Dongxuats.Remove(pr);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public Dongxuat ViewDetail(string id)
        {
            return db.Dongxuats.Find(id);
        }

        public IEnumerable<DongxuatDTO> ListAllPagingdt(string madt)
        {
            List<DongxuatDTO> listLinks = new List<DongxuatDTO>();

            var model = from l in db.Dongxuats // lấy toàn bộ sp
                        join p in db.Loes on l.Malo equals p.Malo
                        join k in db.Vattuytes on p.Mavattu equals k.Mavattu
                        join q in db.Phieuxuats on l.Sophieuxuat equals q.Sophieuxuat
                        where q.Madiemtiem == madt
                        select new { l.Malo, k.Tenvattu, l.SLxuat, l.Dongia, l.Thanhtien, l.Madongxuat, p.HSD, l.Sophieuxuat, q.Ngayxuat };


            foreach (var item in model)
            {
                DongxuatDTO temp = new DongxuatDTO();
                temp.Madongxuat = item.Madongxuat;
                temp.Malo = item.Malo;
                temp.Tenthuoc = item.Tenvattu;
                temp.Dongia = item.Dongia;
                temp.Thanhtien = item.Thanhtien;
                temp.SLxuat = item.SLxuat;
                temp.HSD = item.HSD;
                temp.Sophieuxuat = item.Sophieuxuat;
                temp.Tenthuoc = item.Tenvattu;
                temp.Ngayxuat = item.Ngayxuat;
                listLinks.Add(temp);
            }

            return listLinks.OrderByDescending(x => x.Malo);
        }

        public IEnumerable<Dongxuat> ListAllPaging(string mathuoc)
        {
            List<Dongxuat> listLinks = new List<Dongxuat>();

            var model = from l in db.Dongxuats // lấy toàn bộ sp
                        join p in db.Loes on l.Malo equals p.Malo
                        join k in db.Vattuytes on p.Mavattu equals k.Mavattu
                        where l.Sophieuxuat == mathuoc
                        select new { l.Malo, k.Tenvattu, l.SLxuat, l.Dongia,l.Thanhtien, l.Madongxuat, p.HSD, l.Sophieuxuat, l.SLnhap };

            foreach (var item in model)
            {
                Dongxuat temp = new Dongxuat();
                temp.Madongxuat = item.Madongxuat;
                temp.Malo = item.Malo;
                temp.Tenthuoc = item.Tenvattu;
                temp.Dongia = item.Dongia;
                temp.Thanhtien = item.Thanhtien;
                temp.SLxuat = item.SLxuat;
                temp.SLnhap = item.SLnhap;
                temp.HSD = item.HSD;
                temp.Sophieuxuat = item.Sophieuxuat;
                temp.Tenthuoc = item.Tenvattu;
                listLinks.Add(temp);
            }

            return listLinks.OrderByDescending(x => x.Malo);
        }

        public IEnumerable<Dongxuat> ListAllPagingWithSohd(Phieuxuat hd)
        {
            List<Dongxuat> listLinks = new List<Dongxuat>();

            var model = from l in db.Dongxuats // lấy toàn bộ sp
                        join p in db.Loes on l.Malo equals p.Malo
                        join k in db.Vattuytes on p.Mavattu equals k.Mavattu
                        where l.Sophieuxuat == hd.Sophieuxuat
                        select new { l.Malo, k.Tenvattu, l.SLxuat, l.Dongia, l.Thanhtien, l.Madongxuat, p.HSD, l.Sophieuxuat, l.SLnhap };

            foreach (var item in model)
            {
                Dongxuat temp = new Dongxuat();
                temp.Sophieuxuat = item.Sophieuxuat;
                temp.Madongxuat = item.Madongxuat;
                temp.Malo = item.Malo;
                temp.Tenthuoc = item.Tenvattu;
                temp.SLxuat = item.SLxuat;
                temp.SLnhap = item.SLnhap;
                temp.Dongia = item.Dongia;
                temp.Thanhtien = item.Thanhtien;
                temp.HSD = item.HSD;
                temp.Sophieuxuat = item.Sophieuxuat;
                temp.Tenthuoc = item.Tenvattu;
                listLinks.Add(temp);
            }

            return listLinks.OrderByDescending(x => x.Malo);
        }

        public IEnumerable<Dongxuat> ListAllPagingWithoutSohd(string searchString)
        {
            List<Dongxuat> listLinks = new List<Dongxuat>();

            var model = from l in db.Dongxuats
                        join p in db.Loes on l.Malo equals p.Malo
                        join k in db.Vattuytes on p.Mavattu equals k.Mavattu
                        where l.Sophieuxuat == null
                        select new { l.Malo, k.Tenvattu, l.SLxuat, l.Dongia, l.Thanhtien, l.Madongxuat, p.HSD, l.Sophieuxuat };

            foreach (var item in model)
            {
                Dongxuat temp = new Dongxuat();
                temp.Madongxuat = item.Madongxuat;
                temp.Malo = item.Malo;
                temp.Tenthuoc = item.Tenvattu;
                temp.Dongia = item.Dongia;
                temp.Thanhtien = item.Thanhtien;
                temp.SLxuat = item.SLxuat;
                temp.HSD = item.HSD;
                temp.Sophieuxuat = item.Sophieuxuat;
                temp.Tenthuoc = item.Tenvattu;
                listLinks.Add(temp);
            }

            return listLinks.OrderByDescending(x => x.Malo);
        }

        public IEnumerable<Dongxuat> ListAllPagingWithoutSohd()
        {
            List<Dongxuat> listLinks = new List<Dongxuat>();

            var model = from l in db.Dongxuats
                        join p in db.Loes on l.Malo equals p.Malo
                        join k in db.Vattuytes on p.Mavattu equals k.Mavattu
                        where l.Sophieuxuat == null
                        select new { l.Malo, k.Tenvattu, l.SLxuat, l.Dongia, l.Thanhtien, l.Madongxuat, p.HSD, l.Sophieuxuat };

            foreach (var item in model)
            {
                Dongxuat temp = new Dongxuat();
                temp.Madongxuat = item.Madongxuat;
                temp.Malo = item.Malo;
                temp.Tenthuoc = item.Tenvattu;
                temp.Dongia = item.Dongia;
                temp.Thanhtien = item.Thanhtien;
                temp.SLxuat = item.SLxuat;
                temp.HSD = item.HSD;
                temp.Sophieuxuat = item.Sophieuxuat;
                temp.Tenthuoc = item.Tenvattu;
                listLinks.Add(temp);
            }

            return listLinks.OrderByDescending(x => x.Malo);
        }
    }
}
