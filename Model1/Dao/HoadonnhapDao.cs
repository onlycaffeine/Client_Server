using Model1.DTO;
using Model1.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model1.Dao
{
    public class HoadonnhapDao
    {
        CSDL_NangcaoDbContext db = null;
        public HoadonnhapDao()
        {
            db = new CSDL_NangcaoDbContext();
        }

        public string Insert(Hoadonnhap order)
        {
            db.Hoadonnhaps.Add(order);
            db.SaveChanges();
            return order.Sohoadon;
        }

        public bool Update(Hoadonnhap entity)
        {
            try
            {
                var pr = db.Hoadonnhaps.Find(entity.Sohoadon);
                pr.Sohoadon = entity.Sohoadon;
                pr.Ngaynhap = entity.Ngaynhap;
                pr.Mancc = entity.Mancc;
                pr.Manguon = entity.Manguon;
                pr.Makhonhap = entity.Makhonhap;
                pr.Manhanvien = entity.Manhanvien;
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
                var pr = db.Hoadonnhaps.Find(id);

                var model = from l in db.Loes where l.Sohoadon == id select new { l.Malo };
                foreach (var item in model)
                {
                    var pr1 = db.Loes.Find(item.Malo);
                    db.Loes.Remove(pr1);
                }

                db.Hoadonnhaps.Remove(pr);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool Deletephieutiem(string id)
        {
            try
            {
                var pr = db.Phieutiems.Find(id);

                var model = from l in db.Chitietphhieutiems where l.Sophieutiem == id select new { l.Machitietphieutiem };
                foreach (var item in model)
                {
                    var pr1 = db.Loes.Find(item.Machitietphieutiem);
                    db.Loes.Remove(pr1);
                }

                db.Phieutiems.Remove(pr);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public Hoadonnhap ViewDetail(string id)
        {
            return db.Hoadonnhaps.Find(id);
        }

        public IEnumerable<HoadonnhapDTO> ListAllPaging(string searchString, int page, int pageSize, string a, string b, string Mancc, string Manguon, string Makho)
        {
            List<HoadonnhapDTO> listLinks = new List<HoadonnhapDTO>();

            var model = from l in db.Hoadonnhaps // lấy toàn bộ sp
                        join c in db.Nhacungcaps on l.Mancc equals c.Mancc
                        join n in db.Nguons on l.Manguon equals n.Manguon
                        join k in db.Khoes on l.Makhonhap equals k.Makho
                        select new { l.Sohoadon, l.Mancc, l.Manhanvien, l.Manguon, l.Makhonhap, l.Ngaynhap, c.Tencc, n.Tennguon, k.Tenkho, l.Diadiem};

            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Sohoadon.Contains(searchString) || x.Sohoadon.Contains(searchString));
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
                HoadonnhapDTO temp = new HoadonnhapDTO();
                temp.Sohoadon = item.Sohoadon;
                temp.Mancc = item.Mancc;
                temp.Ncc = item.Tencc;
                temp.Manguon = item.Manguon;
                temp.Nguon = item.Tennguon;
                temp.Makhonhap = item.Makhonhap;
                temp.Kho = item.Tenkho;
                temp.Ngaynhap = item.Ngaynhap;
                temp.Manhanvien = item.Manhanvien;
                temp.Diadiem = item.Diadiem;
                listLinks.Add(temp);
            }

            return listLinks.OrderByDescending(x => x.Ngaynhap);
        }
    }
}
