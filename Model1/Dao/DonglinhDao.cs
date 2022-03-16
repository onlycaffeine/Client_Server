using Model1.DTO;
using Model1.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model1.Dao
{
    public class DonglinhDao
    {
        CSDL_NangcaoDbContext db = null;
        public DonglinhDao()
        {
            db = new CSDL_NangcaoDbContext();
        }

        public long Sldong()
        {
            long a = db.Donglinhs.LongCount();
            return a;
        }

        public string Insert(Donglinh order)
        {
            db.Donglinhs.Add(order);
            db.SaveChanges();
            return order.Madonglinh;
        }

        public string Insert1(Donglinh order)
        {
            db.Donglinhs.Add(order);
            db.SaveChanges();
            return order.Madonglinh;
        }

        public bool Update(Donglinh entity)
        {
            try
            {
                var pr = db.Donglinhs.Find(entity.Madonglinh);
                pr.SLyeucau = entity.SLyeucau;
                pr.SLcapphat = entity.SLcapphat;
                pr.Mathuoc = entity.Mathuoc;
                pr.Sophieulinh = entity.Sophieulinh;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                //logging
                return false;
            }
        }

        public bool Update1(ref string b)
        {
            try
            {
                var model = from l in db.Donglinhs where l.Sophieulinh == null select new { l.Madonglinh};
                foreach (var item in model)
                {
                    var pr = db.Donglinhs.Find(item.Madonglinh);
                    pr.Sophieulinh = b;

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
                var pr = db.Donglinhs.Find(id);
                db.Donglinhs.Remove(pr);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public Donglinh ViewDetail(string id)
        {
            return db.Donglinhs.Find(id);
        }

        public IEnumerable<DonglinhDTO> ListAllPaging(string mathuoc)
        {
            List<DonglinhDTO> listLinks = new List<DonglinhDTO>();

            var model = from l in db.Donglinhs // lấy toàn bộ sp
                        join p in db.Vattuytes on l.Mathuoc equals p.Mavattu
                        where l.Sophieulinh == mathuoc
                        select new { l.Mathuoc, p.Tenvattu, l.SLyeucau, l.SLcapphat, l.Madonglinh};

            foreach (var item in model)
            {
                DonglinhDTO temp = new DonglinhDTO();
                temp.Madonglinh = item.Madonglinh;
                temp.Mathuoc = item.Mathuoc;
                temp.Tenthuoc = item.Tenvattu;
                temp.SLcapphat = item.SLcapphat;
                temp.SLyeucau = item.SLyeucau;
                listLinks.Add(temp);
            }

            return listLinks.OrderByDescending(x => x.Mathuoc);
        }

        public IEnumerable<DonglinhDTO> ListAllPagingWithSohd(string hd)
        {
            List<DonglinhDTO> listLinks = new List<DonglinhDTO>();

            var model = from l in db.Donglinhs
                        join c in db.Phieulinhs on l.Sophieulinh equals c.Sophieulinh
                        join d in db.Diemtiems on c.Madiemtiem equals d.Madiemtiem
                        join p in db.Vattuytes on l.Mathuoc equals p.Mavattu
                        join q in db.Trangthais on c.Matt equals q.Matrangthai
                        where l.Sophieulinh == hd
                        select new { l.Mathuoc, p.Tenvattu, l.SLyeucau, l.SLcapphat, l.Sophieulinh, l.Madonglinh, d.Tendiemtiem, c.Matt, q.Tentrangthai};

            foreach (var item in model)
            {
                DonglinhDTO temp = new DonglinhDTO();
                temp.Sophieulinh = item.Sophieulinh;
                temp.Madonglinh = item.Madonglinh;
                temp.Mathuoc = item.Mathuoc;
                temp.Tenthuoc = item.Tenvattu;
                temp.SLcapphat = item.SLcapphat;
                temp.SLyeucau = item.SLyeucau;
                temp.Tendiemtiem = item.Tendiemtiem;
                temp.Trangthai = item.Tentrangthai;
                listLinks.Add(temp);
            }

            return listLinks.OrderByDescending(x => x.Mathuoc);
        }

        public IEnumerable<Donglinh> ListAllPagingWithSohd1(string hd)
        {
            List<Donglinh> listLinks = new List<Donglinh>();

            var model = from l in db.Donglinhs
                        join c in db.Phieulinhs on l.Sophieulinh equals c.Sophieulinh
                        join p in db.Vattuytes on l.Mathuoc equals p.Mavattu
                        where l.Sophieulinh == hd
                        select new { l.Mathuoc, p.Tenvattu, l.SLyeucau, l.SLcapphat, l.Sophieulinh, l.Madonglinh };

            foreach (var item in model)
            {
                Donglinh temp = new Donglinh();
                temp.Sophieulinh = item.Sophieulinh;
                temp.Madonglinh = item.Madonglinh;
                temp.Mathuoc = item.Mathuoc;
                temp.SLcapphat = item.SLcapphat;
                temp.SLyeucau = item.SLyeucau;
                listLinks.Add(temp);
            }

            return listLinks.OrderByDescending(x => x.Mathuoc);
        }

        public IEnumerable<DonglinhDTO> ListAllPagingWithoutSohd(string searchString)
        {
            List<DonglinhDTO> listLinks = new List<DonglinhDTO>();

            var model = from l in db.Donglinhs
                        join p in db.Vattuytes on l.Mathuoc equals p.Mavattu
                        where l.Sophieulinh == null
                        select new { l.Mathuoc, p.Tenvattu, l.SLyeucau, l.SLcapphat, l.Sophieulinh, l.Madonglinh };

            foreach (var item in model)
            {
                DonglinhDTO temp = new DonglinhDTO();
                temp.Sophieulinh = item.Sophieulinh;
                temp.Madonglinh = item.Madonglinh;
                temp.Mathuoc = item.Mathuoc;
                temp.Tenthuoc = item.Tenvattu;
                temp.SLcapphat = item.SLcapphat;
                temp.SLyeucau = item.SLyeucau;
                listLinks.Add(temp);
            }

            return listLinks.OrderByDescending(x => x.Mathuoc);
        }

        public IEnumerable<DonglinhDTO> ListAllPagingWithoutSohd()
        {
            List<DonglinhDTO> listLinks = new List<DonglinhDTO>();

            var model = from l in db.Donglinhs
                        join p in db.Vattuytes on l.Mathuoc equals p.Mavattu
                        where l.Sophieulinh == null
                        select new { l.Mathuoc, p.Tenvattu, l.SLyeucau, l.SLcapphat, l.Sophieulinh, l.Madonglinh };

            foreach (var item in model)
            {
                DonglinhDTO temp = new DonglinhDTO();
                temp.Sophieulinh = item.Sophieulinh;
                temp.Madonglinh = item.Madonglinh;
                temp.Mathuoc = item.Mathuoc;
                temp.Tenthuoc = item.Tenvattu;
                temp.SLcapphat = item.SLcapphat;
                temp.SLyeucau = item.SLyeucau;
                listLinks.Add(temp);
            }

            return listLinks.OrderByDescending(x => x.Mathuoc);
        }
    }
}
