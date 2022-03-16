using Model1.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model1.Dao
{
    public class TralaiDao
    {
        CSDL_NangcaoDbContext db = null;
        public TralaiDao()
        {
            db = new CSDL_NangcaoDbContext();
        }

        public long Sldong()
        {
            long a = db.Phieuxuattralais.LongCount();
            return a;
        }

        public long Sldongchuanhap()
        {
            var model = from l in db.Phieuxuattralais where l.Matinhtrang == "tt001" select new { l.Sophieuxuat, };
            long a = model.LongCount();
            return a;
        }

        public string Insert(Phieuxuattralai order)
        {
            db.Phieuxuattralais.Add(order);
            db.SaveChanges();
            return order.Sophieuxuat;
        }

        public bool Update(Phieuxuattralai entity)
        {
            try
            {
                var pr = db.Phieuxuattralais.Find(entity.Sophieuxuat);
                pr.Sophieuxuat = entity.Sophieuxuat;
                pr.Ngayxuat = entity.Ngayxuat;
                pr.Manhanvien = entity.Manhanvien;
                pr.Ghichu = entity.Ghichu;
                pr.Matinhtrang = entity.Matinhtrang;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                //logging
                return false;
            }
        }

        public bool Updateghichu(string sophieu, string ghichu, string manv2)
        {
            try
            {
                var pr = db.Phieuxuattralais.Find(sophieu);
                pr.Ghichu = ghichu;
                pr.Matinhtrang = "tt002";
                pr.Ngaynhap = DateTime.Now;
                pr.Manhanvien2 = manv2;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                //logging
                return false;
            }
        }

        public bool Deleteslxuat0(string id)
        {
            try
            {
                var pr = db.Phieuxuattralais.Find(id);

                var model = from l in db.Dongxuattralais
                            where l.Sophieuxuat == id && l.SLxuat == 0
                            select new { l.Madongxuattralai };
                foreach (var item in model)
                {
                    var pr1 = db.Dongxuattralais.Find(item.Madongxuattralai);
                    db.Dongxuattralais.Remove(pr1);
                }

                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool Delete(string id)
        {
            try
            {
                var pr = db.Phieuxuattralais.Find(id);

                var model = from l in db.Dongxuattralais where l.Sophieuxuat == id select new { l.Madongxuattralai };
                foreach (var item in model)
                {
                    var pr1 = db.Dongxuattralais.Find(item.Madongxuattralai);
                    var lo = db.Loes.Find(pr1.Malo);
                    lo.SLnhap -= pr1.SLnhap;
                    db.Dongxuattralais.Remove(pr1);
                }

                db.Phieuxuattralais.Remove(pr);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public Phieuxuattralai ViewDetail(string id)
        {
            return db.Phieuxuattralais.Find(id);
        }

        public IEnumerable<Phieuxuattralai> ListAllPaging(string searchString, string a, string b)
        {
            List<Phieuxuattralai> listLinks = new List<Phieuxuattralai>();

            var model = from l in db.Phieuxuattralais // lấy toàn bộ sp
                        select new { l.Sophieuxuat, l.Ngayxuat, l.Manhanvien, l.Madiemtiem, l.Matinhtrang, l.Ngaynhap };

            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Sophieuxuat.Contains(searchString) || x.Sophieuxuat.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(a) && !string.IsNullOrEmpty(b))
            {
                DateTime createdate1 = Convert.ToDateTime(a);
                DateTime createdate2 = Convert.ToDateTime(b);
                model = model.Where(x => x.Ngayxuat >= createdate1 && x.Ngayxuat <= createdate2);
            }

            if (!string.IsNullOrEmpty(a))
            {
                DateTime createdate1 = Convert.ToDateTime(a);
                model = model.Where(x => x.Ngayxuat >= createdate1);
            }

            if (!string.IsNullOrEmpty(b))
            {
                DateTime createdate2 = Convert.ToDateTime(b);
                model = model.Where(x => x.Ngayxuat <= createdate2);
            }

            foreach (var item in model)
            {
                Phieuxuattralai temp = new Phieuxuattralai();
                temp.Sophieuxuat = item.Sophieuxuat;
                temp.Manhanvien = item.Manhanvien;
                temp.Ngayxuat = item.Ngayxuat;
                temp.Matinhtrang = item.Matinhtrang;
                temp.Manhanvien = item.Manhanvien;
                temp.Ngaynhap = item.Ngaynhap;
                listLinks.Add(temp);
            }

            return listLinks.OrderByDescending(x => x.Ngayxuat);
        }

        public IEnumerable<Phieuxuattralai> ListAllPaging1(string searchString , string a, string b)
        {
            List<Phieuxuattralai> listLinks = new List<Phieuxuattralai>();

            var model = from l in db.Phieuxuattralais where l.Matinhtrang == "tt002"
                        select new { l.Sophieuxuat, l.Ngayxuat, l.Manhanvien, l.Madiemtiem, l.Matinhtrang, l.Ngaynhap };

            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Sophieuxuat.Contains(searchString) || x.Sophieuxuat.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(a) && !string.IsNullOrEmpty(b))
            {
                DateTime createdate1 = Convert.ToDateTime(a);
                DateTime createdate2 = Convert.ToDateTime(b);
                model = model.Where(x => x.Ngaynhap >= createdate1 && x.Ngaynhap <= createdate2);
            }

            if (!string.IsNullOrEmpty(a))
            {
                DateTime createdate1 = Convert.ToDateTime(a);
                model = model.Where(x => x.Ngaynhap >= createdate1);
            }

            if (!string.IsNullOrEmpty(b))
            {
                DateTime createdate2 = Convert.ToDateTime(b);
                model = model.Where(x => x.Ngaynhap <= createdate2);
            }

            foreach (var item in model)
            {
                Phieuxuattralai temp = new Phieuxuattralai();
                temp.Sophieuxuat = item.Sophieuxuat;
                temp.Manhanvien = item.Manhanvien;
                temp.Ngayxuat = item.Ngayxuat;
                temp.Matinhtrang = item.Matinhtrang;
                temp.Manhanvien = item.Manhanvien;
                temp.Ngaynhap = item.Ngaynhap;
                listLinks.Add(temp);
            }

            return listLinks.OrderByDescending(x => x.Sophieuxuat);
        }

        public IEnumerable<Phieuxuattralai> ListAllPagingXuatTL(string searchString, string a, string b, string madt)
        {
            List<Phieuxuattralai> listLinks = new List<Phieuxuattralai>();

            var model = from l in db.Phieuxuattralais
                        where l.Madiemtiem == madt
                        select new { l.Sophieuxuat, l.Ngayxuat, l.Manhanvien, l.Madiemtiem, l.Matinhtrang, l.Ngaynhap };

            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Sophieuxuat.Contains(searchString) || x.Sophieuxuat.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(a) && !string.IsNullOrEmpty(b))
            {
                DateTime createdate1 = Convert.ToDateTime(a);
                DateTime createdate2 = Convert.ToDateTime(b);
                model = model.Where(x => x.Ngayxuat >= createdate1 && x.Ngayxuat <= createdate2);
            }

            if (!string.IsNullOrEmpty(a))
            {
                DateTime createdate1 = Convert.ToDateTime(a);
                model = model.Where(x => x.Ngayxuat >= createdate1);
            }

            if (!string.IsNullOrEmpty(b))
            {
                DateTime createdate2 = Convert.ToDateTime(b);
                model = model.Where(x => x.Ngayxuat <= createdate2);
            }

            foreach (var item in model)
            {
                Phieuxuattralai temp = new Phieuxuattralai();
                temp.Sophieuxuat = item.Sophieuxuat;
                temp.Manhanvien = item.Manhanvien;
                temp.Ngayxuat = item.Ngayxuat;
                temp.Matinhtrang = item.Matinhtrang;
                temp.Manhanvien = item.Manhanvien;
                temp.Ngaynhap = item.Ngaynhap;
                listLinks.Add(temp);
            }

            return listLinks.OrderByDescending(x => x.Ngayxuat);
        }
    }
}
