using Model1.DTO;
using Model1.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model1.Dao
{
    public class LoDao
    {
        CSDL_NangcaoDbContext db = null;
        public LoDao()
        {
            db = new CSDL_NangcaoDbContext();
        }

        public long Sldong() { 
            long a = db.Loes.LongCount();
            return a;
        }

        public bool Updatexuat(ref string cc)
        {
            try
            {
                var model = from l in db.Dongxuats where l.Sophieuxuat == null select new { l.Madongxuat, l.Malo, l.SLxuat };
                foreach (var item in model)
                {
                    var pr1 = db.Loes.Find(item.Malo); /////
                    pr1.SLnhap += item.SLxuat; ////////

                }
                db.SaveChanges();
            }

            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public int Slcon(string ma)
        {
            var pr = db.Loes.Find(ma);
            int a = pr.SLnhap;
            return a;
        }

        public string Mavattu(string ma)
        {
            var pr = db.Loes.Find(ma);
            string a = pr.Mavattu;
            return a;
        }

        public string Hsd(string ma)
        {
            var pr = db.Loes.Find(ma);
            string a = pr.HSD.ToString();
            return a;
        }

        public string Insert(Lo order)
        {
            db.Loes.Add(order);
            db.SaveChanges();
            return order.Malo;
        }

        public bool Update(Lo entity)
        {
            try
            {
                var pr = db.Loes.Find(entity.Malo);
                pr.SLnhap = entity.SLnhap;
                pr.Dongia = entity.Dongia;
                pr.Sohoadon = entity.Sohoadon;
                pr.Solieutrenmotcai = entity.Solieutrenmotcai;
                pr.SDK_gnpk = entity.SDK_gnpk;
                pr.NSX = entity.NSX;
                pr.HSD = entity.HSD;
                pr.Machithidongbang = entity.Machithidongbang;
                pr.Machithinhietdo = entity.Machithinhietdo;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                //logging
                return false;
            }
        }

        public bool Update1(ref string a)
        {
            try
            {
                var model = from l in db.Loes where l.Sohoadon == null select new { l.Malo };
                foreach (var item in model)
                {
                    var pr = db.Loes.Find(item.Malo);
                    pr.Sohoadon = a;
                    
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
                var pr = db.Loes.Find(id);
                db.Loes.Remove(pr);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public Lo ViewDetail(string id)
        {
            return db.Loes.Find(id);
        }

        public long sllohethan()
        {
            var model = from l in db.Loes where l.HSD <= DateTime.Now && l.Sohoadon != null && l.SLnhap != 0 select new{l.Malo,};
            long a = model.LongCount();
            return a;
        }
        public long sllosaphethan()
        {
            var model = from l in db.Loes where DateTime.Now > EntityFunctions.AddDays(l.HSD, -30) && l.HSD > DateTime.Now && l.SLnhap != 0 select new { l.Malo, };
            long a = model.LongCount();
            return a;
        }

        public IEnumerable<LoDTO> ListAllPagingDxh()
        {
            List<LoDTO> listLinks = new List<LoDTO>();

            var model = from l in db.Loes // lấy toàn bộ sp
                        join k in db.Vattuytes on l.Mavattu equals k.Mavattu
                        where l.SLnhap != 0
                        select new
                        {l.Malo,l.SLnhap,l.Dongia,l.Sohoadon,l.Solieutrenmotcai,l.NSX,l.HSD,
                            l.Machithinhietdo,l.Machithidongbang,l.Dangdonggoi,l.Mavattu,k.Tenvattu};

            foreach (var item in model)
            {
                LoDTO temp = new LoDTO();
                temp.Malo = item.Malo;
                temp.SLnhap = item.SLnhap;
                temp.Dongia = item.Dongia;
                temp.Sohoadon = item.Sohoadon;
                temp.Solieutrenmotcai = item.Solieutrenmotcai;
                temp.NSX = item.NSX;
                temp.HSD = item.HSD;
                temp.Dangdonggoi = item.Dangdonggoi;
                temp.Machithinhietdo = item.Machithinhietdo;
                temp.Machithidongbang = item.Machithidongbang;
                temp.Mavattu = item.Mavattu;
                temp.Tenvattu = item.Tenvattu;
                listLinks.Add(temp);
            }

            return listLinks.OrderBy(x => x.HSD);
        }

        public IEnumerable<LoDTO> ListAllPaging()
        {
            List<LoDTO> listLinks = new List<LoDTO>();

            var model = from l in db.Loes // lấy toàn bộ sp
                        join k in db.Vattuytes on l.Mavattu equals k.Mavattu
                        //where l.Sohoadon == null
                        select new
                        {
                            l.Malo,l.SLnhap,l.Dongia,l.Sohoadon,l.Solieutrenmotcai,l.NSX,l.HSD,
                            l.Machithinhietdo,l.Machithidongbang,l.Dangdonggoi,l.Mavattu,k.Tenvattu
                        };

            foreach (var item in model)
            {
                LoDTO temp = new LoDTO();
                temp.Malo = item.Malo;
                temp.SLnhap = item.SLnhap;
                temp.Dongia = item.Dongia;
                temp.Sohoadon = item.Sohoadon;
                temp.Solieutrenmotcai = item.Solieutrenmotcai;
                temp.NSX = item.NSX;
                temp.HSD = item.HSD;
                temp.Dangdonggoi = item.Dangdonggoi;
                temp.Machithinhietdo = item.Machithinhietdo;
                temp.Machithidongbang = item.Machithidongbang;
                temp.Mavattu = item.Mavattu;
                temp.Tenvattu = item.Tenvattu;
                listLinks.Add(temp);
            }

            return listLinks.OrderByDescending(x => x.HSD);
        }

        public IEnumerable<LoDTO> ListAllPaging(string mactdb, string mactnd) // sohoadon = null
        {
            List<LoDTO> listLinks = new List<LoDTO>();

            var model = from l in db.Loes // lấy toàn bộ sp
                        join p in db.Chithidongbangs on l.Machithidongbang equals p.Machithidongbang
                        join q in db.Chithinhietdoes on l.Machithinhietdo equals q.Machithinhietdo
                        join k in db.Vattuytes on l.Mavattu equals k.Mavattu
                        where l.Sohoadon == null
                        select new { l.Malo, l.SLnhap, l.Dongia, l.Sohoadon, l.Solieutrenmotcai, l.NSX, l.HSD, l.Machithinhietdo, 
                            l.Machithidongbang, l.Dangdonggoi, p.Tenchithidongbang , q.Tenchithinhietdo, l.Mavattu, k.Tenvattu};

            foreach (var item in model)
            {
                LoDTO temp = new LoDTO();
                temp.Malo = item.Malo;
                temp.SLnhap = item.SLnhap;
                temp.Dongia = item.Dongia;
                temp.Sohoadon = item.Sohoadon;
                temp.Solieutrenmotcai = item.Solieutrenmotcai;
                temp.NSX = item.NSX;
                temp.HSD = item.HSD;
                temp.Dangdonggoi = item.Dangdonggoi;
                temp.Machithinhietdo = item.Machithinhietdo;
                temp.Machithidongbang = item.Machithidongbang;
                temp.Tenchithidongbang = item.Tenchithidongbang;
                temp.Tenchithinhietdo = item.Tenchithinhietdo;
                temp.Mavattu = item.Mavattu;
                temp.Tenvattu = item.Tenvattu;
                listLinks.Add(temp);
            }

            return listLinks.OrderByDescending(x => x.HSD);
        }

        public IEnumerable<LoDTO> ListAllPagingCheckHd() // sohoadon = null va ko co mactdb
        {
            List<LoDTO> listLinks = new List<LoDTO>();

            var model = from l in db.Loes // lấy toàn bộ sp
                        join p in db.Chithidongbangs on l.Machithidongbang equals p.Machithidongbang
                        join q in db.Chithinhietdoes on l.Machithinhietdo equals q.Machithinhietdo
                        join k in db.Vattuytes on l.Mavattu equals k.Mavattu
                        where l.Sohoadon == null
                        select new
                        {l.Malo,l.SLnhap,l.Dongia,l.Sohoadon,l.Solieutrenmotcai,l.NSX,l.HSD,
                            l.Machithinhietdo,l.Machithidongbang,l.Dangdonggoi,p.Tenchithidongbang,q.Tenchithinhietdo,l.Mavattu,k.Tenvattu
                        };

            foreach (var item in model)
            {
                LoDTO temp = new LoDTO();
                temp.Malo = item.Malo;
                temp.SLnhap = item.SLnhap;
                temp.Dongia = item.Dongia;
                temp.Sohoadon = item.Sohoadon;
                temp.Solieutrenmotcai = item.Solieutrenmotcai;
                temp.NSX = item.NSX;
                temp.HSD = item.HSD;
                temp.Dangdonggoi = item.Dangdonggoi;
                temp.Machithinhietdo = item.Machithinhietdo;
                temp.Machithidongbang = item.Machithidongbang;
                temp.Tenchithidongbang = item.Tenchithidongbang;
                temp.Tenchithinhietdo = item.Tenchithinhietdo;
                temp.Mavattu = item.Mavattu;
                temp.Tenvattu = item.Tenvattu;
                listLinks.Add(temp);
            }

            return listLinks.OrderByDescending(x => x.HSD);
        }

        public IEnumerable<LoDTO> ListAllPaging1(string tenvt, string hsd) // sohoadon # null
        {
            List<LoDTO> listLinks = new List<LoDTO>();

            var model = from l in db.Loes // lấy toàn bộ sp
                        join p in db.Chithidongbangs on l.Machithidongbang equals p.Machithidongbang
                        join q in db.Chithinhietdoes on l.Machithinhietdo equals q.Machithinhietdo
                        join k in db.Vattuytes on l.Mavattu equals k.Mavattu
                        join m in db.Hoadonnhaps on l.Sohoadon equals m.Sohoadon
                        join n in db.Khoes on m.Makhonhap equals n.Makho
                        join a in db.Nhasanxuats on k.Mansx equals a.Mansx
                        join b in db.Nguons on m.Manguon equals b.Manguon
                        where l.Sohoadon != null && l.SLnhap != 0
                        select new { l.Malo, l.SLnhap, l.Dongia, l.Sohoadon, l.Solieutrenmotcai, l.NSX, l.HSD, l.Machithinhietdo,
                            l.Machithidongbang, l.Dangdonggoi, p.Tenchithidongbang, q.Tenchithinhietdo, l.Mavattu, k.Tenvattu, n.Tenkho, a.Tennsx, b.Tennguon };

            //var model1 = from l in db.Loes
            //             join p in db.Chithidongbangs on l.Machithidongbang equals p.Machithidongbang
            //             join q in db.Chithinhietdoes on l.Machithinhietdo equals q.Machithinhietdo
            //             join k in db.Vattuytes on l.Mavattu equals k.Mavattu
            //             join m in db.Hoadonnhaps on l.Sohoadon equals m.Sohoadon
            //             join n in db.Khoes on m.Makhonhap equals n.Makho
            //             join a in db.Nhasanxuats on k.Mansx equals a.Mansx
            //             join b in db.Nguons on m.Manguon equals b.Manguon
            //             where (l.HSD - DateTime.Now).TotalDays < 31
            //             select new
            //             {
            //                 l.Malo,
            //                 l.SLnhap,
            //                 l.Dongia,
            //                 l.Sohoadon,
            //                 l.Solieutrenmotcai,
            //                 l.NSX,
            //                 l.HSD,
            //                 l.Machithinhietdo,
            //                 l.Machithidongbang,
            //                 l.Dangdonggoi,
            //                 p.Tenchithidongbang,
            //                 q.Tenchithinhietdo,
            //                 l.Mavattu,
            //                 k.Tenvattu,
            //                 n.Tenkho,
            //                 a.Tennsx,
            //                 b.Tennguon
            //             };

            if (tenvt != "tatca")
            {
                model = model.Where(x => x.Mavattu.Contains(tenvt) || x.Mavattu.Contains(tenvt));
            }

            if (hsd == "saphethan")
            {
                model = model.Where(x => EntityFunctions.AddDays(x.HSD,-30) < DateTime.Now  && (x.HSD) > DateTime.Now);
            }

            if (hsd == "dahethan")
            {
                model = model.Where(x => ((x.HSD) < DateTime.Now) || (x.HSD) == DateTime.Now);
            }

            if (hsd == "chuahethan")
            {
                model = model.Where(x => ((x.HSD) > DateTime.Now));
            }

            foreach (var item in model)
            {
                LoDTO temp = new LoDTO();
                temp.Malo = item.Malo;
                temp.SLnhap = item.SLnhap;
                temp.Dongia = item.Dongia;
                temp.Sohoadon = item.Sohoadon;
                temp.Solieutrenmotcai = item.Solieutrenmotcai;
                temp.NSX = item.NSX;
                temp.HSD = item.HSD;
                temp.Dangdonggoi = item.Dangdonggoi;
                temp.Machithinhietdo = item.Machithinhietdo;
                temp.Machithidongbang = item.Machithidongbang;
                temp.Tenchithidongbang = item.Tenchithidongbang;
                temp.Tenchithinhietdo = item.Tenchithinhietdo;
                temp.Mavattu = item.Mavattu;
                temp.Tenvattu = item.Tenvattu;
                temp.Tenkho = item.Tenkho;
                temp.Tennsx = item.Tennsx;
                temp.Tennguon = item.Tennguon;
                listLinks.Add(temp);
            }

            return listLinks.OrderByDescending(x=>x.HSD).ThenBy(x => x.Tenvattu);
        }

        public IEnumerable<LoDTO> ListAllPaging11(string tenvt, string hsd) // sohoadon # null
        {
            List<LoDTO> listLinks = new List<LoDTO>();

            var model = from l in db.Loes // lấy toàn bộ sp
                        join p in db.Chithidongbangs on l.Machithidongbang equals p.Machithidongbang
                        join q in db.Chithinhietdoes on l.Machithinhietdo equals q.Machithinhietdo
                        join k in db.Vattuytes on l.Mavattu equals k.Mavattu
                        join m in db.Hoadonnhaps on l.Sohoadon equals m.Sohoadon
                        join n in db.Khoes on m.Makhonhap equals n.Makho
                        join a in db.Nhasanxuats on k.Mansx equals a.Mansx
                        join b in db.Nguons on m.Manguon equals b.Manguon
                        where l.Sohoadon != null
                        select new
                        {
                            l.Malo,
                            l.SLnhap,
                            l.Dongia,
                            l.Sohoadon,
                            l.Solieutrenmotcai,
                            l.NSX,
                            l.HSD,
                            l.Machithinhietdo,
                            l.Machithidongbang,
                            l.Dangdonggoi,
                            p.Tenchithidongbang,
                            q.Tenchithinhietdo,
                            l.Mavattu,
                            k.Tenvattu,
                            n.Tenkho,
                            a.Tennsx,
                            b.Tennguon
                        };

            if (tenvt != "tatca")
            {
                model = model.Where(x => x.Mavattu.Contains(tenvt) || x.Mavattu.Contains(tenvt));
            }

            if (hsd == "saphethan")
            {
                model = model.Where(x => EntityFunctions.AddDays(x.HSD, -30) < DateTime.Now && (x.HSD) > DateTime.Now);
            }

            if (hsd == "dahethan")
            {
                model = model.Where(x => ((x.HSD) < DateTime.Now) || (x.HSD) == DateTime.Now);
            }

            if (hsd == "chuahethan")
            {
                model = model.Where(x => ((x.HSD) > DateTime.Now));
            }

            foreach (var item in model)
            {
                LoDTO temp = new LoDTO();
                temp.Malo = item.Malo;
                temp.SLnhap = item.SLnhap;
                temp.Dongia = item.Dongia;
                temp.Sohoadon = item.Sohoadon;
                temp.Solieutrenmotcai = item.Solieutrenmotcai;
                temp.NSX = item.NSX;
                temp.HSD = item.HSD;
                temp.Dangdonggoi = item.Dangdonggoi;
                temp.Machithinhietdo = item.Machithinhietdo;
                temp.Machithidongbang = item.Machithidongbang;
                temp.Tenchithidongbang = item.Tenchithidongbang;
                temp.Tenchithinhietdo = item.Tenchithinhietdo;
                temp.Mavattu = item.Mavattu;
                temp.Tenvattu = item.Tenvattu;
                temp.Tenkho = item.Tenkho;
                temp.Tennsx = item.Tennsx;
                temp.Tennguon = item.Tennguon;
                listLinks.Add(temp);
            }

            return listLinks.OrderBy(x => x.Tenvattu);
        }

        public IEnumerable<Lo> ListAllPagingWithSohd(Hoadonnhap hd)//string searchString, int page, int pageSize, 
        {
            List<Lo> listLinks = new List<Lo>();

            var model = from l in db.Loes
                        join c in db.Hoadonnhaps on l.Sohoadon equals c.Sohoadon
                        where l.Sohoadon == hd.Sohoadon
                        select new { l.Malo, l.SLnhap, l.Dongia, l.Sohoadon, l.Solieutrenmotcai, l.NSX, l.HSD, l.Machithinhietdo, l.Machithidongbang, l.Dangdonggoi, l.Mavattu };

            foreach (var item in model)
            {
                Lo temp = new Lo();
                temp.Malo = item.Malo;
                temp.SLnhap = item.SLnhap;
                temp.Dongia = item.Dongia;
                temp.Sohoadon = item.Sohoadon;
                temp.Solieutrenmotcai = item.Solieutrenmotcai;
                temp.NSX = item.NSX;
                temp.HSD = item.HSD;
                temp.Dangdonggoi = item.Dangdonggoi;
                temp.Machithinhietdo = item.Machithinhietdo;
                temp.Machithidongbang = item.Machithidongbang;
                temp.Mavattu = item.Mavattu;
                listLinks.Add(temp);
            }

            return listLinks.OrderByDescending(x => x.HSD);
        }

      
    }
}
