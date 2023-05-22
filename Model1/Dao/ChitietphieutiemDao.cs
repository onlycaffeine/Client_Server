using Model1.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model1.Dao
{
    public class ChitietphieutiemDao
    {
        CSDL_NangcaoDbContext db = null;
        public ChitietphieutiemDao()
        {
            db = new CSDL_NangcaoDbContext();
        }

        public string Insert(Chitietphhieutiem order)
        {
            db.Chitietphhieutiems.Add(order);
            db.SaveChanges();
            return order.Machitietphieutiem;

        }

        public DateTime ngaytiemtruoc(string maphieutiem, int loaimuitruoc)
        {
            var p = db.Chitietphhieutiems.FirstOrDefault(x => x.Sophieutiem == maphieutiem && x.Loaimui == (loaimuitruoc - 1).ToString());
            return p.Ngaytiem;
        }

        public long Sldong()
        {
            long a = db.Chitietphhieutiems.LongCount();
            return a;
        }

        public bool Update(Chitietphhieutiem entity)
        {
            try
            {
                var pr = db.Chitietphhieutiems.Find(entity.Machitietphieutiem);
                pr.Loaimui = entity.Loaimui;
                pr.Ngaytiem = entity.Ngaytiem;
                pr.Trieuchung = entity.Trieuchung;
                pr.Machitietphieutiem = entity.Machitietphieutiem;
                pr.Mathuoc = entity.Mathuoc;
                pr.Tenthuoc = entity.Tenthuoc;
                pr.Tendiemtiem = entity.Tendiemtiem;
                pr.Sophieutiem = entity.Sophieutiem;
                pr.Loaitc = entity.Loaitc;
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
                var pr = db.Chitietphhieutiems.Find(id);
                db.Chitietphhieutiems.Remove(pr);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Chitietphhieutiem ViewDetail(string id)
        {
            return db.Chitietphhieutiems.Find(id);
        }

        public IEnumerable<Chitietphhieutiem> ListAllPaging()
        {
            List<Chitietphhieutiem> listLinks = new List<Chitietphhieutiem>();

            var model = from l in db.Chitietphhieutiems // lấy toàn bộ sp
                        join k in db.Diemtiems on l.Madiemtiem equals k.Madiemtiem
                        join p in db.Loes on l.Malo equals p.Malo
                        join q in db.Vattuytes on p.Mavattu equals q.Mavattu
                        select new { l.Sophieutiem, l.Madiemtiem, q.Tenvattu, l.Loaimui, l.Ngaytiem, k.Tendiemtiem, 
                            l.Trieuchung, l.Ghichu, l.Loaitc, l.Machitietphieutiem, l.Malo};

            foreach (var item in model)
            {
                Chitietphhieutiem temp = new Chitietphhieutiem();
                temp.Machitietphieutiem = item.Machitietphieutiem;
                temp.Sophieutiem = item.Sophieutiem;
                temp.Madiemtiem = item.Madiemtiem;
                temp.Tenthuoc = item.Tenvattu;
                temp.Loaimui = item.Loaimui;
                temp.Ngaytiem = item.Ngaytiem;
                temp.Tendiemtiem = item.Tendiemtiem;
                temp.Trieuchung = item.Trieuchung;
                temp.Ghichu = item.Ghichu;
                temp.Loaitc = item.Loaitc;
                temp.Malo = item.Malo;
                listLinks.Add(temp);
            }

            return listLinks.OrderByDescending(x => x.Loaimui);
        }

        public IEnumerable<Chitietphhieutiem> ListAllPagingWithSopn(Phieutiem hd)
        {
            List<Chitietphhieutiem> listLinks = new List<Chitietphhieutiem>();

            var model = from l in db.Chitietphhieutiems
                        join c in db.Phieutiems on l.Sophieutiem equals c.Sophieu
                        join k in db.Diemtiems on l.Madiemtiem equals k.Madiemtiem
                        join p in db.Loes on l.Malo equals p.Malo
                        join q in db.Vattuytes on p.Mavattu equals q.Mavattu
                        where l.Sophieutiem == hd.Sophieu
                        select new { l.Sophieutiem, l.Madiemtiem, q.Tenvattu, l.Loaimui, l.Ngaytiem, k.Tendiemtiem, 
                            l.Trieuchung, l.Ghichu, l.Loaitc, l.Machitietphieutiem, l.Malo};

            foreach (var item in model)
            {
                Chitietphhieutiem temp = new Chitietphhieutiem();
                temp.Machitietphieutiem = item.Machitietphieutiem;
                temp.Sophieutiem = item.Sophieutiem;
                temp.Madiemtiem = item.Madiemtiem;
                temp.Tenthuoc = item.Tenvattu;
                temp.Loaimui = item.Loaimui;
                temp.Ngaytiem = item.Ngaytiem;
                temp.Tendiemtiem = item.Tendiemtiem;
                temp.Trieuchung = item.Trieuchung;
                temp.Ghichu = item.Ghichu;
                temp.Loaitc = item.Loaitc;
                temp.Malo = item.Malo;
                listLinks.Add(temp);
            }

            return listLinks.OrderByDescending(x => x.Loaimui);
        }

    }
}
