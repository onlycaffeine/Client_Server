using Model1.DTO;
using Model1.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model1.Dao
{
    public class DongtralaiDao
    {
        CSDL_NangcaoDbContext db = null;
        public DongtralaiDao()
        {
            db = new CSDL_NangcaoDbContext();
        }

        public long Sldong()
        {
            long a = db.Dongxuattralais.LongCount();
            return a;
        }

        public string Insert(Dongxuattralai order)
        {
            db.Dongxuattralais.Add(order);

            //var lo = db.Loes.Find(order.Malo);
            //lo.SLnhap += order.SLnhap;

            db.SaveChanges();
            return order.Sophieuxuat;
        }

        public bool Updatexuat(Dongxuattralai entity)
        {
            try
            {
                var pr = db.Dongxuattralais.Find(entity.Madongxuattralai);
                pr.Madongxuattralai = entity.Madongxuattralai;
                pr.Sophieuxuat = entity.Sophieuxuat;
                pr.Malo = entity.Malo;
                pr.SLxuat = entity.SLxuat;
                //pr.SLnhap = entity.SLnhap;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                //logging
                return false;
            }
        }

        public bool Update(Dongxuattralai entity)
        {
            try
            {
                var pr = db.Dongxuattralais.Find(entity.Madongxuattralai);
                pr.Madongxuattralai = entity.Madongxuattralai;
                pr.Sophieuxuat = entity.Sophieuxuat;
                pr.Malo = entity.Malo;
                //pr.SLxuat = entity.SLxuat;
                pr.SLnhap = entity.SLnhap;
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
                var pr = db.Dongxuattralais.Find(id);

                var lo = db.Loes.Find(pr.Malo);
                lo.SLnhap -= pr.SLnhap;

                db.Dongxuattralais.Remove(pr);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public Dongxuattralai ViewDetail(string id)
        {
            return db.Dongxuattralais.Find(id);
        }

        public IEnumerable<DongxuattralaiDTO> ListAllPaging(string macpxtl)
        {
            List<DongxuattralaiDTO> listLinks = new List<DongxuattralaiDTO>();

            var model = from l in db.Dongxuattralais // lấy toàn bộ sp
                        join p in db.Loes on l.Malo equals p.Malo
                        join k in db.Vattuytes on p.Mavattu equals k.Mavattu
                        join q in db.Phieuxuattralais on l.Sophieuxuat equals q.Sophieuxuat
                        join m in db.Diemtiems on q.Madiemtiem equals m.Madiemtiem
                        where l.Sophieuxuat == macpxtl
                        select new { l.Malo, k.Tenvattu, l.SLxuat, l.SLnhap, l.Madongxuattralai, l.Sophieuxuat, p.HSD, m.Tendiemtiem};

            foreach (var item in model)
            {
                DongxuattralaiDTO temp = new DongxuattralaiDTO();
                temp.Sophieuxuat = item.Sophieuxuat;
                temp.Malo = item.Malo;
                temp.SLnhap = item.SLnhap;
                temp.SLxuat = item.SLxuat;
                temp.Madongxuattralai = item.Madongxuattralai;
                temp.Tenvattu = item.Tenvattu;
                temp.HSD = item.HSD;
                temp.Tendiemtiem = item.Tendiemtiem;
                listLinks.Add(temp);
            }

            return listLinks.OrderByDescending(x => x.Malo);
        }

        public IEnumerable<Dongxuattralai> ListAllPagingWithSohd(Phieuxuattralai hd)
        {
            List<Dongxuattralai> listLinks = new List<Dongxuattralai>();

            var model = from l in db.Dongxuattralais // lấy toàn bộ sp
                        join p in db.Loes on l.Malo equals p.Malo
                        join k in db.Vattuytes on p.Mavattu equals k.Mavattu
                        where l.Sophieuxuat == hd.Sophieuxuat
                        select new { l.Malo, k.Tenvattu, l.SLxuat, l.Sophieuxuat, l.Madongxuattralai, l.SLnhap, p.HSD };

            foreach (var item in model)
            {
                Dongxuattralai temp = new Dongxuattralai();
                temp.Sophieuxuat = item.Sophieuxuat;
                temp.Malo = item.Malo;
                temp.SLnhap = item.SLnhap;
                temp.SLxuat = item.SLxuat;
                temp.Madongxuattralai = item.Madongxuattralai;
                temp.Tenvattu = item.Tenvattu;
                temp.HSD = item.HSD;
                listLinks.Add(temp);
            }

            return listLinks.OrderByDescending(x => x.Malo);
        }

    }
}
